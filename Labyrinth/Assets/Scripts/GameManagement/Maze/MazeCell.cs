using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell
{
    public bool visited = false;
    public bool isWall = true;
    public bool isStart = false;
    public bool isPath = false;
    public bool isEnemy = false;
    public bool shouldRotate = false;
    public MazeCell[] neighbors = null;
    public GameObject body;
    public MazeCell prev;
    public GameObject floor;
    public int cellRow, cellCol, position;
}
