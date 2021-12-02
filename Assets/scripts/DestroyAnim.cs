using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAnim : MonoBehaviour
{
    public GameObject destruir1;
    public GameObject destruir2;
    [SerializeField] private Animator miAnimacion;
    [SerializeField] private string puertaabrir = "puertaabrir";
    [SerializeField] private string puertacerrada = "puertacerrada";
    private void OnTriggerEnter(Collider other)

    {

        if (other.CompareTag("Player"))
        {
            Destroy(destruir1, 0.1f);

        }

        if (other.CompareTag("Player"))
        {
            Destroy(destruir2, 3f);
        }


        if (other.CompareTag("Player"))
        {
            miAnimacion.Play(puertaabrir, 0, 0.0f);
        }
    }

    private void OnTriggerExit(Collider other)

    {

        if (other.CompareTag("Player"))
        {
            miAnimacion.Play(puertacerrada, 0, 0.0f);
        }
    }
}
