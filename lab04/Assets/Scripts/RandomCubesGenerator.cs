using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomCubesGenerator : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = .3f;
    public int objects;
    public Renderer platform;
    int objectCounter = 0;
    // obiekt do generowania
    public GameObject block;

    void Start()
    {
        for (int i = 0; i < objects; i++)
        {
            var x = Random.Range(platform.bounds.min.x, platform.bounds.max.x);
            var z = Random.Range(platform.bounds.min.z, platform.bounds.max.z);

            positions.Add(new Vector3(x, platform.bounds.max.y + 1f, z));
        }

        foreach(Vector3 elem in positions){
            Debug.Log(elem);
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {
        
    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywołano coroutine");
        foreach(Vector3 pos in positions)
        {
            Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}
