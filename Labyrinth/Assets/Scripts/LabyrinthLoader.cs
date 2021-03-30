using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthLoader : MonoBehaviour
{
    public int mazeRows, mazeCols;
    public GameObject cell;
    public float size = 2f;
    public float gridSpacingOffset = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("test");
        MazeCell[,] cells = new MazeCell[mazeRows, mazeCols];
        InitializeMaze(cells);

        MazeAlgorithm ma = new PrimsAlgorithm(cells);
        ma.CreateLabyrinth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializeMaze(MazeCell[,] cells)
    {
        for(int r = 0; r < mazeRows; r++)
        {
            for (int c = 0; c < mazeCols; c++)
            {
                cells[r, c] = new MazeCell();
                Vector3 spawnPosition = new Vector3(r * gridSpacingOffset, 0, c * gridSpacingOffset) + Vector3.zero;
                cells[r, c].cellRow = r;
                cells[r, c].cellCol = c;
                cells[r, c].body = Instantiate(cell, spawnPosition, Quaternion.identity);
            }
        }
    }
}
