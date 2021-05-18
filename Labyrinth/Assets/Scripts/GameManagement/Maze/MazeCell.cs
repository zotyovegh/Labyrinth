using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell
{
    public bool visited = false;
    public bool isWall = true;
    public bool isStart = false;
    public bool shouldRotate = false;
    public GameObject body;
    public MazeCell prev;
    public GameObject floor;
    public GameObject ceiling;
    public int cellRow, cellCol, position;
}
