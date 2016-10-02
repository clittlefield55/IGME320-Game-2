using UnityEngine;
using System.Collections;

public abstract class RangedWeapon : Weapon {

    public GameObject bullet;
    float bulletSpeed;
    float maxProjectileRange;

    // Use this for initialization
    public override void Start () {
	
	}
	
	// Update is called once per frame
	protected override void Update () {
	
	}

    protected override void Attack()
    {

    }
}
