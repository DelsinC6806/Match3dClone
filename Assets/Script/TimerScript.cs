using UnityEngine.UI;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public Text timerText;
    float second;
    int minute;
    public GameObject GameOver;
    public Text text;
   
    void Start()
    {
        minute = 1;
    }

    void Update()
    {
        countDown();
        DisplayCurrentTime();
    }

    void countDown()
    {
        second -= Time.deltaTime;
        if(second <= 0 && minute > 0)
        {
            minute -= 1;
            second = 59;
        }else if (second <= 0 && minute <= 0)
        {
            text.text = "Game Over";
            GameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void DisplayCurrentTime()
    {
        string min = minute.ToString("00");
        string sec = second.ToString("00");
        timerText.text = min + ":" + sec;
    }
}
