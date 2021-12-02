 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;


// [RequireComponent(typeof(Animator))]
public class Hand : MonoBehaviour
{
    // Animator animator;
    // SkinnedMeshRenderer mesh; 
    // private float gripTarget;
    // private float triggerTarget;
    // private float gripCurrent;
    // private float triggerCurrent;
    // private string animatorGripParam = "Grip";
    // private string animatorTriggerParam = "Trigger";
    // private static readonly int Grip = Animator.stringToHash(name:AnimatorGripParam);
    // private static readonly int Trigger = Animator.stringToHash(name:AnimatorTriggerParam);

    // Physics Movement
    [Space]
    [SerializeField] private ActionBasedController controller;
    [SerializeField] private float followSpeed = 30f;
    [SerializeField] private float rotateSpeed = 100f;
    [Space]
    [SerializeField] private Vector3 positionOffset; 
    [SerializeField] private Vector3 rotationOffset;
    [Space]
    [SerializeField] private Transform palm;
    [SerializeField] float reachDistance = 0.1f, joinDistance = 0.05f;
    [SerializeField] private LayerMask grabbableLayer;

    private Transform _followTarget;
    private Rigidbody _body;

    private bool _isGrabbing;
    private GameObject _heldObject;
    private Transform _grabPoint;
    private FixedJoint _joint1, _joint2; 


    // Start is called before the first frame update
    void Start()
    {
        // Physics Movement 
        _followTarget = controller.gameObject.transform;
        _body = GetComponent<Rigidbody>();
        _body.collisionDetectionMode = CollisionDetectionMode.Continuous;
        _body.interpolation = RigidbodyInterpolation.Interpolate; 
        _body.mass = 20f;
        _body.maxAngularVelocity = 20f;

        // Inputs Setup
        controller.selectAction.action.started += Grab;
        controller.selectAction.action.canceled += Release;

        // Teleport Hands 
        _body.position = _followTarget.position;
        _body.rotation = _followTarget.rotation;
        // animator = GetComponent<Animator>();
        // mesh = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        PhySicsMove();
        // AnimateHand();
    }

    private void PhySicsMove(){
        // Position
        var positionWithOffset = _followTarget.TransformPoint(positionOffset);
        var distance = Vector3.Distance(positionWithOffset, transform.position);
        _body.velocity = (positionWithOffset - transform.position).normalized * (followSpeed * distance);
        
        // Rotation
        var rotationWithOffset = _followTarget.rotation * Quaternion.Euler(rotationOffset);
        var q = rotationWithOffset * Quaternion.Inverse(_body.rotation);
        q.ToAngleAxis(out float angle, out Vector3 axis);
        _body.angularVelocity = axis * (angle * Mathf.Deg2Rad * rotateSpeed);
    }

    private void Grab(InputAction.CallbackContext context)
    {
        if(_isGrabbing || (bool)_heldObject) return;

        Collider[] grabbableColliders = Physics.OverlapSphere(palm.position, reachDistance, (int)grabbableLayer);
        if (grabbableColliders.Length < 1) return;

        var objectToGrab = grabbableColliders[0].transform.gameObject;

        var objectBody = objectToGrab.GetComponent<Rigidbody>();

        if(objectBody != null){
            _heldObject = objectBody.gameObject;
        }
        else
        {
            objectBody = objectToGrab.GetComponentInParent<Rigidbody>();
            if(objectBody != null)
            {
                _heldObject = objectBody.gameObject;
            }
            else
            {
                return;
            }
        }
        StartCoroutine(GrabObject(grabbableColliders[0], objectBody));
    }

    private IEnumerator GrabObject(Collider collider, Rigidbody targetBody) {

        _isGrabbing = true;

        // Create a grab point 
        _grabPoint = new GameObject().transform;
        _grabPoint.position = collider.ClosestPoint(palm.position);
        _grabPoint.parent = _heldObject.transform;
        // Move hand to grab point 
        _followTarget = _grabPoint;
        // Wait for hand to reach grab point
        while (_grabPoint != null && Vector3.Distance(_grabPoint.position, palm.position) > joinDistance && _isGrabbing)
        {
            yield return new WaitForEndOfFrame();
        }
        // Freeze hand and object motion 
        _body.velocity = Vector3.zero;
        _body.angularVelocity = Vector3.zero;
        targetBody.velocity = Vector3.zero;
        targetBody.angularVelocity = Vector3.zero;

        targetBody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        targetBody.interpolation = RigidbodyInterpolation.Interpolate;

        // Attach joints
        _joint1 = gameObject.AddComponent<FixedJoint>();
        _joint1.connectedBody = targetBody;
        _joint1.breakForce = float.PositiveInfinity;
        _joint1.breakTorque = float.PositiveInfinity;

        _joint1.connectedMassScale = 1; 
        _joint1.massScale = 1;
        _joint1.enableCollision = false;
        _joint1.enablePreprocessing = false;

        _joint2 = gameObject.AddComponent<FixedJoint>();
        _joint2.connectedBody = targetBody;
        _joint2.breakForce = float.PositiveInfinity;
        _joint2.breakTorque = float.PositiveInfinity;

        _joint2.connectedMassScale = 1; 
        _joint2.massScale = 1;
        _joint2.enableCollision = false;
        _joint2.enablePreprocessing = false;

        // Reset follow target
        _followTarget = controller.gameObject.transform;
    }

    private void Release(InputAction.CallbackContext context)
    {
        if (_joint1 != null)
            Destroy(_joint1);
        if (_joint2 != null)
            Destroy(_joint2);
        if (_grabPoint != null)
            Destroy(_grabPoint.gameObject);
        
        if(_heldObject != null)
        {
            var targetBody = _heldObject.GetComponent<Rigidbody>();
            targetBody.collisionDetectionMode = CollisionDetectionMode.Discrete;
            targetBody.interpolation = RigidbodyInterpolation.None;
            _heldObject = null; 
        }

        _isGrabbing = false;
        _followTarget = controller.gameObject.transform;

        
    }

    // internal void SetGrip(float v)
    // {
    //     gripTarget = v; 
    // }

    // internal void SetTrigger(float v)
    // {
    //     triggerTarget = v;
    // }

    // void AnimateHand(){
    //     if (gripCurrent != gripTarget){
    //         gripCurrent = Mathf.MoveTowards(gripCurrent, gripCurrent, Time.deltaTime * speed);
    //         animator.setFloat(animatorGripParam, gripCurrent);
    //     }
    //     if (triggerCurrent != gripTarget){
    //         triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerCurrent, Time.deltaTime * speed);
    //         animator.setFloat(animatorTriggerParam, triggerCurrent);
    //     }
    // }

    // public void ToggleVisibility() 
    // {
    //     mesh.enabled = !mesh.enabled;
    // }
}
