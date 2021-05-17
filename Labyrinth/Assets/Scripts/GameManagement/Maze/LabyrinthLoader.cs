using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthLoader : MonoBehaviour
{
    [SerializeField]
    public GameObject cell;
    [SerializeField]
    public GameObject enemy;
    [SerializeField]
    public GameObject player;
    [SerializeField]
    public GameObject cellFloor;
    [SerializeField]
    public GameObject cellCeiling;
    [SerializeField]
    public GameObject cup;    
    [SerializeField]
    public int mazeRows, mazeCols;
    [SerializeField]
    public bool initializeCeiling;

    private int safeDistance, enemyAmount;
    private float gridSpacingOffset = 1f;

    // Start is called before the first frame update
    void Start()
    {
        InitializeDefaultData();

        MazeCell[,] cells = new MazeCell[mazeRows, mazeCols];
        InitializeGrid(cells);

        MazeAlgorithm ma = new PrimsAlgorithm(cells);
        MazeCell finalCell =  ma.CreateLabyrinth(enemy, gridSpacingOffset, safeDistance, enemyAmount);

        InitializeCup(finalCell);
    }

    private void InitializeDefaultData()
    {
        if (GameSetup.gameType == null)
        {
            GameSetup.torchAmount = -1;
            GameSetup.hammerLife = 100;
            GameSetup.bulletAmount = 100;
            GameSetup.size = mazeRows;
            GameSetup.safeDistance = safeDistance;
        }
        if(GameSetup.size != 0)
        {
            mazeRows = GameSetup.size;
            mazeCols = GameSetup.size;
        }         
        if (GameSetup.safeDistance != 0)
        {
            safeDistance = GameSetup.safeDistance;
        }
        enemyAmount = GameSetup.enemyAmount;
    }

    private void InitializeCup(MazeCell finalCell)
    {      
        if (finalCell.shouldRotate)
        {
            Vector3 cupPosition = new Vector3(finalCell.cellRow * gridSpacingOffset * 2, (float)0.8, (float)(finalCell.cellCol-0.2) * gridSpacingOffset * 2) + Vector3.zero;
            GameObject cupObj = Instantiate(cup, cupPosition, Quaternion.identity);
            cupObj.transform.Rotate(0, 90, 0);
        }
        else
        {
            Vector3 cupPosition = new Vector3((float)(finalCell.cellRow + 0.20) * gridSpacingOffset * 2, (float)0.8, finalCell.cellCol * gridSpacingOffset * 2) + Vector3.zero;
            Instantiate(cup, cupPosition, Quaternion.identity);
        }        
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
                if (initializeCeiling)
                {
                    Vector3 ceilingPosition = new Vector3(r * gridSpacingOffset * 2, 2, c * gridSpacingOffset * 2) + Vector3.zero;
                    cells[r, c].ceiling = Instantiate(cellCeiling, ceilingPosition, Quaternion.identity);
                }                

                if (r == 0 || r == mazeRows - 1 || c == 0 || c == mazeCols-1)
                {
                    var wallScript = cells[r, c].body.GetComponent<WallScript>();
                    wallScript.isMapEdgeElement = true;
                }
            }
        }
    }   
}
