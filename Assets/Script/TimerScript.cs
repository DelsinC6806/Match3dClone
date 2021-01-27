using UnityEngine.UI;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public Text timerText;
    float second;
    public static int minute;
    public GameObject GameOver;
    public Text text;
   
    void Start()
    {
        minute = 1;
        Time.timeScale = 1;
    }

    void Update()
    {
        countDown();
        DisplayCurrentTime();
    }

    void countDown()
    {
        
        if(second <= 0 && minute > 0)
        {
            minute -= 1;
            second = 59;
        }else if (second <= 0 && minute <= 0)
        {
            text.text = "GAMEOVER";
            text.color = Color.red;
            GameOver.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            second -= Time.deltaTime;
        }
    }

    void DisplayCurrentTime()
    {
        string min = minute.ToString("00");
        string sec = second.ToString("00");
        timerText.text = min + ":" + sec;
    }
}
