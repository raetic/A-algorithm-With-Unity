﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public bool canWalk;
    public Vector3 myPos;
    public int myX;
    public int myY;
    public int gCost;
    public int hCost;
    public int fcost;
    public Node par;
    public Node(bool walk,Vector3 pos,int X,int Y)
    {
       canWalk = walk;
       myPos = pos;
        myX = X;
        myY = Y;
    }
   
}
