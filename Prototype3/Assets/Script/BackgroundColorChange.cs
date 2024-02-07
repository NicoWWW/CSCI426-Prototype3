using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorChange : MonoBehaviour
{
    Color black = Color.black;

    Camera cm;
    CountDown m_manager;
    Escapee m_player;
    GameObject nightWall;
    GameObject dayWall;

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
        if (!m_manager.GetCanCode()) //  Light off
        {
            cm.backgroundColor = black;
            m_player.ChangeColorWhenLightOff();
        }
        else // Light On
        {
            cm.backgroundColor = currColor;
            m_player.ChangeColorWhenLightOn();
        }

    }
}
