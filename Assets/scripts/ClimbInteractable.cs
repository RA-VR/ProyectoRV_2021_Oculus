using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ClimbInteractable : XRBaseInteractable
{
    // Start is called before the first frame update
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        if (args.interactor is XRDirectInteractor)
        {
            Debug.Log("Entrando");
            Climber.climbingHand = args.interactor.GetComponent<XRController>();
        }
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        Debug.Log("Saliendo111111");


        if (Climber.climbingHand && Climber.climbingHand.name == args.interactor.name)
        {
            Debug.Log("Saliendo22222222");

            Climber.climbingHand = null;
        }
    }
}
