using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public float maxYpos, minYpos;
    public float spawnTime;
    public GameObject pipe;

    // Start is called before the first frame update
    void Start()
    {
        //StartSpawningPipes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void stopSpawningPipes()
    {
        CancelInvoke("SpawnPipe");
    }

    public void StartSpawningPipes()
    {
        InvokeRepeating("SpawnPipe", 0.2f, spawnTime);
    }

    void SpawnPipe()
    {
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(minYpos, maxYpos), 0), Quaternion.identity);
    }

    
}
