using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SteeringBehaviour : MonoBehaviour
{
    public float weighting = 7.5f;
    //ref to owner for getting velocity
    protected AI owner;

    //getcomponents
    void Awake()
    {
        owner = GetComponent<AI>();
    }

    public virtual Vector3 GetForce()
    {
        //set force 0
        Vector3 force = Vector3.zero;
        //do nothing

        //return force
        return force;
    }
    // Update is called once per frame
    void Update()
    {

    }

}

