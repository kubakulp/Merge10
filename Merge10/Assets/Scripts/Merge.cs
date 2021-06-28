using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merge : MonoBehaviour
{
    public static int gridWidth = 5;
    public static int gridHeight = 5;
    //public static Transform[,] grid = new Transform[gridWidth, gridHeight];

    public bool CheckAndCombineTiles()
    {
        Transform movingTile = FindObjectOfType<SpawnTile>().transform;

        Vector2 pos = movingTile.transform.localPosition;

        Transform collidingTile = Game.grid[(int)pos.x, (int)pos.y];

        int movingTileValue = movingTile.GetComponent<Tile>()?.tileValue ?? 0;
        int collidingTileValue = collidingTile.GetComponent<Tile>()?.tileValue ?? 0;
        int suma = movingTileValue + collidingTileValue;

        if (suma == 10)
        {
            Destroy(movingTile.gameObject);
            Destroy(collidingTile.gameObject);
            UpdateGrid();

            return true;
        }
        else

        if (collidingTileValue < 10 && movingTileValue < 10)
        {
            Destroy(movingTile.gameObject);
            Destroy(collidingTile.gameObject);

            Game.grid[(int)pos.x, (int)pos.y] = null;

            string newTileName = "tile_" + suma;

            GameObject newTile = (GameObject)Instantiate(Resources.Load(newTileName, typeof(GameObject)), pos, Quaternion.identity);

            newTile.transform.parent = transform;

            newTile.GetComponent<Tile>().mergedThisTurn = true;

            UpdateGrid();

            return true;
        }
        else

        if (collidingTileValue > 10 && movingTileValue < 0)
        {
            Destroy(movingTile.gameObject);
            Destroy(collidingTile.gameObject);

            Game.grid[(int)pos.x, (int)pos.y] = null;

            string newTileName = "tile_" + suma;

            GameObject newTile = (GameObject)Instantiate(Resources.Load(newTileName, typeof(GameObject)), pos, Quaternion.identity);

            newTile.transform.parent = transform;

            newTile.GetComponent<Tile>().mergedThisTurn = true;

            UpdateGrid();

            return true;
        }

        return false;
    }

    void UpdateGrid()
    {
        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                if (Game.grid[x, y] != null)
                {
                    if (Game.grid[x, y].parent == transform)
                    {
                        Game.grid[x, y] = null;
                    }
                }
            }
        }
    }

    public bool EndGame()
    {
        for(int x = 0; x < gridWidth; x++)
        {
            Transform LookingTile = Game.grid[x,1];
            int LookingTileValue = LookingTile.GetComponent<Tile>()?.tileValue ?? 0;
            if(LookingTileValue<10)
            {
                return false;
            }
        }
        return true;
    }
}
