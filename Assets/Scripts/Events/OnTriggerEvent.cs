using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;
public class OnTriggerEvent : MonoBehaviour
{
    //reference tag to detect collisions
    public string hitTag;
    public UnityEvent onEnter;


    private void OnTriggerEnter(Collider other)
    {
        //if hitting hit tag or hitTag is set to nothing
        if (other.tag == hitTag ||  hitTag == "")
        {
            //Invoke 
            onEnter.Invoke();
        }
    }
}
