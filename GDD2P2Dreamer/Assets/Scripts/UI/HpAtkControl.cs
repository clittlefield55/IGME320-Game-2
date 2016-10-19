using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HpAtkControl : MonoBehaviour {


    UnityEngine.UI.Text hpText;
    UnityEngine.UI.Text atkText;

    int hp = 0;
    int atk = 0;

    // Use this for initialization
    void Start () {
        // set hp and attack
        hp = GameObject.Find("PlayerCollider").GetComponent<TakeDamage>().totalHealth;
        //atk = GameObject.FindGameObjectWithTag("PlayerBullet").GetComponent<Spray>().atk;
        // text
        hpText = GameObject.Find("HpText").GetComponent<Text>();
        atkText = GameObject.Find("AtkText").GetComponent<Text>();
        hpText.text = "Health: " + hp;
        atkText.text = "Attack: " + atk;
    }
	
	// Update is called once per frame
	void Update () {
        hp = GameObject.Find("PlayerCollider").GetComponent<PlayerController>().hp;
        atk = GameObject.Find("PlayerCollider").GetComponent<PlayerController>().attack;

        hpText.text = "Health: " + hp;
        atkText.text = "Attack: " + atk;


    }
}
