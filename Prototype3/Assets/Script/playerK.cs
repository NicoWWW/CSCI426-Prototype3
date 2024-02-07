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

    bool canInput = true; //true when player stops moving

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
            MoveUp(Time.deltaTime);

        }
        else if (Input.GetKey(KeyCode.A))
        {
            MoveLeft(Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            MoveDown(Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MoveRight(Time.deltaTime);
        }
        else
        {
            //timeSinceInput += Time.deltaTime;
        }



    }
    public void MoveUp(float deltaTime)
    {

        if (!isUp && canInput)
        {
            Debug.Log("moving up START");
            //timeSinceInput = 0.0f;
            nodeDestination = nodeManager.GetNodeUp((int)currNode.GetNodeCoordinate().x, (int)currNode.GetNodeCoordinate().y);
            isUp = true;
            canInput = false;
            Debug.Log("current Coord: " + currNode.GetNodeCoordinate().x + " " + currNode.GetNodeCoordinate().y);
            Debug.Log("New Coord: " + nodeDestination.GetNodeCoordinate().x + " " + nodeDestination.GetNodeCoordinate().y);
        }


        if (nodeDestination != null)
        {
            Debug.Log("moving up2");

            if ((transform.position - nodeDestination.transform.position).magnitude <= 0.1f)
            {
                transform.position = nodeDestination.transform.position;
                currNode = nodeDestination;
                isUp = false;
                canInput = true;
            }
        }
        else
        {
            Debug.Log("up3 NULL");
            //isUp = false;
        }
        transform.position = transform.position + up * speed * deltaTime;
    }
    public void MoveLeft(float deltaTime)
    {

        if (!isLeft && canInput)
        {
            Debug.Log("moving left START");
            //timeSinceInput = 0.0f;
            nodeDestination = nodeManager.GetNodeLeft((int)currNode.GetNodeCoordinate().x, (int)currNode.GetNodeCoordinate().y);
            isLeft = true;
            canInput = false;
            Debug.Log("current Coord: " + currNode.GetNodeCoordinate().x + " " + currNode.GetNodeCoordinate().y);
            Debug.Log("New Coord: " + nodeDestination.GetNodeCoordinate().x + " " + nodeDestination.GetNodeCoordinate().y);
        }


        if (nodeDestination != null)
        {
            Debug.Log("moving left2");

            if ((transform.position - nodeDestination.transform.position).magnitude <= 0.1f)
            {
                transform.position = nodeDestination.transform.position;
                currNode = nodeDestination;
                isLeft = false;
                canInput = true;

            }
        }
        else
        {
            Debug.Log("left3 NULL");
            //isLeft = false;
        }

        transform.position = transform.position + left * speed * deltaTime;
    }
    public void MoveDown(float deltaTime)
    {

        if (!isDown && canInput)
        {
            Debug.Log("moving down START");
            //timeSinceInput = 0.0f;
            nodeDestination = nodeManager.GetNodeDown((int)currNode.GetNodeCoordinate().x, (int)currNode.GetNodeCoordinate().y);
            isDown = true;
            canInput = false;
            Debug.Log("current Coord: " + currNode.GetNodeCoordinate().x + " " + currNode.GetNodeCoordinate().y);
            Debug.Log("New Coord: " + nodeDestination.GetNodeCoordinate().x + " " + nodeDestination.GetNodeCoordinate().y);
        }


        if (nodeDestination != null)
        {
            Debug.Log("moving down2");

            if ((transform.position - nodeDestination.transform.position).magnitude <= 0.1f)
            {
                transform.position = nodeDestination.transform.position;
                currNode = nodeDestination;
                isDown = false;
                canInput = true;
            }
        }
        else
        {
            Debug.Log("down3 NULL");
            isDown = false;
        }

        transform.position = transform.position + down * speed * deltaTime;
    }
    public void MoveRight(float deltaTime)
    {



        if (!isRight && canInput)
        {
            Debug.Log("moving right START");
            //timeSinceInput = 0.0f;
            nodeDestination = nodeManager.GetNodeRight((int)currNode.GetNodeCoordinate().x, (int)currNode.GetNodeCoordinate().y);
            isRight = true;
            canInput = false;
            Debug.Log("current Coord: " + currNode.GetNodeCoordinate().x + " " + currNode.GetNodeCoordinate().y);
            Debug.Log("New Coord: " + nodeDestination.GetNodeCoordinate().x + " " + nodeDestination.GetNodeCoordinate().y);
        }


        if (nodeDestination != null)
        {
            Debug.Log("moving right2");

            if ((transform.position - nodeDestination.transform.position).magnitude <= 0.1f)
            {
                transform.position = nodeDestination.transform.position;
                currNode = nodeDestination;
                isRight = false;
                canInput = true;
            }
        }
        else
        {
            Debug.Log("right3 NULL");
            //isRight = false;
        }
        transform.position = transform.position + right * speed * deltaTime;

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
