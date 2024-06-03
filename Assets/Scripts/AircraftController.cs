using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AircraftController : MonoBehaviour
{
    public bool throttle => Input.GetKey(KeyCode.Space);
    public float pitchPower, rollPower, yawPower, enginePower;

    private float activeRoll, activePitch, activeYaw;

    private void Update()
    {
        // Apply forward movement with appropriate throttle
        float currentEnginePower = throttle ? enginePower : enginePower / 2;
        transform.position += transform.forward * currentEnginePower * Time.deltaTime;

        // Handle pitch and roll based on throttle
        if (throttle)
        {
            activePitch = Input.GetAxisRaw("Vertical") * pitchPower * Time.deltaTime;
            activeRoll = Input.GetAxisRaw("Horizontal") * rollPower * Time.deltaTime;
        }
        else
        {
            activePitch = Input.GetAxisRaw("Vertical") * (pitchPower / 2) * Time.deltaTime;
            activeRoll = Input.GetAxisRaw("Horizontal") * (rollPower / 2) * Time.deltaTime;
        }

        // Handle yaw based on mouse clicks
        if (Input.GetMouseButton(0)) // Left click
        {
            activeYaw = -yawPower * Time.deltaTime;
        }
        else if (Input.GetMouseButton(1)) // Right click
        {
            activeYaw = yawPower * Time.deltaTime;
        }
        else
        {
            activeYaw = 0;
        }

        // Apply rotations
        transform.Rotate(activePitch * pitchPower * Time.deltaTime,
                         activeYaw * yawPower * Time.deltaTime,
                         -activeRoll * rollPower * Time.deltaTime,
                         Space.Self);
    }
}
