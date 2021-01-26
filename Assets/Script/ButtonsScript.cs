using UnityEngine;
using UnityEngine.UI;
public class ButtonsScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public Text pauseText;

    public void onPauseButton()
    {
        Time.timeScale = 0;
        pauseText.text = "PAUSED";
        pauseText.color = Color.white;
        pauseMenu.SetActive(true);
    }

    public void onCloseButton()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
    }

    public void onRetryButton()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
