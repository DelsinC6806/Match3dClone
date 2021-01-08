using UnityEngine;
public class ButtonsScript : MonoBehaviour
{
    public GameObject pauseMenu;

    public void onPauseButton()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void onCloseButton()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
    }
}
