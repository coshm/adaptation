using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    private Rigidbody ballRigidbody;
    private SphereCollider ballCollider;

    private ObjectHandler objHandler;

    void Awake() {
        ballRigidbody = GetComponent<Rigidbody>();
        ballCollider = GetComponent<SphereCollider>();
    }

    void Start() {
        objHandler = GameObject.Find("RigidBodyFPSController").GetComponent<ObjectHandler>();
    }

    void OnMouseUpAsButton() {
        Debug.Log("Clicked on ball.");
        objHandler.PickUpBall(this);
    }

    public void TogglePhysics(bool enabled) {
        ToggleIsKinematic(enabled ? false : true);
        ToggleCollider(enabled ? true : false);
    }

    public void ToggleIsKinematic(bool enabled) {
        ballRigidbody.isKinematic = enabled;
    }

    public void ToggleCollider(bool enabled) {
        ballCollider.enabled = enabled;
    }

    public void SetPosition(Vector3 position) {
        transform.localPosition = position;
    }

    public void AttachBallTo(Transform parent) {
        transform.parent = parent;
    }

    public void SetVelocity(Vector3 velocity) {
        ballRigidbody.velocity = velocity;
    }
}
