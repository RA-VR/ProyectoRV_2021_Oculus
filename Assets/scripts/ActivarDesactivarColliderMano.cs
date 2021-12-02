using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarDesactivarColliderMano : MonoBehaviour
{
    public GameObject Collider1;
    public GameObject Collider2;
    private void Start()
    {
        Collider1.SetActive(false); ;
        Collider2.SetActive(false); ;
    }
    private void OnTriggerEnter(Collider other)
    {

       if(other.tag == "Player")
        {

            Collider1.SetActive(true); ;
            Collider2.SetActive(true); ;

                Debug.Log("Desaparecer Colliders");
                
            } 
     }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {

            Collider1.SetActive(false); ;
            Collider2.SetActive(false); ;

            Debug.Log("Aparecer Colliders");

        }

    }
}