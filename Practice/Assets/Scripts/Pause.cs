using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool isActive = false;
    [SerializeField] private GameObject pauseMenu;

    private void PauseOn()
    {
        Time.timeScale = 0f;
        isActive = true;
        pauseMenu.SetActive(true);
    }

    void PauseOff()
    {
        Time.timeScale = 1f;
        isActive = false;
        pauseMenu.SetActive(false);
    }

    void TooglePause()
    {
        Debug.Log(isActive);
        if(!isActive)
        {
            PauseOn();
        }
        else if(isActive)
        {
            PauseOff();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            TooglePause();
        }
    }
}
