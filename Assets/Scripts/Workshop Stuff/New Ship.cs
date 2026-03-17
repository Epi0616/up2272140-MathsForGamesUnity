using UnityEngine;
using UnityEngine.InputSystem;

public class NewShip : MonoBehaviour

{

    [Header("Tuning")]

    public float moveSpeed = 5f; // units/sec

    public float lookSensitivity = 0.15f; // degrees per mouse delta unit

    public float pitchClamp = 80f; // degrees

    private MyVector3 Up = MyVector3.up;

    // Input values set by PlayerInput (Send Messages)

    private Vector2 moveInput; // x=strafe, y=forward

    private Vector2 lookInput; // mouse delta


    // We store angles in degrees for easier tuning/clamping

    private float yawDeg;

    private float pitchDeg;


    // Called automatically by PlayerInput for action "Move"

    public void OnMove(InputValue value)

    {

        moveInput = value.Get<Vector2>();

    }


    // Called automatically by PlayerInput for action "Look"

    public void OnLook(InputValue value)

    {

        lookInput = value.Get<Vector2>();

    }


    private void Update()

    {

        // TODO (Part B): Implement using the steps below in the workshop.

        // Leave everything else in this file unchanged.

        yawDeg += lookInput.x * lookSensitivity;

        pitchDeg += lookInput.y * lookSensitivity;

        pitchDeg = Mathf.Clamp(pitchDeg, -pitchClamp, pitchClamp);

        //Now we�ll use our MFGCore library for movement before our last line is:
        transform.rotation = Quaternion.Euler(pitchDeg, yawDeg, 0f);

        float yawRad = SFMathsCore.DegreesToRadians(yawDeg);
        float pitchRad = SFMathsCore.DegreesToRadians(pitchDeg);

        MyVector3 forwardVector = SFMathsCore.ForwardFromYawPitchUnity(yawRad, pitchRad);

        MyVector3 rightVector = SFMathsCore.CrossProduct(Up, forwardVector);

        //Up = SFMathsCore.CrossProduct(rightVector, forwardVector);

        MyVector3 movementDirection = SFMathsCore.Scale(forwardVector, moveInput.y) + SFMathsCore.Scale(rightVector, moveInput.x);

        MyVector3 movementChange = SFMathsCore.MoveStep(movementDirection, moveSpeed);

        Vector3 convertedVector = SFMathsCore.MyVector3ToVector3(movementChange);

        transform.position += convertedVector;

        

    }

}
