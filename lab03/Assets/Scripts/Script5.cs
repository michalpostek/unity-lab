using UnityEngine;
using System.Collections.Generic;

public class Script5 : MonoBehaviour
{
    public GameObject cubePrefab;
    public int cubeCount = 10;
    public Vector3 planePosition;
    public float planeSize = 10f;

    private List<Vector2> takenPositions = new List<Vector2>();

    void Start()
    {
        for (int i = 0; i < cubeCount; i++)
        {
            var next = GetRandomPosition();

            if (next != Vector3.zero)
            {
                Instantiate(cubePrefab, next, Quaternion.identity);
            }
        }
    }

    private Vector3 GetRandomPosition()
    {
        while (true)
        {
            var x = Random.Range(-planeSize / 2f, planeSize / 2f);
            var z = Random.Range(-planeSize / 2f, planeSize / 2f);
            var pos2D = new Vector2(Mathf.Round(x), Mathf.Round(z));

            if (!takenPositions.Contains(pos2D))
            {
                takenPositions.Add(pos2D);

                return new Vector3(
                    planePosition.x + pos2D.x,
                    planePosition.y + 0.5f,
                    planePosition.z + pos2D.y
                );
            }
        }
    }
}