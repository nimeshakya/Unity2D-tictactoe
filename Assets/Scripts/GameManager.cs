using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int turn;
    public int currentTurn { get { return turn; } set { turn = value; } }

    private void Start()
    {
        turn = 0;
    }
}
