using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    Grid grid;
    private void Start()
    {
        grid = GetComponent<Grid>();
    }
    public List<Node> GiveWay(Vector3 startPos,Vector3 endPos)
    {
        List<Node> nodeList = new List<Node>();
        Node startNode = grid.GetNodeFromVector(startPos);

        Node endNode = grid.GetNodeFromVector(endPos);
       



        return nodeList;
    }

}
