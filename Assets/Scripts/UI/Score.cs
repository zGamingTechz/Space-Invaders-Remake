using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject player;
    PlayerRespawn score_script;
    public Text score_text;
    int lives1;

    private void Start()
    {
        score_script = player.GetComponent<PlayerRespawn>();
    }

    // Update is called once per frame
    void Update()
    {
        lives1 = score_script.lives;
        score_text.text = "Lives: " + lives1.ToString();

        
    }
}
