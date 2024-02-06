using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Escapee;

public class CodeReception : MonoBehaviour
{
    // Start is called before the first frame update
    Escapee.CodeInput codeInput = new Escapee.CodeInput();

    private bool isRecepting = false;
    private int totalInput = 9;
    private float timer = 0.0f;
    private int count = 0;

    void Start()
    {
        codeInput.m_codeList = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && !isRecepting && count < 9)
        {
            isRecepting = true;
            timer = 0.0f;
        }

        if (Input.GetKeyUp(KeyCode.Space) && isRecepting)
        {
            isRecepting = false;
            Debug.Log("timer:" + timer);

            if (0.0f < timer && timer < 0.18f)
            {
                codeInput.m_codeList.Add(0);
                count++;
            }
            else
            {
                codeInput.m_codeList.Add(1);
                count++;
            }
        }

        if (isRecepting)
        {
            timer += Time.deltaTime;
        }
    }

    public Escapee.CodeInput GetInput()
    {
        return codeInput;
    }
}
