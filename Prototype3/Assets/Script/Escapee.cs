using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static Escapee;

public class Escapee : MonoBehaviour
{
    CodeReception m_reception;
    Rigidbody2D rb;
    CountDown timer;
    playerK m_player;

    private bool isProcessing = false;
    private float movingVelocity = 2.0f;
    private bool isCaught = false;
    private Color initialColor;

    public class CodeInput
    {
        public List<int> m_codeList;
    }

    CodeInput input = new CodeInput();

    // Start is called before the first frame update
    void Start()
    {
        m_reception = this.gameObject.GetComponent<CodeReception>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<CountDown>();
        input.m_codeList = new List<int>();
        m_player = GetComponent<playerK>();
    }

    // Update is called once per frame
    void Update()
    {
        input = m_reception.GetInput();

        if (!isCaught)
        {
            if (!timer.GetCanCode())
            {
                Debug.Log("Player starts moving.");
                isProcessing = true;
                CodeProcess();
            }
        }
        else
        {

        }


    }

    private void CodeProcess()
    {
        if (input.m_codeList.Count > 0 && isProcessing)
        {
            for (int i = 0; i < input.m_codeList.Count; i += 2)
            {
                if (i + 1 < input.m_codeList.Count)
                {
                    if (input.m_codeList[i] == 1 && input.m_codeList[i + 1] == 1) //  Go Up: __
                    {
                        // TO DO: Go up movement
                        m_player.MoveUp(Time.deltaTime);
                        Debug.Log("Up");
                    }
                    else if (input.m_codeList[i] == 0 && input.m_codeList[i + 1] == 0) //   Go down: **
                    {
                        // TO DO: Go down movement
                        m_player.MoveDown(Time.deltaTime);
                        Debug.Log("Down");
                    }
                    else if (input.m_codeList[i] == 1 && input.m_codeList[i + 1] == 0) //   Go left:: _*
                    {
                        // TO DO: Go left movement
                        m_player.MoveLeft(Time.deltaTime);
                        Debug.Log("Left");
                    }
                    else if (input.m_codeList[i] == 0 && input.m_codeList[i + 1] == 1) //   Go right: *_
                    {
                        // TO DO: Go right movement
                        m_player.MoveRight(Time.deltaTime);
                        Debug.Log("Right");

                    }
                }
            }

        }

        //Debug.Log("Process finished.");
        isProcessing = false;
        timer.SetCanCode();
    }

    public bool GetIfCaught()
    {
        return isCaught;
    }

    public bool GetIsProcess()
    {
        return isProcessing;
    }

    public void ChangeColorWhenLightOff()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
    }

    public void ChangeColorWhenLightOn()
    {
        GetComponent<Renderer>().material.color = Color.black;
    }
}
