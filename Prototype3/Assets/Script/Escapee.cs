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

    private bool isProcessing = false;
    private float movingVelocity = 2.0f;

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
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space) && !isRecepting && count < 9)
        {
            isRecepting = true;
            codeTimer = 0.0f;
        }

        if (Input.GetKeyUp(KeyCode.Space) && isRecepting)
        {
            isRecepting = false;
            Debug.Log("timer:" + codeTimer);

            if (0.0f < codeTimer && codeTimer < 0.18f)
            {
                input.m_codeList.Add(0);
                count++;
            }
            else
            {
                input.m_codeList.Add(1);
                count++;
            }
        }

        if (isRecepting)
        {
            codeTimer += Time.deltaTime;
        }
        */

        /*
        if (count == totalInput - 1)
        {
            Debug.Log(input.m_codeList[0].ToString() + input.m_codeList[1].ToString() + input.m_codeList[2].ToString() + input.m_codeList[3].ToString());
        }
        */

        input = m_reception.GetInput();

        if (timer.GetCurrentTime() <= 0.0f)
        {
            isProcessing = true;
            //Debug.Log("total input: " + count);
            CodeProcess();
        }

    }

    private void CodeProcess()
    {
        if (input.m_codeList.Count > 0 && isProcessing)
        {
            for (int i = 0; i < input.m_codeList.Count; i += 2)
            {
                if (i + 1 <= input.m_codeList.Count)
                {
                    if (input.m_codeList[i] == 1 && input.m_codeList[i + 1] == 1) //  Go Up: __
                    {
                        // TO DO: Go up movement
                        Debug.Log("Up");
                    }
                    else if (input.m_codeList[i] == 0 && input.m_codeList[i + 1] == 0) //   Go down: **
                    {
                        // TO DO: Go down movement
                        Debug.Log("Down");
                    }
                    else if (input.m_codeList[i] == 1 && input.m_codeList[i + 1] == 0) //   Go left:: _*
                    {
                        // TO DO: Go left movement
                        Debug.Log("Left");
                    }
                    else if (input.m_codeList[i] == 0 && input.m_codeList[i + 1] == 1) //   Go right: *_
                    {
                        // TO DO: Go right movement
                        Debug.Log("Right");

                    }
                }
            }

            isProcessing = false;
        }
    }
}
