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

    //sound
    public AudioClip fireSound;

    private AudioSource source3;

	// Use this for initialization
	void Start ()
    {
        weaponName = "Water Gun";
        bulletSpeed = 500;
        ammo = 5000;
        isFiring = false;

    }

    void Awake()
    {
        source3 = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
            source3.PlayOneShot(fireSound, 10f);
        }
    }

    void Fire()
    {
        Object spray = Instantiate(bullet, transform.position, transform.rotation);
    }
}
