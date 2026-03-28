using UnityEngine;
using UnityEngine.InputSystem;

public class Movements : MonoBehaviour
{

    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotate;
    [SerializeField] float thrustForce = 20f;
    [SerializeField] float rotateSpeed = 20f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        thrust.Enable();
        rotate.Enable();
    }

    private void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
    }


    private void ProcessThrust()
    {
        if (thrust.IsPressed())
        {
            rb.AddForce(transform.up * thrustForce * Time.fixedDeltaTime, ForceMode.Impulse);
        }
    }

    private void ProcessRotation()
    {
        float rotationInput = rotate.ReadValue<float>();
        if (rotationInput < 0)
        {
            ApplyRotation(rotateSpeed * Time.fixedDeltaTime);
        }
        else if (rotationInput > 0)
        {
            ApplyRotation(-rotateSpeed * Time.fixedDeltaTime);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        transform.Rotate(Vector3.forward * rotationThisFrame);
    }


    private void OnDisable()
    {
        thrust.Disable();
        rotate.Disable();
    }
}
