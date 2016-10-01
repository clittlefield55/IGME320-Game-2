using UnityEngine;
using System.Collections;

public class Spray : MonoBehaviour {

    float sprayLife;
    float maxLife;
    float bulletSpeed;
    Vector3 velocity;
    //Enemy nme;

	// Use this for initialization
	void Start () {
        sprayLife = 0.0f;
        maxLife = 0.5f;
        bulletSpeed = 0.02f;
        velocity = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
        sprayLife += Time.deltaTime; //add the game tick's time to the bullet life
        Move(); //make the bullet move
        if (sprayLife >= maxLife) //if the bullet runs out of time
        {
            Destroy(this.gameObject); // destroy the bullet
        }
	}

    void OnCollisionEnter(Collision splat)
    {
        print("Ouch!");
        if(splat.gameObject.tag == "Enemy")
        {
            // insert take damage code here.
            //nme = splat.gameObject;
            //nme.takeDamage(10);
        }

        Destroy(this.gameObject);
    }

    void Move()
    {
        Vector3 direction = transform.forward;
        direction *= bulletSpeed;
        velocity += direction;
        Vector3.ClampMagnitude(velocity, 2.0f);
        transform.position += velocity;
    }
}
