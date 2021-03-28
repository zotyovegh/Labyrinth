﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthPrefab : MonoBehaviour
{
    public GameObject[] itemsToPickFrom;
    public int gridX;
    public int gridY;
    public float gridSpacingOffset = 1f;
    public Vector3 gridOrigin = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        SpawnGrid();
    }

    void SpawnGrid()
    {
       for(int x = 0; x < gridX; x++)
        {
            for (int y = 0; y < gridY; y++)
            {
                Vector3 spawnPosition = new Vector3(x * gridSpacingOffset, 0, y * gridSpacingOffset) + gridOrigin;
                PickAndSpawn(spawnPosition, Quaternion.identity);
            }
        }
    }

    void PickAndSpawn(Vector3 positionToSpawn, Quaternion rotationToSpawn)
    {
        int randomIndex = Random.Range(0, itemsToPickFrom.Length);
        GameObject clone = Instantiate(itemsToPickFrom[randomIndex], positionToSpawn, rotationToSpawn);
    }
}
