using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek :SteeringBehaviour
{
    public Transform target;
    public float stoppingDistance;

    public override Vector3 GetForce()
    {
        Vector3 force =Vector3.zero;
        // Step 1). Check if we have a valid target
        // IF target is null
        //  return force (zero)
        if (target == null)
        {

        }
        // Step 2). Get direction we want to go
        // SET desiredForce to target - current

        // Step 3). Apply weighting to desired force
        // IF desiredForce distance is greater than stoppingDistance
        //  SET desiredForce to restricted desiredForce (using weighting)
        //  SET force to desiredForce - velocity

        return force;
    }
}
