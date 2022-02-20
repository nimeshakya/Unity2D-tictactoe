using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int turn;
    public int currentTurn { get { return turn; } set { turn = value; } }

    public List<Vector2> circlePos = new List<Vector2>(); // array of positions of circle
    public List<Vector2> crossPos = new List<Vector2>(); // array of positions of cross

    // gameobjects references
    public Text circleScoreText;
    public Text crossScoreText;
    public Text winOrDrawText;

    private GameObject templateCircleCross;
    private GameObject gameOverPanel;
    private GameObject scoreBoardPanel;
    private GameObject mainMenuPanel;

    private GridManager gridManager;

    [HideInInspector]
    public bool win; // any one win
    private bool circleWin;
    private bool crossWin;

    // scores
    private static int circleScore = 0;
    private static int crossScore = 0;

    // Player 2 human or cpu
    int _player2;
    public int player2 { get { return _player2; } private set { _player2 = value; } }

    // CPU gameplay positions
    private List<Vector2> _cpuPos = new List<Vector2> { new Vector2(0, 0), new Vector2(0, 1), new Vector2(0, 2), new Vector2(1, 0), new Vector2(1, 1), new Vector2(1, 2), new Vector2(2, 0), new Vector2(2, 1), new Vector2(2, 2), };
    public List<Vector2> cpuPos { get { return _cpuPos; } private set { _cpuPos = value; } }

    private void Awake()
    {
        templateCircleCross = GameObject.FindWithTag("TemplateCircleCross");
        templateCircleCross.SetActive(false);
        gameOverPanel = GameObject.FindWithTag("GameOverPanel");
        gameOverPanel.SetActive(false);
        scoreBoardPanel = GameObject.FindWithTag("ScoreBoardPanel");
        scoreBoardPanel.SetActive(false);
        mainMenuPanel = GameObject.FindWithTag("MainMenuPanel");
        gridManager = GameObject.FindWithTag("GridManager").GetComponent<GridManager>();
    }

    private void Start()
    {
        turn = 0;
        win = false;
        circleWin = false;
        crossWin = false;

        circleScoreText.text = circleScore.ToString();
        crossScoreText.text = crossScore.ToString();
    }

    public void GameModeSelect(int gameMode) // gameMode is int 0 or 1
    {
        player2 = gameMode == 0 ? 0 : 1; // assign 0 if 1Player and 1 if 2Player

        gridManager.GenerateGrid();
        templateCircleCross.SetActive(true);
        scoreBoardPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void PlayAgain()
    {
        // clear all stored positions in respective list
        circlePos.Clear();
        crossPos.Clear();

        // restore available positions for cpu
        List<Vector2> cpuPos = new List<Vector2> { new Vector2(0, 0), new Vector2(0, 1), new Vector2(0, 2), new Vector2(1, 0), new Vector2(1, 1), new Vector2(1, 2), new Vector2(2, 0), new Vector2(2, 1), new Vector2(2, 2), };

        // default all win status
        win = false;
        circleWin = false;
        crossWin = false;
        
        // destroy all spawnned circles
        foreach(GameObject circle in GameObject.FindGameObjectsWithTag("Circle"))
        {
            Destroy(circle);
        }
        // destroy all spawnned crosses
        foreach(GameObject cross in GameObject.FindGameObjectsWithTag("Cross"))
        {
            Destroy(cross);
        }
        // destroy all spawnned tiles
        foreach(GameObject tile in GameObject.FindGameObjectsWithTag("BoardTile"))
        {
            Destroy(tile);
        }

        gridManager.GenerateGrid();

        templateCircleCross.SetActive(true);
        scoreBoardPanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // check for draw
    public void DrawCheck()
    {
        if(circlePos.Count >= 5 || crossPos.Count >= 5)
        {
            DrawAction();
        }
    }

    // do something when draw
    private void DrawAction()
    {
        templateCircleCross.SetActive(false);
        gameOverPanel.SetActive(true);
        scoreBoardPanel.SetActive(false);

        winOrDrawText.text = "Draw";
    }

    // function to do some things when circle or cross wins
    private void WinAction()
    {
        if (circleWin)
        {
            circleScore++;
            winOrDrawText.text = "Circle Wins";
            circleScoreText.text = circleScore.ToString();
        }
        if (crossWin)
        {
            crossScore++;
            winOrDrawText.text = "Cross Wins";
            crossScoreText.text = crossScore.ToString();
        }
    }

    // update win status of circle or cross if win
    private void WinUpdate()
    {
        templateCircleCross.SetActive(false);
        gameOverPanel.SetActive(true);
        scoreBoardPanel.SetActive(false);

        if(currentTurn == 0)
        {
            circleWin = true;
            crossWin = false;
            WinAction();
        }

        if (currentTurn == 1)
        {
            circleWin = false;
            crossWin = true;
            WinAction();
        }
    }

    public void WinCheck(int thisTurn)
    {
        List<Vector2> checkingList = thisTurn == 0 ? circlePos : crossPos;

        for(int i=0; i<checkingList.Count; i++)
        {
            if (!win )
            {
                DrawCheck();
                switch (checkingList[i])
                {
                    case Vector2 v when v.Equals(new Vector2(0, 0)):
                        if(checkingList.Contains(new Vector2(0, 1)) && checkingList.Contains(new Vector2(0, 2)))
                        {
                            Debug.Log("Win");
                            win = true;
                        } else if (checkingList.Contains(new Vector2(1, 0)) && checkingList.Contains(new Vector2(2, 0)))
                        {
                            Debug.Log("Win");
                            win = true;
                        } else if(checkingList.Contains(new Vector2(1, 1)) && checkingList.Contains(new Vector2(2, 2)))
                        {
                            Debug.Log("Win");
                            win = true;
                        }

                        break;

                    case Vector2 v when v.Equals(new Vector2(0, 1)):
                        if (checkingList.Contains(new Vector2(0, 0)) && checkingList.Contains(new Vector2(0, 2)))
                        {
                            Debug.Log("Win");
                            win = true;
                        }
                        else if (checkingList.Contains(new Vector2(1, 1)) && checkingList.Contains(new Vector2(2, 1)))
                        {
                            Debug.Log("Win");
                            win = true;
                        }

                        break;

                    case Vector2 v when v.Equals(new Vector2(0, 2)):
                        if (checkingList.Contains(new Vector2(0, 1)) && checkingList.Contains(new Vector2(0, 0)))
                        {
                            Debug.Log("Win");
                            win = true;
                        }
                        else if (checkingList.Contains(new Vector2(1, 2)) && checkingList.Contains(new Vector2(2, 2)))
                        {
                            Debug.Log("Win");
                            win = true;
                        }
                        else if (checkingList.Contains(new Vector2(1, 1)) && checkingList.Contains(new Vector2(2, 0)))
                        {
                            Debug.Log("Win");
                            win = true;
                        }

                        break;

                    case Vector2 v when v.Equals(new Vector2(1, 0)):
                        if (checkingList.Contains(new Vector2(0, 0)) && checkingList.Contains(new Vector2(2, 0)))
                        {
                            Debug.Log("Win");
                            win = true;
                        }
                        else if (checkingList.Contains(new Vector2(1, 1)) && checkingList.Contains(new Vector2(1,2)))
                        {
                            Debug.Log("Win");
                            win = true;
                        }

                        break;

                    case Vector2 v when v.Equals(new Vector2(1, 1)):
                        if (checkingList.Contains(new Vector2(1, 0)) && checkingList.Contains(new Vector2(1, 2)))
                        {
                            Debug.Log("Win");
                            win = true;
                        }
                        else if (checkingList.Contains(new Vector2(0, 1)) && checkingList.Contains(new Vector2(2, 1)))
                        {
                            Debug.Log("Win");
                            win = true;
                        }
                        else if (checkingList.Contains(new Vector2(0, 0)) && checkingList.Contains(new Vector2(2, 2)))
                        {
                            Debug.Log("Win");
                            win = true;
                        }
                        else if (checkingList.Contains(new Vector2(0, 2)) && checkingList.Contains(new Vector2(2, 0)))
                        {
                            Debug.Log("Win");
                            win = true;
                        }

                        break;

                    case Vector2 v when v.Equals(new Vector2(1, 2)):
                        if (checkingList.Contains(new Vector2(0, 2)) && checkingList.Contains(new Vector2(2, 2)))
                        {
                            Debug.Log("Win");
                            win = true;
                        }
                        else if (checkingList.Contains(new Vector2(1, 1)) && checkingList.Contains(new Vector2(1, 0)))
                        {
                            Debug.Log("Win");
                            win = true;
                        }

                        break;

                    case Vector2 v when v.Equals(new Vector2(2, 0)):
                        if (checkingList.Contains(new Vector2(0, 0)) && checkingList.Contains(new Vector2(1, 0)))
                        {
                            Debug.Log("Win");
                            win = true;
                        }
                        else if (checkingList.Contains(new Vector2(2, 1)) && checkingList.Contains(new Vector2(2, 2)))
                        {
                            Debug.Log("Win");
                            win = true;
                        }
                        else if (checkingList.Contains(new Vector2(1, 1)) && checkingList.Contains(new Vector2(0, 2)))
                        {
                            Debug.Log("Win");
                            win = true;
                        }

                        break;

                    case Vector2 v when v.Equals(new Vector2(2, 1)):
                        if (checkingList.Contains(new Vector2(2, 0)) && checkingList.Contains(new Vector2(2, 2)))
                        {
                            Debug.Log("Win");
                            win = true;
                        }
                        else if (checkingList.Contains(new Vector2(1, 1)) && checkingList.Contains(new Vector2(0, 1)))
                        {
                            Debug.Log("Win");
                            win = true;
                        }

                        break;

                    case Vector2 v when v.Equals(new Vector2(2, 2)):
                        if (checkingList.Contains(new Vector2(1, 2)) && checkingList.Contains(new Vector2(0, 2)))
                        {
                            Debug.Log("Win");
                            win = true;
                        }
                        else if (checkingList.Contains(new Vector2(2, 1)) && checkingList.Contains(new Vector2(2, 0)))
                        {
                            Debug.Log("Win");
                            win = true;
                        }
                        else if (checkingList.Contains(new Vector2(1, 1)) && checkingList.Contains(new Vector2(0, 0)))
                        {
                            Debug.Log("Win");
                            win = true;
                        }

                        break;
                }
            } else
            {
                WinUpdate();// perform win action
                break; // break loop
            }
        }
    }
}
