using UnityEngine.UI;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public Text timerText;
    float second;
    int minute;
   
    void Start()
    {
        minute = 10;
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
            //GameOver
        }
    }

    void DisplayCurrentTime()
    {
        string min = minute.ToString("00");
        string sec = second.ToString("00");
        timerText.text = min + ":" + sec;
    }
}
