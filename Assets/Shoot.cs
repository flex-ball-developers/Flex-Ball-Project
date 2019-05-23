using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public GameObject Player;
    protected Rigidbody2D rb2d;
    public Vector2 spawnPoint;
    public Vector2 dir;
    public Vector2 target;
    public float bulletSpeed = 5f;

  

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        //Enemy bullet
        //target.x = Player.transform.position.x;
        //target.y = Player.transform.position.y;
        //spawnPoint = gameObject.transform.position;

        //Player to the right
        target.x = Player.transform.position.x + 1;
        target.y = Player.transform.position.y;
        spawnPoint = Player.transform.position;

        


        dir = target - spawnPoint;
        rb2d.velocity = dir.normalized * bulletSpeed;
    }
	
	// Update is called once per frame
	void Update () {
        
   
    }
}
