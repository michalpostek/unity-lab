using UnityEngine;

public class Script3 : MonoBehaviour
{
    public float speed = 5f;

    private float lastStartingX;
    private float lastStartingZ;

    private const float distanceToCover = 10f;

    void Start()
    {
        this.UpdateLastStartingCoordinates();
    }

    void Update()
    {
        if (this.GetDistanceCovered() > distanceToCover) {
            this.UpdateLastStartingCoordinates();
            transform.Rotate(0f, -90f, 0f, Space.Self);
        }

        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private float GetDistanceCovered() {
        return Mathf.Abs(this.lastStartingX - this.transform.position.x) + Mathf.Abs(this.lastStartingZ - this.transform.position.z);
    }

    private void UpdateLastStartingCoordinates() {
        this.lastStartingX = transform.position.x;
        this.lastStartingZ = transform.position.z;
    }
}
