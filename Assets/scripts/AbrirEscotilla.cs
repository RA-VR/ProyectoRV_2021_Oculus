using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirEscotilla : MonoBehaviour
{
    public GameObject Escotilla;
    public float TiempoDeEspera;
    public void _AbrirEscotilla()
    {
        if (Escotilla.GetComponent<Animator>()) { Escotilla.GetComponent<Animator>().Play("Abrir"); }
        else { Escotilla.SetActive(false); }
        StartCoroutine(CerrarEscotilla());
    }

    IEnumerator CerrarEscotilla()
    {
        yield return new WaitForSeconds(TiempoDeEspera);
        if (Escotilla.GetComponent<Animator>()) { Escotilla.GetComponent<Animator>().Play("Cerrar"); }
        else { Escotilla.SetActive(true); }
    }
}
