using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsignarTag : MonoBehaviour
{
    //public GameObject test;
    public string tago;
    public static int ObjetosPuestos;

    public GameObject destruir1;
    public GameObject aparecer1;
    public GameObject Correcto;
    public GameObject Incorrecto;
    public GameObject BloqueoPuerta;
    public GameObject BotónPuerta;
    //public AudioSource audioSource;
    //private bool activated = false;

    void Start()
    {
        //ObjetosPuestos = 0;
    }
    private void Update()
    {
        if (ObjetosPuestos >= 7)
        {
            if(BloqueoPuerta!= null) BloqueoPuerta.SetActive(false);
            if (BotónPuerta != null) BotónPuerta.SetActive(true);
            ObjetosPuestos = 0;
        }
    }

    private void OnTriggerEnter(Collider other)

    {

        if (other.CompareTag(tago))
        {
            Destroy(destruir1, 0.0f);
            aparecer1.SetActive(true);
            Correcto.SetActive(true);
            Incorrecto.SetActive(false);
            ObjetosPuestos++;
        }
        else
        {
            Incorrecto.SetActive(true);
            Correcto.SetActive(false);
        }
    }
}
