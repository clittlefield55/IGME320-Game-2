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
    public float Speed = 0.05f;
    public GameObject target;

    public float fireRate = 2.0f;
    private float nextFire = 0.0f;

    void Start()
    {
        //bulletSpeed = 100;
        //active = false;
        //counter = 0;
        //transform.position = body.transform.position;
        //originPos = transform.position;

        //InvokeRepeating("Fire", 2.0f, 2.0f);



    }

    // Update is called once per frame
    void Update()
    {
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

        Vector3 dist = target.transform.position - transform.position;

        if (dist.magnitude < 4 && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
        }

        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    Fire();
        //}

    }

    void Fire()
    {
        Rigidbody bullet = (Rigidbody)Instantiate(BulletPrefab, transform.position, transform.rotation);
        bullet.velocity = -transform.forward * Speed;
    }
}
