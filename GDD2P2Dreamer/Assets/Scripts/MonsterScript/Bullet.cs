using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {


    private float spawnTime;

	// Use this for initialization
	void Start () {
        spawnTime = Time.time;
	}

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= spawnTime + 2)
        {
            //print("Destroy through time");
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(UnityEngine.Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            //Debug.Log("Ouch!");
            // insert take damage code here.
            //nme = splat.gameObject;
            //nme.takeDamage(10);

            //var obj = splat.gameObject.GetComponent<TakeDamage>();
            //obj.GetDamage(1);
            //enemy = splat.gameObject;
            //enemy.GetComponent<TakeDamage>().GetDamage(1);

            col.gameObject.GetComponent<TakeDamage>().GetDamage(1);

            Debug.Log("Hit!" + col.gameObject.name);

            //Destroy(gameObject);


        }
        Destroy(gameObject);
    }
}
