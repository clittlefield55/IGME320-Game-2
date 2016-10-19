using UnityEngine;
using System.Collections;

public class Seeker : Vehicle {

    public GameObject seekerTarget;


    //weighting
    public float seekWeight = 60.0f;

    //ultimate steering force that will be applied to acceleration
    private Vector3 ultimateForce;

    //define necessary weights for seeker
    //public float avoidWeight = 30.0f;
    //public float sepWeight = 10.0f;
    //public float allignWeight = 20.0f;
    //public float cohWeight = 50.0f;




    // Call Inherited Start and then do our own
    override public void Start()
    {
        base.Start();
        ultimateForce = Vector3.zero;
    }

    protected override void CalcSteeringForces()
    {
        seekerTarget = GameObject.Find("body"); // not sure

        //reset ultimate force
        ultimateForce = Vector3.zero;

        //get a seeking force (based on char movement - for now, just seek)
        //add that seeking force to the ultimate steering force

        Vector3 dist = seekerTarget.transform.position - transform.position;
        if (dist.magnitude <= 4)
        {
            maxSpeed = 0f;
            ultimateForce += Seek(seekerTarget.transform.position) * seekWeight;
        }
        else
        {
            maxSpeed = 1f;
            ultimateForce += Seek(seekerTarget.transform.position - new Vector3(0, 0, 0)) * seekWeight;
        }

        //avoiding obstacle
        //for(int i = 0; i < gm.Obstacles.Length; i++){
        //	ultimateForce += AvoidObstacle(gm.Obstacles[i], 5) * avoidWeight;
        //}

        //limit steering force
        ultimateForce = Vector3.ClampMagnitude(ultimateForce, maxForce);

        //applyForce to acceleration
        ApplyForce(ultimateForce);
    }
}
