using UnityEngine.UI;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    public Text levelText;
    public static int level;
    bool levelup = false;

    void Start()
    {
        level = 0;
    }

    void Update()
    {
        DisplayCurrentLevel();
    }

    public void nextLevel()
    {
        if (!levelup)
        {
            level += 1; 
            levelup = true;
        }
    }

    void DisplayCurrentLevel()
    {
        levelText.text = "LEVEL " + level;
    }
}
