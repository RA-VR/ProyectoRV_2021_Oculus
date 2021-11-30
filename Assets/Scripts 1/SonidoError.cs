using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoError : MonoBehaviour
{
    //public GameObject test;
    public string tago;

    
    public AudioSource audioSource;
    //private bool activated = false;

    void Start()
    {
        //gameObject.tag = test;
    }

    private void OnTriggerEnter(Collider other)

    {

        if (other.CompareTag(tago))
        {
            audioSource.Play();
        }

        //if (other.CompareTag(tag))
        //{

        //    aparecer1.SetActive(true);

        //    if (!activated)
        //    {
        //        activated = true;

        //        audioSource.enabled = true;


        //    }
        //}


    }
    
}
