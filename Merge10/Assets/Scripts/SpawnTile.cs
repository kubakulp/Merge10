using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnTile : MonoBehaviour
{
    public GameObject[] Tiles;

    void Start()
    {
        NewTile();
    }

    public void NewTile()
    {
        var gameObject = Instantiate(Tiles[Random.Range(0, Tiles.Length)], transform.position, Quaternion.identity);

        Game.currentGameObject = gameObject;

        Game.gameObjects[0, 0] = gameObject;
    }

    
}
