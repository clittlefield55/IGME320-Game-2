using UnityEngine;
using System.Collections;

public class WaterGun : MonoBehaviour {

    public GameObject bullet;
    string weaponName;
    int bulletSpeed;
    int ammo;
    float ammoCoolDown;
    float counter;
    bool isFiring;
    bool hasFired;
    

	// Use this for initialization
	void Start ()
    {
        weaponName = "Water Gun";
        bulletSpeed = 500;
        ammo = 5000;
        isFiring = false;

	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
	}

    void Fire()
    {
        Object spray = Instantiate(bullet, transform.position, GetComponent<Rigidbody>().transform.rotation);
    }
}
