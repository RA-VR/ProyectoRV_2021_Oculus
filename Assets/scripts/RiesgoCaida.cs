using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiesgoCaida : MonoBehaviour
{
    public float Distancia;
    public float MenorDistancia;
    public int num_Distancias;
    public float[] Distancias;
    public Transform Camara;
    public Transform GuanteIz;
    public Transform GuanteDr;
    public GameObject PosiblesCaidas;


    void Start()
    {
            PosiblesCaidas = GameObject.FindGameObjectWithTag("Riesgo Caida");
    }

    // Update is called once per frame
    void Update()
    {
            Distancia = Vector3.Distance(Camara.position, PosiblesCaidas.GetComponent<Transform>().position);

            Debug.Log(Distancia); 

    }
}