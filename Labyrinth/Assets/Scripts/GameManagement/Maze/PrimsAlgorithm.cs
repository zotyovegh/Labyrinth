using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PrimsAlgorithm : MazeAlgorithm
{
    public PrimsAlgorithm(MazeCell[,] cells) : base(cells) { }
    private static System.Random rand = new System.Random();
    public override MazeCell CreateLabyrinth(GameObject enemy, float gridSpacingOffset, int safeDistance, int enemyAmount)
    {
        var wallPairs = new List<MazeCell[]>();
        GetNeighboringWalls(cells[1, 1], wallPairs);
        while (wallPairs.Count > 0)
        {
            var currentPair = TakeRandomPair(wallPairs);
            if (!currentPair[1].isWall)
            {
                continue;
            }
            currentPair[0].isWall = false;
            currentPair[1].isWall = false;
            if (currentPair[0].body != null) GameObject.Destroy(currentPair[0].body);
            if (currentPair[1].body != null) GameObject.Destroy(currentPair[1].body); 

            currentPair[1].prev = currentPair[0];

            GetNeighboringWalls(currentPair[1], wallPairs);
        }
        cells[1, 1].isStart = true;
        var path = UpdateLabyrinth(cells, cells[1, 1]);
        var finishCell = GetFinishCell(path, safeDistance);
        var newList = Shuffle(path.Where(x => (x.position > safeDistance && !x.isWall && x.position != finishCell.position)).ToList()).Take(enemyAmount).ToList();

        for (var i = 0; i < newList.Count-1; i++)
        {
            Vector3 newEnemyPosition = new Vector3(newList[i].cellRow * gridSpacingOffset * 2, 1, newList[i].cellCol * gridSpacingOffset * 2) + Vector3.zero;
            newList[i].body = GameObject.Instantiate(enemy, newEnemyPosition, Quaternion.Euler(0, rand.Next(360), 0));
        }
        return finishCell;
    }

    private MazeCell GetFinishCell(IEnumerable<MazeCell> path, int safeDistance)
    {       
        MazeCell finishCell = path.LastOrDefault(x => (x.position > safeDistance && !x.isWall));

        if(finishCell != null && finishCell.cellRow != finishCell.prev.cellRow)
        {
            finishCell.shouldRotate = true;
        }
        return finishCell;
    }

    private void GetNeighboringWalls(MazeCell cell, ICollection<MazeCell[]> wallPairs)
    {
        var row = cell.cellRow;
        var col = cell.cellCol;
        if (row > 1)
        {
            //UP
            var neighbor = cells[row - 1, col];
            wallPairs.Add(new MazeCell[] { neighbor, cells[row - 2, col] });
        }
        if (col < cells.GetLength(1) - 2)
        {
            //Right
            var neighbor = cells[row, col + 1];
            wallPairs.Add(new MazeCell[] { neighbor, cells[row, col+2] });
        }
        if (row < cells.GetLength(0) - 2)
        {
            //Down
            var neighbor = cells[row + 1, col];
            wallPairs.Add(new MazeCell[] { neighbor, cells[row + 2, col] });
        }
        if (col > 1)
        {
            //Left
            var neighbor = cells[row, col - 1];
            wallPairs.Add(new MazeCell[] { neighbor, cells[row, col-2] });
        }
    }

    private static MazeCell[] TakeRandomPair(IList<MazeCell[]> wallPairs)
    {
        var position = UnityEngine.Random.Range(0, wallPairs.Count);
        var pair = wallPairs[position];
        wallPairs.RemoveAt(position);
        return pair;
    }

    public override List<MazeCell> UpdateLabyrinth(MazeCell[,] grid, MazeCell startCell)
    {
        var mainList = new List<MazeCell>();
        var visitedCells = new List<MazeCell>();

        startCell.visited = true;
        startCell.position = 1;
        mainList.Add(startCell);
        visitedCells.Add(startCell);

        while (mainList.Count > 0)
        {
            var currentCell = mainList.First();
            mainList = mainList.Skip(1).ToList();
            visitedCells.Add(currentCell);

            if (currentCell.isWall && !currentCell.isStart) continue;
            var neighbors = GetUnvisitedNeighbors(currentCell, grid);
            foreach (var cell in neighbors)
            {
                cell.visited = true;
                cell.position = currentCell.position + 1;
                mainList.Add(cell);
            }
        }
        return visitedCells;
    }

    IEnumerable<MazeCell> GetUnvisitedNeighbors(MazeCell cell, MazeCell[,] grid)
    {
        var neighbors = new List<MazeCell>();
        Up(cell.cellRow, cell.cellCol, grid, neighbors);
        Right(cell.cellRow, cell.cellCol, grid, neighbors);
        Down(cell.cellRow, cell.cellCol, grid, neighbors);
        Left(cell.cellRow, cell.cellCol, grid, neighbors);
        return neighbors;
    }

    private static void Up(int row, int col, MazeCell[,] grid, ICollection<MazeCell> neighbors)
    {
        if (row <= 0) return;
        var cell = grid[row - 1, col];
        if (!cell.visited)
        {
            neighbors.Add(cell);
        }
    }

    private static void Right(int row, int col, MazeCell[,] grid, ICollection<MazeCell> neighbors)
    {
        if (col >= grid.GetLength(1) - 1) return;
        var cell = grid[row, col + 1];
        if (!cell.visited)
        {
            neighbors.Add(cell);
        }
    }

    private static void Down(int row, int col, MazeCell[,] grid, ICollection<MazeCell> neighbors)
    {
        if (row >= grid.GetLength(0) - 1) return;
        var cell = grid[row + 1, col];
        if (!cell.visited)
        {
            neighbors.Add(cell);
        }
    }

    private static void Left(int row, int col, MazeCell[,] grid, ICollection<MazeCell> neighbors)
    {
        if (col <= 0) return;
        var cell = grid[row, col - 1];
        if (!cell.visited)
        {
            neighbors.Add(cell);
        }
    }

    public static List<T> Shuffle<T>(List<T> list)
    {
        var rng = new System.Random();
        var n = list.Count;
        while (n > 1)
        {
            n--;
            var k = rng.Next(n + 1);
            var value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
        return list;
    }
}
