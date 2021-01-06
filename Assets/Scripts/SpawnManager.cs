using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject PowerUp;
    public float spawnRange = 8;
    private int level = 1;
    // Start is called before the first frame update
    void Start()
    {
        // InvokeRepeating("Spawn", 1f, 4f);

       Spawn(level++);
    }

    // Update is called once per frame
    void Update()
    {
        int enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount <= 0) Spawn(level++); 
    }

    void Spawn(int enemyCount)
    {
        Instantiate(PowerUp, SpawnPosition(), PowerUp.transform.rotation); ;
        for (int i = 0; i < enemyCount; i++)
        {
            Instantiate(Enemy, SpawnPosition(), Enemy.transform.rotation); 
        }
        
    }

    Vector3 SpawnPosition()
    {
        var x = Random.Range(-spawnRange, spawnRange);
        var z = Random.Range(-spawnRange, spawnRange);

        return new Vector3(x, 0, z);

    }

}
