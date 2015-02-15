using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float topSpeed;
    public float moveForce;
    public float screenCollisionBuffer;

    void Start()
    {
        //Set start position
    }

	// Update is called once per frame
	void Update () 
    {
        //Move player
        CheckInputs();
        CheckLeftSideOfScreen();
        CheckRightSideOfScreen();
	}

    //Player Controller
    void CheckInputs()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.touches[0];
            if (touch.position.x < Screen.width / 2)
            {
                rigidbody2D.AddForce(Vector2.right * -1 * moveForce * Time.deltaTime);
            }
            else if (touch.position.x > Screen.width / 2)
            {
                rigidbody2D.AddForce(Vector2.right * moveForce * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.A) && !CheckLeftSideOfScreen())
        {
            //Move left
            rigidbody2D.AddForce(Vector2.right * -1 * moveForce * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) && !CheckRightSideOfScreen())
        {
            //Move Right
            rigidbody2D.AddForce(Vector2.right * moveForce * Time.deltaTime);
        }

        // If the player's horizontal velocity is greater than the maxSpeed...
        if (Mathf.Abs(rigidbody2D.velocity.x) > topSpeed)
        {
            // ... set the player's velocity to the maxSpeed in the x axis.
            rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * topSpeed, rigidbody2D.velocity.y);
        }
    }

    bool CheckLeftSideOfScreen()
    {
        float xPos = gameObject.transform.position.x;
        float size = gameObject.renderer.bounds.size.x / 2;
        var dist = (transform.position - Camera.main.transform.position).z; 
        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x; 

        if (xPos - size <= leftBorder)
        {
            rigidbody2D.velocity = Vector2.zero;
            return true;
        }
        return false;
    }

    bool CheckRightSideOfScreen()
    {
        float xPos = gameObject.transform.position.x;
        float size = gameObject.renderer.bounds.size.x / 2;
        var dist = (transform.position - Camera.main.transform.position).z;
        var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;

        if (xPos + size >= rightBorder)
        {
            rigidbody2D.velocity = Vector2.zero;
            return true;
        }
        return false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // If the colliding gameobject is an Enemy...
        if (col.gameObject.tag == "Enemy")
        {
            GloriousDeath();
        }
    }

    void GloriousDeath()
    {
        Debug.Log("OH NO I'm Dead!");
        Destroy(gameObject);
    }
}
