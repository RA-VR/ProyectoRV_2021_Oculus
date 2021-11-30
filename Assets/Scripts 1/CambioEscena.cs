using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public string scen;
    public string EscenaViajePorTiempo;
    //public string des;

    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Player"))
        //{
        //    SceneManager.UnloadSceneAsync(des);
        //}
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadSceneAsync(scen);
        }
    }

    public void _CambioDeEscenaPorTiempo( float TiempoParaViajar)
    {
        StartCoroutine(_CambioDeEscena(EscenaViajePorTiempo, TiempoParaViajar));
    }
    IEnumerator _CambioDeEscena (string EscenaViaje, float TiempoParaViajar)
    {
        yield return new WaitForSeconds(TiempoParaViajar);
        SceneManager.LoadScene(EscenaViaje);
    }

}