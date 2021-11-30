using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionCarteles : MonoBehaviour
{
    public Transform Camara;
    public Quaternion AnguloInicial;
    public Vector3 AnguloFinal;
    public float c;
    public float b;
    public float a;
    public float Radianes;
    public float Grados;
[SerializeField]
    public bool GiroActivo = true;
        [Range(-1,1)]
    public float gIRO;
   
    private void Update()
    {
        if (GiroActivo)
        {
            c = Camara.position.x - transform.position.x;
            a = Camara.position.z - transform.position.z;

            b = Mathf.Sqrt(a * a + c * c);

            Radianes = Mathf.Asin(c / b);
            Grados = Radianes * Mathf.Rad2Deg;
            AnguloInicial = transform.rotation;
            AnguloFinal = new Vector3(0, Grados, 0);
            transform.eulerAngles = AnguloFinal;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
    public void _ActivarGiro (bool Persigue)
    {
        GiroActivo = Persigue;
      

    }
}
