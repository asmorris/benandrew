using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {


	// Use this for initialization
	void Start () 
    {
   
	}
	
	// Update is called once per frame
	void Update () 
    {
        CheckPosition();
	}

    private void CheckPosition()
    {
        if (this.transform.position.y < -(Screen.height/2))
        {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
