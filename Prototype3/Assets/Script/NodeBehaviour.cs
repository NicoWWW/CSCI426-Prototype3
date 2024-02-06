using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeBehaviour : MonoBehaviour
{
    private List<NodeBehaviour> neighborNodes;
    private Vector2Int NodeCoordinate;

    List<NodeBehaviour> GetNeighbors()
    {
        return neighborNodes;
    }

    void AddNeighbor(NodeBehaviour node)
    {
        if (!neighborNodes.Contains(node))
        {
            neighborNodes.Add(node);
        }
    }

    public void SetNodeCoordinate(int x, int y)
    {
        NodeCoordinate = new Vector2Int(x, y);
    }

    public Vector2 GetNodeCoordinate()
    {
        return NodeCoordinate;
    }
}
