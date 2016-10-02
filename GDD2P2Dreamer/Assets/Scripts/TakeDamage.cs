using UnityEngine;
using System.Collections;

public class TakeDamage : MonoBehaviour {

    public int totalHealth = 5;
    public int currentHealth;
    bool isDead;
    public GameObject mainBody;
	// Use this for initialization
	void Start () {
        currentHealth = totalHealth;
        isDead = false;
	}
	
	// Update is called once per frame
	void Update () {

        // if damaged // fade out
        //if(Input.GetKeyDown(KeyCode.G))
        //{
        //    GetDamage(1);
        //    print(currentHealth);
        //}
        // if died // destroy 
        if (isDead == true)
        {
            DeadEffect();
            print("Died");
        }
	}

    public void GetDamage(int damage)
    {
        // if died
        if(isDead)
        {
            return; // exit loop
        }

        // defuce current health
        currentHealth -= damage;
        print(currentHealth);

        if (currentHealth <= 0)
        {
            // set boolean
            isDead = true;
        }
    }

    public void DeadEffect()
    {

        Destroy(mainBody, 0.1f);
    }


}
