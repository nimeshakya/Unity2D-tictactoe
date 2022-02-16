using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int turn;
    public int currentTurn { get { return turn; } set { turn = value; } }

    public List<Vector2> circlePos = new List<Vector2>(); // array of positions of circle
    public List<Vector2> crossPos = new List<Vector2>(); // array of positions of cross

    bool win;

    private void Start()
    {
        turn = 0;
        win = false;
    }

    private void Update()
    {
    }

    public void WinCheck(int thisTurn)
    {
        List<Vector2> checkingList = thisTurn == 0 ? circlePos : crossPos;

        for(int i=0; i<checkingList.Count; i++)
        {
            if (!win)
            {
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
                break; // break loop
            }
        }
    }
}
