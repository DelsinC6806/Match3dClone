using UnityEngine.UI;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public Text scoreText;
    int score;
    void Start()
    {
        score = 0;
    }

    void Update()
    {
        displayCurrentScore();
    }

    void addScore()
    {
        //add Score when match is correct
    }

    void displayCurrentScore()
    {
        scoreText.text = score.ToString();
    }
}
