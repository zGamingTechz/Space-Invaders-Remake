using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject playerPrefab;
    GameObject playerInstance;
    float respawnTimer;
    public int lives = 4;
    public int dummyLives = 4;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInstance == null)
        {

            respawnTimer -= Time.deltaTime;

            if (respawnTimer <= 0)
            {
                SpawnPlayer();
            }
        }
    }

    void SpawnPlayer()
    {
        dummyLives--;
        respawnTimer = 1f;
        if (lives > 0)
        {
            lives--;
            playerInstance = (GameObject)Instantiate(playerPrefab);
            playerInstance.name = "Player";
        }
    }

}
