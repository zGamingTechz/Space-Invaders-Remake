using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActualScore : MonoBehaviour
{
    public static int score = 0;
    public static int scoreForChangingBullets = 0;
    public Text scoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreForChangingBullets = score;
        scoreBoard.text = "Score: " + score.ToString();
    }
}
