using UnityEngine;
using System.Collections;

public class Spray : MonoBehaviour {
    public int atk;
    float sprayLife;
    float maxLife;
    float bulletSpeed;
    Vector3 velocity;
    //Enemy nme;
    GameObject enemy;
    bool ifHit;
    // Use this for initialization
    void Start () {
        sprayLife = 0.0f;
        maxLife = 0.5f;
        bulletSpeed = 0.02f;
        velocity = Vector3.zero;
        ifHit = false;
        atk = 1;
	}
	
	// Update is called once per frame
	void Update () {
        atk = GameObject.Find("PlayerCollider").GetComponent<PlayerController>().attack;

        sprayLife += Time.deltaTime; //add the game tick's time to the bullet life
        Move(); //make the bullet move
        if (sprayLife >= maxLife) //if the bullet runs out of time
        {
            Destroy(this.gameObject); // destroy the bullet
        }




    }

    void OnCollisionEnter(UnityEngine.Collision splat)
    {
        Debug.Log("Collide!");

        if (splat.gameObject.tag == "Enemy")
        {
            Debug.Log("Ouch!");
            // insert take damage code here.
            //nme = splat.gameObject;
            //nme.takeDamage(10);

            //var obj = splat.gameObject.GetComponent<TakeDamage>();
            //obj.GetDamage(1);
            //enemy = splat.gameObject;
            //enemy.GetComponent<TakeDamage>().GetDamage(1);

            splat.gameObject.GetComponent<TakeDamage>().GetDamage(atk);
         
            Debug.Log("Hit!"+splat.gameObject.name);

            Destroy(gameObject);


        }
        else if (splat.gameObject.tag == "Player")
        {
            // nothing happen
        }
        else
        {
            Destroy(gameObject);
        }
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
