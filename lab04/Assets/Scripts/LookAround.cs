using UnityEngine;
using UnityEngine.InputSystem;

public class LookAround : MonoBehaviour
{
    public Transform player;
    public InputAction lookAction;
    public float sens = 50f;
    private float xRotation = 0f;

    void OnEnable()
    {
        lookAction.Enable();
    }

    void OnDisable()
    {
        lookAction.Disable();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        var look = lookAction.ReadValue<Vector2>();
        var localRotation = Quaternion.Euler(Mathf.Clamp(xRotation, -90f, 90f), 0f, 0f);

        transform.localRotation = localRotation;
        player.Rotate(Vector3.up * look.x * sens * Time.deltaTime);
    }
}
