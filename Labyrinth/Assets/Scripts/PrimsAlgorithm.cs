using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PrimsAlgorithm : MazeAlgorithm
{
    public PrimsAlgorithm(MazeCell[,] cells) : base(cells) { }
    private static System.Random rand = new System.Random();
    public override MazeCell CreateLabyrinth(GameObject enemy, float gridSpacingOffset, int safeDistance, int enemyAmount)
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

            currentPair[1].prev = currentPair[0];

            getNeighboringWalls(currentPair[1], cells, wallPairs);
        }
        cells[1, 1].isStart = true;
        List<MazeCell> path = UpdateLabyrinth(cells, cells[1, 1]);
        int safeZone = (int)(path[path.Count - 1].position * 0.2);

        MazeCell finishCell = GetFinishCell(path, safeDistance);        
        
        List <MazeCell> newList = Shuffle(path.Where(x => (x.position > safeDistance && !x.isWall && x.position != finishCell.position)).ToList()).Take(enemyAmount).ToList();

        for (int i = 0; i < newList.Count-1; i++)
        {
            Vector3 newEnemyPosition = new Vector3(newList[i].cellRow * gridSpacingOffset * 2, 1, newList[i].cellCol * gridSpacingOffset * 2) + Vector3.zero;
            newList[i].body = GameObject.Instantiate(enemy, newEnemyPosition, Quaternion.Euler(0, rand.Next(360), 0));
        }
        return finishCell;
    }

    private MazeCell GetFinishCell(List<MazeCell> path, int safeDistance)
    {       
        MazeCell finishCell = path.Where(x => (x.position > safeDistance && !x.isWall)).LastOrDefault();

        if(finishCell.cellRow != finishCell.prev.cellRow)
        {
            finishCell.shouldRotate = true;
        }
        return finishCell;
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
        MazeCell[] pair = wallPairs[position];
        wallPairs.RemoveAt(position);
        return pair;
    }

    public override List<MazeCell> UpdateLabyrinth(MazeCell[,] grid, MazeCell startCell)
    {
        List<MazeCell> mainList = new List<MazeCell>();
        List<MazeCell> visitedCells = new List<MazeCell>();

        startCell.visited = true;
        startCell.position = 1;
        mainList.Add(startCell);
        visitedCells.Add(startCell);

        while (mainList.Count > 0)
        {
            MazeCell currentCell = mainList.First();
            mainList = mainList.Skip(1).ToList();
            visitedCells.Add(currentCell);

            if (currentCell.isWall && !currentCell.isStart) continue;
            var neighbors = getUnvisitedNeighbors(currentCell, grid);
            for (int i = 0; i < neighbors.Count; i++)
            {
                neighbors[i].visited = true;
                neighbors[i].position = currentCell.position + 1;
                mainList.Add(neighbors[i]);
            }
        }
        return visitedCells;
    }

    List<MazeCell> getUnvisitedNeighbors(MazeCell cell, MazeCell[,] grid)
    {
        List<MazeCell> neighbors = new List<MazeCell>();
        Up(cell.cellRow, cell.cellCol, grid, neighbors);
        Right(cell.cellRow, cell.cellCol, grid, neighbors);
        Down(cell.cellRow, cell.cellCol, grid, neighbors);
        Left(cell.cellRow, cell.cellCol, grid, neighbors);
        return neighbors;
    }

    void Up(int row, int col, MazeCell[,] grid, List<MazeCell> neighbors)
    {
        if (row > 0)
        {
            MazeCell cell = grid[row - 1, col];
            if (!cell.visited)
            {
                neighbors.Add(cell);
            }
        }
    }

    void Right(int row, int col, MazeCell[,] grid, List<MazeCell> neighbors)
    {
        if (col < grid.GetLength(1) - 1)
        {
            MazeCell cell = grid[row, col + 1];
            if (!cell.visited)
            {
                neighbors.Add(cell);
            }
        }
    }

    void Down(int row, int col, MazeCell[,] grid, List<MazeCell> neighbors)
    {
        if (row < grid.GetLength(0) - 1)
        {
            MazeCell cell = grid[row + 1, col];
            if (!cell.visited)
            {
                neighbors.Add(cell);
            }
        }
    }

    void Left(int row, int col, MazeCell[,] grid, List<MazeCell> neighbors)
    {
        if (col > 0)
        {
            MazeCell cell = grid[row, col - 1];
            if (!cell.visited)
            {
                neighbors.Add(cell);
            }
        }
    }

    public static List<T> Shuffle<T>(List<T> list)
    {
        var rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
        return list;
    }
}
