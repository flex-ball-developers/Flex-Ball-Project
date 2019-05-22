using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public GameObject Player;
    public Vector2 spawnPoint;
    public Vector2 dir;
    public Vector2 playerLocation;

    // Use this for initialization
    void Start () {
        playerLocation.x = Player.transform.position.x;
        playerLocation.y = Player.transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {
       dir = spawnPoint - playerLocation;
	}
}
