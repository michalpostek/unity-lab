using UnityEngine;

public class Script6b : MonoBehaviour
{
    public Transform target;
    private float xVelocity = 0.01f;
    private float yVelocity = 0.01f;
    private float zVelocity = 0.01f;

    public void Update()
    {
        var newPos = new Vector3(
            Mathf.SmoothDamp(transform.position.x, target.position.x, ref xVelocity, 0.5f),
            Mathf.SmoothDamp(transform.position.y, target.position.y, ref yVelocity, 0.5f),
            Mathf.SmoothDamp(transform.position.z, target.position.z, ref zVelocity, 0.5f)
        );

        this.transform.position = newPos;
    }
}