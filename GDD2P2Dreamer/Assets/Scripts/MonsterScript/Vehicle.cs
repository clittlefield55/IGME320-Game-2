using UnityEngine;
using System.Collections;

//use the Generic system here to make use of a Flocker list later on
using System.Collections.Generic;

[RequireComponent(typeof(CharacterController))]

abstract public class Vehicle : MonoBehaviour {

	//no position - transform.position will be used instead
	protected Vector3 acceleration;
	protected Vector3 velocity;
	protected Vector3 desired;

	//access to game manager script
	//protected GameManager gm;

	public Vector3 Velocity {
		get { return velocity; }
	}
	
	public float maxSpeed = 3.0f;
	public float maxForce = 6.0f;
	public float mass = 1.0f;
	public float radius = 1.0f;
    public GameObject body;
	CharacterController charControl;

	abstract protected void CalcSteeringForces();

	virtual public void Start(){
		acceleration = Vector3.zero;
		velocity = body.transform.forward;
		desired = Vector3.zero;

		//store access to character controller component
		charControl = GetComponent<CharacterController>();

		//access to game obj holding gm script
		//gm = GameObject.Find("GameManagerGO").GetComponent<GameManager>();
	}

	
	// Update is called once per frame
	protected void Update () {
		CalcSteeringForces ();

		//add accel to vel
		velocity += acceleration * Time.deltaTime;
		velocity.y = 0;
		//limit velo to max speed
		velocity = Vector3.ClampMagnitude (velocity, maxSpeed);

        //dude face torward target
        //transform.forward = velocity.normalized;
        //transform.forward = desired.normalized;
		//added vel to pos to move
		charControl.Move (velocity * Time.deltaTime);

		Vector3 pos = body.transform.position;
        body.transform.position = pos;
		//reset accel
		acceleration = Vector3.zero;

	}

	protected void ApplyForce(Vector3 steeringForce){
		acceleration += steeringForce / mass;
	}

	protected Vector3 Seek(Vector3 targetPosition){ 
		desired = targetPosition - body.transform.position;
        body.transform.forward = -desired.normalized;

        desired = desired.normalized * maxSpeed;
		Vector3 seekingForce = desired - velocity;
		seekingForce.y = 0;
        return seekingForce; 
	}


	/*protected Vector3 AvoidObstacle(GameObject obst, float sD){
		desired = Vector3.zero;
		//distance from dude to obstacle
		Vector3 vecToCenter = obst.transform.position - transform.position;
		vecToCenter.y =0;
		//radius of obstacle
		float obstRad = obst.GetComponent<ObstacleScript> ().Radius;
		//calculate safe distance
		if (vecToCenter.magnitude > sD) {
			return Vector3.zero;
		}
		//check obstacle behind
		if (Vector3.Dot (vecToCenter, transform.forward) < 0) {
			return Vector3.zero;
		}
		//will it not collide?
		if (Mathf.Abs (Vector3.Dot (vecToCenter, transform.right)) > obstRad + radius) {
			return Vector3.zero;
		}
		//will it collide?
		//is it on your left or right?
		if(Vector3.Dot(vecToCenter, transform.right) < 0){ //on left move right
			desired = transform.right * maxSpeed;
			//debug line to see if the dude is avoiding to the right
			//Debug.DrawLine(transform.position, obst.transform.position, Color.red);
			Debug.DrawLine(obst.transform.position, transform.position, Color.red);
		}
		else { //on right move left
			desired = transform.right * -maxSpeed;
			//debug line to see if the dude is avoiding to the left
			Debug.DrawLine(transform.position, obst.transform.position, Color.green);
		}
		return desired;
	}*/


}
