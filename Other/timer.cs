using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public TextMeshProUGUI TimerText;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        int hundredths = Mathf.FloorToInt((timer * 100) % 100);

        TimerText.text = "TIME: "+ $"{minutes:00}:{seconds:00}.{hundredths:00}";
    }
    public void ResetTimer()
    {
        timer = 0f;
    }
}
