using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static int score = 0;
    public Text scoreText;
    float delay = .5f;
    float time;
    Path path;
    public int highScore;
    public Text highScoreText;  


    void Start()
    {
        path = GetComponent<Path>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        time = time + 1f *Time.deltaTime;

        if (time >= delay)
        {
            time = 0f;
            score += 1;
        }

        highScore = score;
        highScoreText.text = " " + highScore;
    }

    

}
