using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDown : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public float countdownDuration = 5f;

    private float currentTime = 0f;
    private bool countdownStarted = false;

    void Start()
    {
        currentTime = countdownDuration;
        UpdateTimerText();
        countdownStarted = true;
    }

    void Update()
    {
        if (countdownStarted)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                currentTime = 0;
                countdownStarted = false;
            }

            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
        int seconds = Mathf.CeilToInt(currentTime);
        countdownText.text = seconds.ToString();
    }

    public void StartCountdown()
    {
        countdownStarted = true;
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }
}
