using UnityEngine;
using System.Collections;

public class FireBullet : MonoBehaviour {

    //private int bulletSpeed;
    //protected bool active;
    //protected Vector3 desired;
    //private int counter;
    //private Vector3 originPos;

    //public GameObject player;
    //public GameObject body;
    // Use this for initialization
    public Rigidbody BulletPrefab;
    public float Speed = 10;

	void Start () {
        //bulletSpeed = 100;
        //active = false;
        //counter = 0;
        //transform.position = body.transform.position;
        //originPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //float distBetweenPlayer = Vector3.Distance(player.transform.position, body.transform.position);
        //if(distBetweenPlayer <= 50 && active == false)
        //{
        //    fire();
        //    print("FIREEEEEEEEEEEEEEEEEEEE");
        //}

        //if(IfCollide() == true)
        //{
        //    transform.position = originPos;

        //    print("Enemy hit the player.......");
        //}
        if(Input.GetKeyDown(KeyCode.F))
        {
            Fire();
        }

    }

    void Fire()
    {
        Rigidbody bullet = (Rigidbody)Instantiate(BulletPrefab, transform.position, transform.rotation);
        bullet.velocity = -transform.forward * Speed;
    }
}
