using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float levelTime = 0f;
    private bool isRunning = true;
    [SerializeField] GameObject WinMenu;
    SceneLoader sceneLoader;

    private void Awake()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    void Update()
    {
        if (!isRunning || Pause.isActive) return;

        levelTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(levelTime / 60f);
        int seconds = Mathf.FloorToInt(levelTime % 60f);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void Win()
    {
        WinMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Lose()
    {
        sceneLoader.Restart();
    }
}
