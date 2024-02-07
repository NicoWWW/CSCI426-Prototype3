using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.InteropServices.WindowsRuntime;

public class CountDown : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public float countdownDuration = 5f;

    private float currentTime = 0f;
    private bool countdownStarted = false;

    private bool canCode = true;

    Escapee m_player;

    void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Escapee>();
    }

    void Update()
    {

        if (currentTime < 0f)
        {
            currentTime = 0f;
        }

        //Debug.Log(countdownStarted);

        else if (!m_player.GetIsProcess() && currentTime == 0.0f && countdownStarted) // Time's up, Light off
        {
            Debug.Log("Light off. Can not code. Player Move.");
            canCode = false;
            countdownStarted = false;
        }

        /*
        Debug.Log(m_player.GetIfCaught().ToString());
        Debug.Log(currentTime);
        */
        //Debug.Log(canCode);

        //*/

        if (!m_player.GetIfCaught() && currentTime == 0.0f && canCode && !m_player.GetIsProcess()) // Light On
        {
            Debug.Log("Light On. Can code. Player should not move.");
            StartCoroutine(StartCountdown());
        }

    }

    void UpdateTimerText()
    {
        int seconds = Mathf.CeilToInt(currentTime);
        countdownText.text = seconds.ToString();
    }

    public IEnumerator StartCountdown()
    {
        currentTime = countdownDuration;

        canCode = true;
        countdownStarted = true;

        // Loop until countdownValue becomes 0
        while (currentTime >= 0)
        {
            UpdateTimerText();

            // Wait for one second
            yield return new WaitForSeconds(1);

            // Decrease the countdown value
            currentTime--;
        }
    }

    private IEnumerator Wait(float time)
    {
        float timer = time;

        // Loop until countdownValue becomes 0
        while (timer >= 0)
        {
            // Wait for one second
            yield return new WaitForSeconds(1);

            // Decrease the countdown value
            timer--;
        }
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }

    public bool GetCanCode()
    {
        return canCode;
    }

    public void SetCanCode()
    {
        canCode = true;
    }
}
