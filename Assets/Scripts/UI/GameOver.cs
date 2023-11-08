using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject player;
    PlayerRespawn score_script;
    public Text game_over_text;
    int lives;
    float toMainMenu = 5f;

    private void Start()
    {
        score_script = player.GetComponent<PlayerRespawn>();
    }

    // Update is called once per frame
    void Update()
    {
        lives = score_script.dummyLives;
        
        if (lives < 0)
        {
            game_over_text.text = "Game Over";
            Debug.Log(toMainMenu);
            toMainMenu -= Time.deltaTime;
            if (toMainMenu < 0)
            {
                SceneManager.LoadScene(0);
            }
        }


    }
}
