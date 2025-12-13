    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

public class Platform : MonoBehaviour
{
    public const float Speed = 2f;
    public const float Distance = 5f;

    private bool isRunning = false;
    private bool goingLeft = true;

    public Vector3 platformDelta { get; private set; }
private Vector3 lastPos;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        Debug.Log("Here");
        lastPos = startPos;

    }

    void Update()
    {
        if (!isRunning) {
            return;
        }

        var direction = goingLeft ? -1f : 1f;
        var move = Vector3.right * direction * Speed * Time.deltaTime;
        transform.Translate(move);

        if (goingLeft && transform.position.z > startPos.z + Distance)
        {
            goingLeft = false;
        }
        else if (!goingLeft && transform.position.z < startPos.z)
        {
            isRunning = false;
        }
    }

    void LateUpdate()
    {
        platformDelta = transform.position - lastPos;
        lastPos = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);

        if (other.CompareTag("Player"))
        {
            var cc = other.GetComponent<CharacterController>();
            cc?.Move(platformDelta);

            isRunning = true;
            goingLeft = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player opuścił platformę");

        }
    }
}
