using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TakeDamage : MonoBehaviour {

    public Object pickup;
    public int totalHealth = 10;
    public int currentHealth;
    private Image healthBar;

    bool isDead;
    public GameObject mainBody;
	// Use this for initialization
	void Start () {
        if (this.gameObject.tag == "Enemy")
        {
            totalHealth = 10;
            healthBar = transform.FindChild("EnemyCanvas").FindChild("HealthBar").FindChild("Health").GetComponent<Image>();
        }
        if(this.gameObject.tag == "Player")
        {
            //totalHealth = 20;
            totalHealth = GameObject.Find("PlayerCollider").GetComponent<TakeDamage>().totalHealth;
            healthBar = transform.FindChild("PlayerCanvas").FindChild("HealthBar").FindChild("Health").GetComponent<Image>();
        }
        currentHealth = totalHealth;
        isDead = false;
	}
	
	// Update is called once per frame
	void Update () {

        totalHealth = GameObject.Find("PlayerCollider").GetComponent<PlayerController>().hp;
        print(totalHealth);
        //currentHealth = totalHealth;
    
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
        // healthBar.fillAmount- (float)currentHealth/(float)totalHealth;
        healthBar.fillAmount = (float)currentHealth / (float)totalHealth;
        if (currentHealth <= 0)
        {
            // set boolean
            isDead = true;
        }
    }

    public void DeadEffect()
    {
        if (this.gameObject.tag == "Enemy")
        {
            Instantiate(pickup, transform.position, Quaternion.identity);
        }

        Destroy(mainBody, 0.1f);
        if (this.gameObject.tag == "Player")
        {
            Application.LoadLevel("Death");
        }
    }


}
