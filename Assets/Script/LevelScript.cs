using UnityEngine.UI;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    public Text levelText;
    int level;
    bool levelup = false;

    void Start()
    {
        level = 1;
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
