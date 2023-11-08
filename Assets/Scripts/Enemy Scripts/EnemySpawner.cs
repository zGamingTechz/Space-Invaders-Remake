using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform enemy_spawner2;
    float nextEnemy = Random.Range(2, 8);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nextEnemy -= Time.deltaTime;

        if (nextEnemy < 0)
        {
            nextEnemy = Random.Range(3, 11); ;
            float random_for_spawn = Random.Range(0, 21);

            if (random_for_spawn < 11)
            {
                Instantiate(enemyPrefab, enemy_spawner2.position, Quaternion.identity);
            }
        }
    }
}
