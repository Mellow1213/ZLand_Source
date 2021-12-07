using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    public float spawnTime;
    float timer;
    public GameObject zombiePrefab;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        if (spawnTime == 0)
            spawnTime = 20;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawnTime)
        {
            timer = 0;
            Instantiate(zombiePrefab, transform.position, Quaternion.identity);
        }

    }
}
