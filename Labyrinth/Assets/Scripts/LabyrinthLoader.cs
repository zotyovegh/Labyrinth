using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthLoader : MonoBehaviour
{
    public GameObject cell;
    public GameObject enemy;
    public GameObject player;
    public GameObject cellFloor;
    public GameObject cup;
    public float gridSpacingOffset = 1f;
    public int safeDistance, enemyAmount, mazeRows, mazeCols;
    public bool repositionPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        if (repositionPlayer)
        {
            player.transform.position = new Vector3(2, 1, 2);
        }        

        MazeCell[,] cells = new MazeCell[mazeRows, mazeCols];
        InitializeGrid(cells);

        MazeAlgorithm ma = new PrimsAlgorithm(cells);
        MazeCell finalCell =  ma.CreateLabyrinth(enemy, gridSpacingOffset, safeDistance, enemyAmount);

        InitializeCup(finalCell);
    }

    private void InitializeCup(MazeCell finalCell)
    {
        Vector3 cupPosition = new Vector3((float)(finalCell.cellRow + 0.20) * gridSpacingOffset * 2, (float)0.8, finalCell.cellCol * gridSpacingOffset * 2) + Vector3.zero;
        Instantiate(cup, cupPosition, Quaternion.identity);
    
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
                Vector3 floorPosition = new Vector3(r * gridSpacingOffset * 2, 0, c * gridSpacingOffset * 2) + Vector3.zero;

                cells[r, c] = new MazeCell();
                cells[r, c].cellRow = r;
                cells[r, c].cellCol = c;
                cells[r, c].body = Instantiate(cell, cellPosition, Quaternion.identity);
                cells[r, c].floor = Instantiate(cellFloor, floorPosition, Quaternion.identity);
            }
        }
    }
   
}
