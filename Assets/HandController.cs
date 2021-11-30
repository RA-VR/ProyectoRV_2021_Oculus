using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(ActionBasedController))]

public class HandController : MonoBehaviour
{
    ActionBasedController controller;

    public HandA handA;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<ActionBasedController>();
    }

    // Update is called once per frame
    void Update()
    {
        handA.SetGrip(controller.selectAction.action.ReadValue<float>());
        handA.SetTrigger(controller.activateAction.action.ReadValue<float>());
    }
    
}
