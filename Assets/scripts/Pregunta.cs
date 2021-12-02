using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pregunta : MonoBehaviour
{
    public UnityEvent Correct;
    public UnityEvent Incorrect;
public void Correcta()
    {
        Correct.Invoke();
    }public void Incorrecta()
    {
        Incorrect.Invoke();
    }
}
