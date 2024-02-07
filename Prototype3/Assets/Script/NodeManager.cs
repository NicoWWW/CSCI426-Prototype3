using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    [SerializeField] private NodeBehaviour nb;
    private List<NodeBehaviour> allNodes;
    private Maze maze;

    private int mazeHeight = 6;
    private int mazeWidth = 8;
    [SerializeField] float spaceBetweenNodes = 0.5f;
    private void Awake()
    {
        //nb = GetComponent<NodeBehaviour>();
        allNodes = new List<NodeBehaviour>();
        maze = GetComponent<Maze>();
        Vector3 ogNodePos = nb.GetComponent<Transform>().position;
        nb.SetNodeCoordinate(0, 0);
        int counter = 0;
        for (int i = 0; i < mazeHeight; i++)
        {
            for (int j = 0; j < mazeWidth; j++)
            {
                NodeBehaviour temp = Instantiate(nb);
                temp.transform.position = new Vector3((j * spaceBetweenNodes) + ogNodePos.x, ogNodePos.y - (i * spaceBetweenNodes), 0.0f);
                temp.SetNodeCoordinate(i, j);
                temp.name = "(" + i.ToString() + j.ToString() + ") " + (counter.ToString());
                allNodes.Add(temp);
                counter++;
            }
        }
    }

    public NodeBehaviour GetNode(int y, int x)
    {
        return allNodes[(y * mazeWidth) + x];
    }

    public NodeBehaviour GetNodeLeft(int y, int x)
    {

        if (x == 0)
        {
            return null;
        }
        Debug.Log("GetNodeLeft(" + x + ", " + y + ") = " + allNodes[(y * mazeWidth) + x - 1].GetNodeCoordinate().x + ", " + allNodes[(y * mazeWidth) + x - 1].GetNodeCoordinate().y);
        return allNodes[(y * mazeWidth) + x - 1];
    }
    public NodeBehaviour GetNodeRight(int y, int x)
    {

        if (x == mazeWidth - 1)
        {
            return null;
        }
        Debug.Log("GetNodeRight(" + x + ", " + y + ") = " + allNodes[(y * mazeWidth) + x + 1].GetNodeCoordinate().x + ", " + allNodes[(y * mazeWidth) + x + 1].GetNodeCoordinate().y);
        return allNodes[(y * mazeWidth) + x + 1];
    }
    public NodeBehaviour GetNodeDown(int y, int x)
    {
        if (y == mazeHeight - 1)
        {
            return null;
        }
        Debug.Log("GetNodeDown(" + x + ", " + y + ") = " + allNodes[(y * mazeWidth + 1) + x].GetNodeCoordinate().x + ", " + allNodes[(y * mazeWidth + 1) + x].GetNodeCoordinate().y);
        return allNodes[((y + 1) * mazeWidth) + x];
    }
    public NodeBehaviour GetNodeUp(int y, int x)
    {

        if (y == 0)
        {
            return null;
        }
        Debug.Log("GetNodeUp(" + x + ", " + y + ") = " + allNodes[(y * mazeWidth - 1) + x].GetNodeCoordinate().x + ", " + allNodes[(y * mazeWidth - 1) + x].GetNodeCoordinate().y);
        return allNodes[((y - 1) * mazeWidth) + x];
    }
}
