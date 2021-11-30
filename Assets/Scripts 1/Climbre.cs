using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Climbre : MonoBehaviour
{
    private CharacterController character;
    private ContinuosMovement continuousMovement;

    private List<XRController> climbingHands = new List<XRController>();

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        continuousMovement = GetComponent<ContinuosMovement>();
    }

    private void FixedUpdate()
    {
        foreach (XRController hand in climbingHands)
        {
            if (hand)
            {
                continuousMovement.enabled = false;
                Climb(hand);
            }
        }

        if (climbingHands.Count <= 0)
        {
            continuousMovement.enabled = true;
        }
    }

    public void SelectEntered(SelectEnterEventArgs args)
    {
        if (args.interactor is XRDirectInteractor)
            climbingHands.Add(args.interactor.GetComponent<XRController>());
    }

    public void SelectExited(SelectExitEventArgs args)
    {
        if (args.interactor is XRDirectInteractor)
        {
            var hand = climbingHands.Find(x => x.name == args.interactor.name);

            if (hand)
            {
                climbingHands.Remove(hand);
            }
        }
    }

    void Climb(XRController hand)
    {
        InputDevices.GetDeviceAtXRNode(hand.controllerNode).TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity);

        character.Move(transform.rotation * -velocity * Time.fixedDeltaTime);
    }
}
