using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerK : MonoBehaviour
{
    private NodeBehaviour currNode;
    private NodeBehaviour nodeDestination;
    [SerializeField] NodeManager nodeManager;
    [SerializeField] float inputCoolDown = 0.5f;
    private float timeSinceInput = 0.0f;
    float speed = 2.0f;
    //private Transform t;

    Vector3 up;
    Vector3 down;
    Vector3 left;
    Vector3 right;

    bool isLeft = false;
    bool isRight = false;
    bool isUp = false;
    bool isDown = false;

    private void Start()
    {
        currNode = nodeManager.GetNode(0, 0);
        //t = GetComponent<Transform>();
        transform.position = currNode.GetComponent<Transform>().position;
        up = new Vector3(0.0f, 1.0f, 0.0f);
        down = new Vector3(0.0f, -1.0f, 0.0f);
        left = new Vector3(-1.0f, 0.0f, 0.0f);
        right = new Vector3(1.0f, 0.0f, 0.0f);
    }
    private void FixedUpdate()
    {

        if (isLeft)
        {
            MoveLeft(Time.deltaTime);
        }
        if (isRight)
        {
            MoveRight(Time.deltaTime);
        }
        if (isUp)
        {
            MoveUp(Time.deltaTime);
        }
        if (isDown)
        {
            MoveDown(Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("moving up0");
            if (timeSinceInput > inputCoolDown)
            {
                Debug.Log("moving up1 " + timeSinceInput);
                timeSinceInput = 0.0f;
                nodeDestination = nodeManager.GetNodeUp((int)currNode.GetNodeCoordinate().x, (int)currNode.GetNodeCoordinate().y);
                MoveUp(Time.deltaTime);
                isUp = true;
            }

        }
        else if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("moving left0 " + timeSinceInput);
            if (timeSinceInput > inputCoolDown)
            {
                Debug.Log("moving left1");
                timeSinceInput = 0.0f;
                nodeDestination = nodeManager.GetNodeLeft((int)currNode.GetNodeCoordinate().x, (int)currNode.GetNodeCoordinate().y);
                MoveLeft(Time.deltaTime);
                isLeft = true;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("moving down0 " + timeSinceInput);
            if (timeSinceInput > inputCoolDown)
            {
                Debug.Log("moving down1");
                timeSinceInput = 0.0f;
                nodeDestination = nodeManager.GetNodeDown((int)currNode.GetNodeCoordinate().x, (int)currNode.GetNodeCoordinate().y);
                MoveDown(Time.deltaTime);
                isDown = true;
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("moving right0 " + timeSinceInput);
            if (timeSinceInput > inputCoolDown)
            {
                Debug.Log("moving right1");
                timeSinceInput = 0.0f;
                nodeDestination = nodeManager.GetNodeRight((int)currNode.GetNodeCoordinate().x, (int)currNode.GetNodeCoordinate().y);
                MoveRight(Time.deltaTime);
                isRight = true;
            }
        }
        else
        {
            timeSinceInput += Time.deltaTime;
        }



    }
    public void MoveUp(float deltaTime)
    {
        if (nodeDestination != null)
        {
            Debug.Log("moving up2");
            transform.position = transform.position + up * speed * deltaTime;
            if ((transform.position - nodeDestination.transform.position).magnitude <= 0.1f)
            {
                transform.position = nodeDestination.transform.position;
                currNode = nodeDestination;
                isUp = false;
                Debug.Log("NewCoord: " + currNode.GetNodeCoordinate().x + " " + currNode.GetNodeCoordinate().y);
            }
        }
        else
        {
            Debug.Log("up3 NULL");
            isUp = false;
        }

    }
    private void MoveLeft(float deltaTime)
    {
        if (nodeDestination != null)
        {
            Debug.Log("moving left2");
            transform.position = transform.position + left * speed * deltaTime;
            if ((transform.position - nodeDestination.transform.position).magnitude <= 0.1f)
            {
                transform.position = nodeDestination.transform.position;
                currNode = nodeDestination;
                isLeft = false;
                Debug.Log("NewCoord: " + currNode.GetNodeCoordinate().x + " " + currNode.GetNodeCoordinate().y);
            }
        }
        else
        {
            Debug.Log("left3 NULL");
            isLeft = false;
        }
    }
    public void MoveDown(float deltaTime)
    {
        if (nodeDestination != null)
        {
            Debug.Log("moving down2");
            transform.position = transform.position + down * speed * deltaTime;
            if ((transform.position - nodeDestination.transform.position).magnitude <= 0.1f)
            {
                transform.position = nodeDestination.transform.position;
                currNode = nodeDestination;
                isDown = false;
                Debug.Log("NewCoord: " + currNode.GetNodeCoordinate().x + " " + currNode.GetNodeCoordinate().y);
            }
        }
        else
        {
            Debug.Log("down3 NULL");
            isDown = false;
        }
    }
    public void MoveRight(float deltaTime)
    {
        if (nodeDestination != null)
        {
            Debug.Log("moving right2");
            transform.position = transform.position + right * speed * deltaTime;
            Debug.Log("this pos " + transform.position + " destPos " + nodeDestination.transform.position);
            if ((transform.position - nodeDestination.transform.position).magnitude <= 0.1f)
            {
                transform.position = nodeDestination.transform.position;
                currNode = nodeDestination;
                isRight = false;
                Debug.Log("NewCoord: " + currNode.GetNodeCoordinate().x + " " + currNode.GetNodeCoordinate().y);
            }
        }
        else
        {
            Debug.Log("right3 NULL");
            isRight = false;
        }
    }

    private void OnTriggerEnter2D()
    {
        Debug.Log("In player coll");
        if (isRight)
        {
            isRight = false;
            isLeft = true;
            nodeDestination = currNode;
        }
        else if (isDown)
        {
            isDown = false;
            isUp = true;
            nodeDestination = currNode;
        }
        else if (isUp)
        {
            isUp = false;
            isDown = true;
            nodeDestination = currNode;
        }
        else if (isLeft)
        {
            isLeft = false;
            isRight = true;
            nodeDestination = currNode;
        }
        //BounceBack();
    }

    public void BounceBack()
    {
        Vector3 lerpvec = Vector3.Lerp(transform.position, currNode.transform.position, 0.2f);
    }


}
