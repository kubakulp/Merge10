using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{

    public static Int32 Objecti = 0;
    
    public static int gridWidth = 5;
    public static int gridHeight = 5;

    public static Transform[,] grid = new Transform[gridWidth, gridHeight];

    public static GameObject[,] gameObjects = new GameObject[gridWidth, gridHeight];
    public static GameObject currentGameObject;

    public WinningLevel winningLevel;

    public Ads ads;
    private bool IsFirst = true;
    private bool IsMoreThenThousand = false;

    // Start is called before the first frame update
    void Start()
    {
        ScoreScript.scoreValue = 0;
        if(SceneManager.GetActiveScene().buildIndex % 11 !=0)
        {
            ScoreToWin.scoreWinValue = 400 * (SceneManager.GetActiveScene().buildIndex % 11);
        }
        else
        {
            ScoreToWin.scoreWinValue = 400 * 11;
        }
    }

    // Update is called once per frame
    void Update()
    {
        EndGame();
        AddAfterPoints();
    }


    public void RightMove()
    {       
        gameObjects[currentGameObject.x(), currentGameObject.y()] = null;

        if (currentGameObject.transform.position.x < 5)
        {
            currentGameObject.transform.position += new Vector3(1, 0, 0);
        }
        if (currentGameObject.transform.position.x > 4)
        {
            currentGameObject.transform.position += new Vector3(-5, 0, 0);
        }

        gameObjects[currentGameObject.x(), currentGameObject.y()] = currentGameObject;
    }

    public void LeftMove()
    {
        gameObjects[currentGameObject.x(), currentGameObject.y()] = null;

        if (currentGameObject.transform.position.x > -1)
        {
            currentGameObject.transform.position += new Vector3(-1, 0, 0);
        }
        if (currentGameObject.transform.position.x < 0)
        {
            currentGameObject.transform.position += new Vector3(5, 0, 0);
        }

        gameObjects[currentGameObject.x(), currentGameObject.y()] = currentGameObject;
    }

    public void UpMove()
    {
        var spawnTitle = FindObjectOfType<SpawnTile>();

                    var newTile = false;

                    for (int i = 0; i < 4; i++)
                    {
                        gameObjects[currentGameObject.x(), currentGameObject.y()] = null;

                        GameObject desGameObject = gameObjects[currentGameObject.x(), currentGameObject.y() + 1];

                        if (desGameObject != null)
                        {
                            var tileDes = desGameObject.GetComponent<Tile>();
                            var tileCurrent = currentGameObject.GetComponent<Tile>();

                            if (tileDes.tileValue < 10 || (tileDes.tileValue > 10 && tileCurrent.tileValue < 0))
                            {


                                var sum = tileDes.tileValue + tileCurrent.tileValue;
                                if(sum > 0)
                                {
                                    ScoreScript.scoreValue += sum;                
                                    ScoreToWin.scoreWinValue = ScoreToWin.scoreWinValue - sum;
                                    if(ScoreToWin.scoreWinValue<=0 && SceneManager.GetActiveScene().name!="newGame")
                                    {
                                        winningLevel.WinLevel();
                                        if (SceneManager.GetActiveScene().name == "Level30")
                                        {
                                            SceneManager.LoadScene("LastLevel");
                                        }
                                        else
                                        {
                                            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 62 - (SceneManager.GetActiveScene().buildIndex / 12));
                                        }
                                    }
                                }
                                
                                if (sum == 10 || sum == 0 || sum < -9)
                                {
                                    Destroy(currentGameObject);
                                    Destroy(desGameObject);
                                    ScoreScript.scoreValue += 10;
                                    ScoreToWin.scoreWinValue = ScoreToWin.scoreWinValue - 10;
                                    if (ScoreToWin.scoreWinValue <= 0 && SceneManager.GetActiveScene().name != "newGame")
                                    {
                                        winningLevel.WinLevel();
                                        if(SceneManager.GetActiveScene().name == "Level30")
                                        {
                                            SceneManager.LoadScene("LastLevel");
                                        }
                                        else
                                        {
                                            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 62 - (SceneManager.GetActiveScene().buildIndex / 12));
                                        }
                                    }
                                }
                                else
                                {
                                    string newTileName = $"tile_{sum}";

                                    GameObject sumTile = (GameObject)Instantiate(Resources.Load(newTileName, typeof(GameObject)), desGameObject.transform.position, Quaternion.identity);

                                    gameObjects[sumTile.x(), sumTile.y()] = sumTile;

                                    Destroy(currentGameObject);
                                    Destroy(desGameObject);
                                }

                                newTile = true;
                                break;
                            }
                            else
                                gameObjects[currentGameObject.x(), currentGameObject.y()] = currentGameObject;
                        }
                        else
                        {
                            currentGameObject.transform.position += new Vector3(0, 1, 0);
                            gameObjects[currentGameObject.x(), currentGameObject.y()] = currentGameObject;
                            newTile = true;
                        }

                        if (ScoreScript.scoreValue > 300)
                        {
                             IsMoreThenThousand = true;
                        }
                    }

                    if (newTile)
                    {
                        spawnTitle.NewTile();
                    }
    }

    public void EndGame()
    {
        if (gameObjects[0, 1] != null && gameObjects[1, 1] != null && gameObjects[2, 1] != null && gameObjects[3, 1] != null && gameObjects[4, 1] != null)
        {
            var tile1 = gameObjects[0 ,1].GetComponent<Tile>();
            var tile2 = gameObjects[1, 1].GetComponent<Tile>();
            var tile3 = gameObjects[2, 1].GetComponent<Tile>();
            var tile4 = gameObjects[3, 1].GetComponent<Tile>();
            var tile5 = gameObjects[4, 1].GetComponent<Tile>();

            if (tile1.tileValue > 10 && tile2.tileValue > 10 && tile3.tileValue > 10 && tile4.tileValue > 10 && tile5.tileValue > 10 && SceneManager.GetActiveScene().name != "newGame")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 32 - (SceneManager.GetActiveScene().buildIndex / 12));
            }

            if (tile1.tileValue > 10 && tile2.tileValue > 10 && tile3.tileValue > 10 && tile4.tileValue > 10 && tile5.tileValue > 10 && SceneManager.GetActiveScene().name == "newGame")
            {
                SceneManager.LoadScene("gameOver");
            }
        }
    }

    public void AddAfterPoints()
    {
        if(IsMoreThenThousand == true && IsFirst == true)
        {
            ads.StandardAd();
            IsFirst = false;
        }
    }
}




public static class GameObjectExtension
{
    public static Int64 x(this GameObject gameObject)
    {
        return (Int64)gameObject.transform.position.x;
    }

    public static Int64 y(this GameObject gameObject)
    {
        return (Int64)gameObject.transform.position.y;
    }
}



