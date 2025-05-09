using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float currentTime = 0f;
    public bool isCounting = true;

    public TextMeshProUGUI timerText;

    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            currentTime = 0;
            isCounting = false;
            GameManager.Instance.GameOver(); // Call GameOver method when time runs out
        }
        UpdateTimerDisplay();
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StopTimer()
    {
        isCounting = false;
    }

    public void StartTimer()
    {
        isCounting = true;
    }

    public void ResetTimer()
    {
        currentTime = 0f;
        UpdateTimerDisplay();
    }
}
