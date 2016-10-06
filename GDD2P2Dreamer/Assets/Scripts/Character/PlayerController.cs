using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 10.0f;
    public float jumpSpeed = 8.0f;
    public float turnSpeed = 5.0f;
	// Use this for initialization
	void Start () {
	
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

    void TakeDamage()
    {

    }
}
