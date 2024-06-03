using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AircraftController : MonoBehaviour
{
    public bool throttle => Input.GetKey(KeyCode.LeftShift);

    public float pitchPower, rollPower, yawPower, enginePower;

    private float activeRoll, activePitch, activeYaw;

    private float activePitchPower, activeYawPower;

    void Start()
    {
        // Hide and lock the cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        // Toggle cursor visibility and lock state when pressing the Escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.visible)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
    private void FixedUpdate()
    {
        // Apply forward movement with appropriate throttle
        float currentEnginePower = throttle ? enginePower : enginePower / 2;
        transform.position += transform.forward * currentEnginePower * Time.fixedDeltaTime;

        // Handle pitch and roll based on throttle
        if (throttle)
        {
            activePitch = Input.GetAxisRaw("Vertical") * pitchPower * Time.fixedDeltaTime;
            activeRoll = Input.GetAxisRaw("Horizontal") * rollPower * Time.fixedDeltaTime;
        }
        else
        {
            activePitch = Input.GetAxisRaw("Vertical") * (pitchPower / 2) * Time.fixedDeltaTime;
            activeRoll = Input.GetAxisRaw("Horizontal") * (rollPower / 2) * Time.fixedDeltaTime;
        }

        // Handle yaw based on mouse clicks
        if (Input.GetMouseButton(0)) // Left click
        {
            activeYaw = -yawPower * Time.fixedDeltaTime;
        }
        else if (Input.GetMouseButton(1)) // Right click
        {
            activeYaw = yawPower * Time.fixedDeltaTime;
        }
        else
        {
            activeYaw = 0;
        }

        // Apply rotations
        transform.Rotate(activePitch * pitchPower * Time.fixedDeltaTime,
                         activeYaw * yawPower * Time.fixedDeltaTime,
                         -activeRoll * rollPower * Time.fixedDeltaTime,
                         Space.Self);
    }
}