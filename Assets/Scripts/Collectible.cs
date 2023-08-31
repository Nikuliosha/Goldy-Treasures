using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


/*
 * This class representing generic collectible Type.
 * When collecting an item, its name (not the actual object) will be add to an Inventory List, and the Iten the object will be destroy.
 */


public class Collectible : MonoBehaviour
{
    private static List<Transform> usedSpawnPoints = new List<Transform>();


    private void Start()
    {
        SpawnRandomally();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       if (other.CompareTag("Player"))
        {
            Collect(other.gameObject);
            
        }
    }
    
    private void Collect(GameObject player)
    {
        Inventory inventory = FindAnyObjectByType<Inventory>();
        if (inventory != null)
        {
            inventory.AddToInvetory(this);
            Destroy(gameObject);
        }
    }

    private void SpawnRandomally()
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        List<Transform> availableSpawnPoints = new List<Transform>();

        foreach (var spawnPoint in spawnPoints)
        {
            if (!usedSpawnPoints.Contains(spawnPoint.transform))
            {
                availableSpawnPoints.Add(spawnPoint.transform);
            }
        }

        if (availableSpawnPoints.Count > 0)
        {
            // Choose a random available spawn point index.
            int randomIndex = UnityEngine.Random.Range(0, availableSpawnPoints.Count);
            Transform chosenSpawnPoint = availableSpawnPoints[randomIndex];

            // Set the position of the collectible to the chosen spawn point's position.
            transform.position = chosenSpawnPoint.position;

            // Mark the chosen spawn point as used.
            usedSpawnPoints.Add(chosenSpawnPoint);
        }
    }


}
