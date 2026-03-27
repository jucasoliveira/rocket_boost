using UnityEngine;
using UnityEngine.InputSystem;

public class Movements : MonoBehaviour
{

    [SerializeField] InputAction thrust;
    [SerializeField] float thrustForce = 20f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        thrust.Enable();
    }

    private void FixedUpdate()
    {
        if (thrust.IsPressed())
        {
            // add force of 10 upwards
            rb.AddForce(Vector3.up * thrustForce * Time.fixedDeltaTime, ForceMode.Impulse);
            Debug.Log("Thrusting");
        }
    }


    private void OnDisable()
    {
        thrust.Disable();
    }
}
