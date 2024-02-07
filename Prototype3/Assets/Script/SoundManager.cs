using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource beep;

    private void Awake()
    {
        beep = GetComponent<AudioSource>();
    }

    public void Beep()
    {
        beep.Play();
    }

    public void StopBeep()
    {
        beep.Stop();
    }
}
