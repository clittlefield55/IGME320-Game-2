using UnityEngine;
using System.Collections;

public class ignoreCoin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(UnityEngine.Collision col)
    {
        if (col.gameObject.tag == "Coin")
        {
            Physics.IgnoreCollision(col.gameObject.GetComponent<Collider>(), GetComponent<Collider>());

        }
    }

}
