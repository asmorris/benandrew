using UnityEngine;
using System.Collections;

public class Mastermind : MonoBehaviour {


    public float spawnTime = 5f;		// The amount of time between each spawn.
    public float spawnDelay = 3f;		// The amount of time before spawning starts.
    public Spawner[] motherShips;

	// Use this for initialization
	void Start () 
    {
        // Start calling the Spawn function repeatedly after a delay .
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
	}

    void Spawn()
    {

    }
}
