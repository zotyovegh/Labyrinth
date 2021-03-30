using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimsAlgorithm : MazeAlgorithm
{
    public PrimsAlgorithm(MazeCell[,] cells) : base(cells) { }
    public override void CreateLabyrinth()
    {
        List<MazeCell[]> wallPairs = new List<MazeCell[]>();
        getNeighboringWalls(cells[1, 1], cells, wallPairs);
        while (wallPairs.Count > 0)
        {
            MazeCell[] currentPair = takeRandomPair(wallPairs);
            if (!currentPair[1].isWall)
            {
                continue;
            }
            currentPair[0].isWall = false;
            currentPair[1].isWall = false;
            if (currentPair[0].body != null) GameObject.Destroy(currentPair[0].body);
            if (currentPair[1].body != null) GameObject.Destroy(currentPair[1].body);
            getNeighboringWalls(currentPair[1], cells, wallPairs);
        }
    }
    void getNeighboringWalls(MazeCell cell, MazeCell[,]cells, List<MazeCell[]> wallPairs)
    {
        int row = cell.cellRow;
        int col = cell.cellCol;
        if (row > 1)
        {
            //UP
            MazeCell neighbor = cells[row - 1, col];
            wallPairs.Add(new MazeCell[] { neighbor, cells[row - 2, col] });
        }
        if (col < cells.GetLength(1) - 2)
        {
            //Right
            MazeCell neighbor = cells[row, col + 1];
            wallPairs.Add(new MazeCell[] { neighbor, cells[row, col+2] });
        }
        if (row < cells.GetLength(0) - 2)
        {
            //Down
            MazeCell neighbor = cells[row + 1, col];
            wallPairs.Add(new MazeCell[] { neighbor, cells[row + 2, col] });
        }
        if (col > 1)
        {
            //Left
            MazeCell neighbor = cells[row, col - 1];
            wallPairs.Add(new MazeCell[] { neighbor, cells[row, col-2] });
        }
    }

    MazeCell[] takeRandomPair(List<MazeCell[]> wallPairs)
    {
        int position = UnityEngine.Random.Range(0, wallPairs.Count);
        Debug.Log(wallPairs.Count + " " + position);
        MazeCell[] pair = wallPairs[position];
        wallPairs.RemoveAt(position);
        return pair;
    }
}
