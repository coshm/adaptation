using UnityEngine;
using System.Collections;
using System;

public class ObjectHandler : MonoBehaviour {

    private const float MAX_REACH = 1.5f;

    private const int LEFT_MOUSE_BUTTON = 0;
    private const float MAX_DURATION = 3f;
    private const float MAX_VELOCITY = 20f;

    private const float DEFAULT_Y = -0.4f;
    private const float DEFAULT_Z = 0.6f;
    private const float Y_TO_ANGLE_RATIO = 1f / 900f;

    private Ball ball;
    private DateTime? mouseDownTime;
    private Transform cameraTransform;

    void Start() {
        cameraTransform = transform.Find("MainCamera");
    } 

    public void PickUpBall(Ball newBall) {
        if (ball == null) {
            float distance = (transform.position - newBall.transform.position).magnitude;
            if (distance <= MAX_REACH) {
                ball = newBall;
                ball.TogglePhysics(false);
                ball.AttachBallTo(cameraTransform);
                ball.SetPosition(GetAdjustedBallPosition());
            }
        }
    }

    public void Throw(double throwDuration) {
        float velocityMag = (Mathf.Min((float)throwDuration, MAX_DURATION) / MAX_DURATION) * MAX_VELOCITY;
        Vector3 velocity = velocityMag * cameraTransform.forward;
        ball.SetVelocity(velocity);
        ball.TogglePhysics(true);
        ball.AttachBallTo(null);
        ball = null;
    }

    void Update() {
        if (ball != null) {
            ball.SetPosition(GetAdjustedBallPosition());
            if (Input.GetMouseButtonDown(LEFT_MOUSE_BUTTON) && !mouseDownTime.HasValue) {
                mouseDownTime = DateTime.Now;
            }
            if (Input.GetMouseButtonUp(LEFT_MOUSE_BUTTON) && mouseDownTime.HasValue) {
                TimeSpan duration = DateTime.Now - mouseDownTime.Value;
                Throw(duration.TotalSeconds);
                mouseDownTime = null;
            }
        }

    }

    private Vector3 GetAdjustedBallPosition() {
        float y = cameraTransform.localRotation.x * Y_TO_ANGLE_RATIO + DEFAULT_Y;
        return new Vector3(0, y, DEFAULT_Z);
    }
}
