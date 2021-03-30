using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell
{
    public bool visited = false;
    public bool isWall = true;
    public MazeCell[] neighbors = null;
    public GameObject body;
    public GameObject floor;
    public int cellRow, cellCol;
}
