using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerColliderStart : MonoBehaviour
{
    public UnityEvent OnTriggerEnter_;
    public UnityEvent OnTriggerStay__;
    public UnityEvent OnTriggerExit_;

    private void OnTriggerEnter(Collider other)
    {
       if(other.tag=="Player") OnTriggerEnter_.Invoke();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player") OnTriggerStay__.Invoke();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") OnTriggerExit_.Invoke();
    }

}
