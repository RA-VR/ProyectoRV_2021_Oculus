using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetection : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioSource audioSource2;
    public GameObject aparecer1;
    public GameObject aparecer2;
    public GameObject aparecer3;

    private bool activated=false;

    private void Start()
    {
        
    }

    private void MyFunction()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I'm the trigger, someone has enter");

        if (other.tag == "Player") 
        {

            aparecer3.SetActive(true);
            aparecer2.SetActive(true);
            if (!activated)
            {
                activated = true;

                audioSource.enabled=true;
                audioSource2.enabled = true;
                aparecer1.SetActive(true);
                
            }
        }

    }


    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit Event");

        if (other.tag == "Player")
        {

            aparecer3.SetActive(false);
            aparecer2.SetActive(false);
            aparecer1.SetActive(false);
        }


    }
}
