using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BotonesReaccion : MonoBehaviour
{
    public string _tag;
    public UnityEvent Accionar;
    public UnityEvent Salida;

    private void OnTriggerEnter(Collider other)

    {

        if (other.CompareTag(_tag))
        {
            Accionar.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(_tag))
        {
            Salida.Invoke();
        }
    }
    public void _Accionar()
    {
        Accionar.Invoke();
    }
    public void _Salida()
    {
        Salida.Invoke();
    }

}
