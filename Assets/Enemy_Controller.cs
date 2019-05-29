using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : PhysicsObject {

    public float ShootTimer = 0f;
    public GameObject Bullet;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ShootTimer += 1 * Time.deltaTime;

        if(ShootTimer > 3.0f)
        {
          

            Instantiate(Bullet, gameObject.transform);
            ShootTimer = 0;
        }
	}
}
