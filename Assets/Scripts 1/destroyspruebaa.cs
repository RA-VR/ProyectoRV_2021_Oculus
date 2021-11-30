using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyspruebaa : MonoBehaviour
{
    public GameObject destruir1;
    public GameObject aparecer1;
    public AudioSource audioSource;
    //private bool activated = false;
    private void OnTriggerEnter(Collider other)

    {

            if (other.CompareTag("Player"))
            {
                Destroy(destruir1,0.0f);
            }

         
            if (other.CompareTag("Player"))
            {
               aparecer1.SetActive(true);
            }
           
        if (other.CompareTag("Player"))
        {
            audioSource.enabled = true;
        }
    }

    
}
