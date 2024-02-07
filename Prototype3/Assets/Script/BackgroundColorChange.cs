using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorChange : MonoBehaviour
{
    Color black = Color.black;

    Camera cm;
    CountDown m_manager;
    Escapee m_player;

    private Color currColor;

    void Start()
    {
        cm = GetComponent<Camera>();
        m_manager = GameObject.FindGameObjectWithTag("Timer").GetComponent<CountDown>();
        currColor = cm.backgroundColor;
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Escapee>();
    }

    void Update()
    {

    }

    public void LightOff()
    {
        cm.backgroundColor = black;
        m_player.ChangeColorWhenLightOff();
    }

    public void LightOn()
    {
        cm.backgroundColor = currColor;
        m_player.ChangeColorWhenLightOn();
    }
}
