using UnityEngine;

public class Script2 : MonoBehaviour
{
    public float speed = 2f;

    private float startingX;
    private bool invertDirection = false;
    private const int distanceToCover = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.startingX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        var course = invertDirection ? -speed : speed;
        this.transform.Translate(Vector3.right * course * Time.deltaTime);

        var distanceCovered = this.GetDistanceCovered();

        if (distanceCovered > distanceToCover)
        {
            this.invertDirection = true;
        }

        if (distanceCovered < 0)
        {
            this.invertDirection = false;
        }
    }

    private float GetDistanceCovered()
    {
        return this.transform.position.x - this.startingX;
    }
}
