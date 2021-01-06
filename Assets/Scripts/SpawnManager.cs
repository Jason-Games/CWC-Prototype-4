using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Enemy;
    public float spawnRange = 8;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 1f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {

        
        Instantiate(Enemy, SpawnPosition() , Enemy.transform.rotation);;
    }

    Vector3 SpawnPosition()
    {
        var x = Random.Range(-spawnRange, spawnRange);
        var z = Random.Range(-spawnRange, spawnRange);

        return new Vector3(x, 0, z);

    }

}
