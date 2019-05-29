using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AI : MonoBehaviour
{
    //var
    public float maxVelocity = 5f, maxDistance = 5f;
    protected NavMeshAgent agent;
    protected SteeringBehaviour[] aiBehaviours;
    protected Vector3 velocity;
    //property
    public Vector3 Velocity
    {
        protected set { velocity = value; }
        get { return velocity; }
    }
    //getcomponents
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        //get all steering behaviours on AI
        aiBehaviours = GetComponents<SteeringBehaviour>();
    }
    private void Update()
    {
        CalculateForce();
    }
    public virtual Vector3 CalculateForce()
    {
        // Pseudocode
        // 1 Create a result Vector3
        // SET force to zero
        Vector3 force = Vector3.zero;

        // 2 Loop through all behaviours and get forces
        // 3 Limit the total force to max speed
        foreach (var aiBehaviour in aiBehaviours)
        {
            // Apply force to behaviour.GetForce * weighting
            force += aiBehaviour.GetForce() * aiBehaviour.weighting;
            //if force magnitude > maxvelocity
            if (force.magnitude > maxVelocity)
            {
                //set force to force normalized * maxspeed
                force = force.normalized * maxVelocity;
                //break - exit loop
                break;
            }

        }
        // 4 Limit the total velocity to our max velocity if it exceeds
        velocity += force * Time.deltaTime;
        // IF velocity magnitude > max velocity
        if (velocity.magnitude > maxVelocity)
        {
            //  SET velocity to velocity normalized * max velocity
            velocity = velocity.normalized * maxVelocity;
        }
        // 5  destination for NavMeshAgent
        //if velocity magnitude > 0
        if (velocity.magnitude > 0)
        {
            //set pos to current  (position) + velocity * deltatime
            Vector3 pos = transform.position + velocity * Time.deltaTime;
            NavMeshHit hit;
            //if navmesh sampleposition within navmesh
            if (NavMesh.SamplePosition(pos, out hit, maxDistance, -1))
            {
                //set agent destination to hit position
                agent.SetDestination(hit.position);
            }

        }


        // 6 Return force
        return force;
    }

   


}
