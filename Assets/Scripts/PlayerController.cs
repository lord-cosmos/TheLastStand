using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float thrust;
    public float thrust_multiplier;
    public float yaw_multiplier;
    public float pitch_multiplier;
    new Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        float pitch = Input.GetAxis("Vertical");
        float yaw = Input.GetAxis("Horizontal");

        rigidbody.AddRelativeForce(0f, 0f, thrust * thrust_multiplier * Time.deltaTime);
        rigidbody.AddTorque(pitch * pitch_multiplier * Time.deltaTime, yaw * yaw_multiplier * Time.deltaTime, -yaw * yaw_multiplier * 2 * Time.deltaTime);
    }
}