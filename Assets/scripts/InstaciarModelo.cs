using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaciarModelo : MonoBehaviour
{
    public GameObject Prefat;
    public void InstacarPrefat()
    {
        Instantiate(Prefat);   
    }   
}
