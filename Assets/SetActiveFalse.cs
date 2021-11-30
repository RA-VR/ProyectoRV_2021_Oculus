using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveFalse : MonoBehaviour
{
    public float TiempoEnQueDesapareceGmeObject;
    void Start()
    {
        StartCoroutine(_SetActiveFalse());
    }

 IEnumerator _SetActiveFalse()
    {
        yield return new WaitForSeconds(TiempoEnQueDesapareceGmeObject);
        gameObject.SetActive(false);
    }
}
