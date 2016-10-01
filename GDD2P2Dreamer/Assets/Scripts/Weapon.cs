using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour {
    public string weaponName;

	// Use this for initialization
	public virtual void Start () {
	
	}

    // Update is called once per frame
    protected virtual void Update () {
	
	}

    abstract protected void Attack();
}
