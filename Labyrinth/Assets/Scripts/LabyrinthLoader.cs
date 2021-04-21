using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthLoader : MonoBehaviour
{
    public int mazeRows, mazeCols;
    public GameObject cell;
    public GameObject enemy;
   // public GameObject cellFloor;
    public float gridSpacingOffset = 1f;
    public int safeDistance, enemyAmount;

    // Start is called before the first frame update
    void Start()
    {
        MazeCell[,] cells = new MazeCell[mazeRows, mazeCols];
        InitializeGrid(cells);

        MazeAlgorithm ma = new PrimsAlgorithm(cells);
        ma.CreateLabyrinth(enemy, gridSpacingOffset, safeDistance, enemyAmount);

        Vector3 cellPosition = new Vector3(1 * gridSpacingOffset * 2, 1, (-5) * gridSpacingOffset * 2) + Vector3.zero;
     //  GameObject.Instantiate(enemy, cellPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializeGrid(MazeCell[,] cells)
    {
        for(int r = 0; r < mazeRows; r++)
        {
            for (int c = 0; c < mazeCols; c++)
            {                
                Vector3 cellPosition = new Vector3(r * gridSpacingOffset*2, 1, c * gridSpacingOffset*2) + Vector3.zero;
              //  Vector3 floorPosition = new Vector3(r * gridSpacingOffset*2, 0, c * gridSpacingOffset*2) + Vector3.zero;

                cells[r, c] = new MazeCell();
                cells[r, c].cellRow = r;
                cells[r, c].cellCol = c;
                cells[r, c].body = Instantiate(cell, cellPosition, Quaternion.identity);
               //S cells[r, c].floor = Instantiate(cellFloor, floorPosition, Quaternion.identity);
            }
        }
    }
}
