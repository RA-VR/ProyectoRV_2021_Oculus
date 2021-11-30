using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparecerLetrero : MonoBehaviour
{

    public string tago;

    public GameObject destruir1;
    public GameObject aparecer1;
    private void OnTriggerEnter(Collider other)

    {

        if (other.CompareTag(tago))
        {
            aparecer1.SetActive(true);
        }


    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag(tago))
        {
            aparecer1.SetActive(false);
        }

    }
}
