using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 10.0f;
    public float jumpSpeed = 8.0f;
    public float turnSpeed = 5.0f;
    public int attack = 1;
    public int hp = 8;
	// Use this for initialization
	void Start () {
        //Cursor.visible = false;
    attack = 1;
    hp = 8;
}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void Move()
    {
        //accrue values for up-down and side movement
        float fwd = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float side = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float jump = Input.GetAxis("Jump") * jumpSpeed * Time.deltaTime;

        //move the character's position
        transform.Translate(side, jump, fwd);

        //rotate the character
        float turn = Input.GetAxis("Mouse X") * turnSpeed;
        transform.Rotate(0, turn, 0);
    }

    public void hpUpgrade ()
    {
        hp += 5;
        GameObject.Find("PlayerCollider").GetComponent<TakeDamage>().currentHealth = hp;
        print("hp Upgrade");
    }
    public void atkUpgrade()
    {
        attack += 1;
        print("atk upgrade");
    }
}
