using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirSonido : MonoBehaviour
{
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        if(time!=0)
        {
            Destroy(gameObject, time);
        }
        else
        {
            Destroy(gameObject, 2f);
        }
    }


}
