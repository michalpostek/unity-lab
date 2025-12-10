using UnityEngine;

public class Script6 : MonoBehaviour
{
    public Transform target;
    private float interpolation = 0.0f;
    private float interpolationIncreaseFactor = 0.1f;

    public void Update()
    {
        this.interpolation += this.interpolationIncreaseFactor * Time.deltaTime;

        var newPos = new Vector3(
            Mathf.Lerp(transform.position.x, target.position.x, this.interpolation), 
            Mathf.Lerp(transform.position.y, target.position.y, this.interpolation), 
            Mathf.Lerp(transform.position.z, target.position.z, this.interpolation)
        );
        
        transform.position = newPos;
    }
}