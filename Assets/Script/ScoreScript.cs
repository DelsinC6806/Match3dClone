using UnityEngine.UI;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    #region Singleton
    public static ScoreScript instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
        }
        instance = this;
    }
    #endregion
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

    public void addScore()
    {
        score += (1 * MatchingScript.comboNum);
    }

    void displayCurrentScore()
    {
        scoreText.text = score.ToString();
    }
}
