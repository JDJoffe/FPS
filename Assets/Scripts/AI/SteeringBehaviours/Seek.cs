﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : SteeringBehaviour
{
    public Transform target;
    public float stoppingDistance;

    public override Vector3 GetForce()
    {
        Vector3 force = Vector3.zero;
        // Step 1). Check if we have a valid target
        //target !=null
        if (target)
        {
            // Step 2). Get direction we want to go
            // SET desiredForce to target - current
            Vector3 desiredForce = target.position - transform.position;
            // Step 3). Apply weighting to desired force
            // IF desiredForce distance is greater than stoppingDistance
            if (desiredForce.magnitude > stoppingDistance)
            {
                //  SET desiredForce to restricted desiredForce (using weighting)
                desiredForce = desiredForce.normalized * weighting;
                //  SET force to desiredForce - velocity
                force = desiredForce - owner.Velocity;
            }
        }
        //  return force (zero)
        return force;
    }
    private void OnDrawGizmos()
    {


        Debug.DrawLine(transform.position, target.position, Color.red);
        Gizmos.DrawWireSphere(transform.position ,  2);
       
    }
}
