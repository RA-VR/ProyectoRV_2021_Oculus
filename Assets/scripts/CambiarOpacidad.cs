using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarOpacidad : MonoBehaviour
{
    public float Distancia;
    public Transform Camara;
    

    void Start()
    {
        foreach (GameObject z in GameObject.FindGameObjectsWithTag("Riesgo Caida"))
        {
            

        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject z in GameObject.FindGameObjectsWithTag("Riesgo Caida"))
        {
            Distancia = Vector3.Distance(transform.position, z.GetComponent<Transform>().position);

        }
    }
}
