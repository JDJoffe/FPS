using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AI : MonoBehaviour
{
    protected Vector3 velocity;
    public float maxVelocity = 5f, maxDistance = 5f;
    protected NavMeshAgent agent;
    protected SteeringBehaviour[] aiBehaviours;

    //getcomponents
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        //get all steering behaviours on AI
        aiBehaviours = GetComponents<SteeringBehaviour>();
    }
    public virtual Vector3 CalculateForce()
    {

        //set force to 0
        Vector3 force = Vector3.zero;
        // limit total velocity to max if exceeded
        //if velocity magnitude > maxvelocity
        if (velocity > maxVelocity)
        {

        }
        //set velocity to velocity normalized * max velocity
        //set destinatio navmeshagent
        //return force
        return force;
    }
   
   

  
}
