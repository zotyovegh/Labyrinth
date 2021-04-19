using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MazeAlgorithm
{
    protected MazeCell[,] cells;
    protected int mazeRows, mazeCols;
   
    protected MazeAlgorithm(MazeCell[,] cells): base()
    {
        this.cells = cells;
        mazeRows = cells.GetLength(0);
        mazeCols = cells.GetLength(1);
    }

    public abstract void CreateLabyrinth(GameObject enemy, float gridSpacingOffset, int safeDistance, int enemyAmount);

    public abstract List<MazeCell> UpdateLabyrinth(MazeCell[,] grid, MazeCell startCell);

}
