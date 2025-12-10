using UnityEngine;
using UnityEngine.InputSystem;

public class Script4 : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        var x = 0f;
        var z = 0f;

        if (Keyboard.current.aKey.isPressed) x = -1f;
        if (Keyboard.current.dKey.isPressed) x = 1f;
        if (Keyboard.current.wKey.isPressed) z = 1f;
        if (Keyboard.current.sKey.isPressed) z = -1f;

        var move = new Vector3(x, 0f, z) * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);
    }
}