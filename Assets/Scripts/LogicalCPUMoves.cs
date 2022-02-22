using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicalCPUMoves : MonoBehaviour
{
    public GameObject cross;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
    }

    public void CPUSpawnTurn()
    {
        Vector2 cpuSpawnPos = FindUniquePosition();

        GameObject spawnnedCross = Instantiate(cross, cpuSpawnPos, Quaternion.identity);
        gameManager.crossPos.Add(spawnnedCross.transform.position);

        // disable board highlight on spawnned positions
        DisableHighlight(spawnnedCross);

        gameManager.WinCheck(1);
        if (!gameManager.win)
            gameManager.currentTurn = 0;
    }

    private Vector2 FindUniquePosition()
    {
        bool foundUniquePos = false;
        Vector2 cpuSpawnPos;

        do
        {
            cpuSpawnPos = gameManager.cpuPos[Random.Range(0, gameManager.cpuPos.Count)];

            if (gameManager.circlePos.Contains(cpuSpawnPos) || gameManager.crossPos.Contains(cpuSpawnPos))
            {
                continue;
            }
            else
            {
                break;
            }
        } while (!foundUniquePos);

        cpuSpawnPos = PosRelativeToCirclePos(cpuSpawnPos);
        cpuSpawnPos = PosRelativeToItself(cpuSpawnPos);

        return cpuSpawnPos;
    }

    private Vector2 PosRelativeToItself(Vector2 cpuSpawnPos)
    {
        Vector2 relativeCPUSpawnPos = cpuSpawnPos;

        foreach(Vector2 pos in gameManager.crossPos)
        {
            switch (pos)
            {
                case Vector2 v when v.Equals(new Vector2(0, 0)):
                    if (gameManager.crossPos.Contains(new Vector2(0, 1)) || gameManager.crossPos.Contains(new Vector2(0, 2)))
                    {
                        if (gameManager.crossPos.Contains(new Vector2(0, 1)) && (!gameManager.circlePos.Contains(new Vector2(0, 2)) && !gameManager.crossPos.Contains(new Vector2(0,2))))
                            relativeCPUSpawnPos = new Vector2(0, 2);
                        if (gameManager.crossPos.Contains(new Vector2(0, 2)) && (!gameManager.circlePos.Contains(new Vector2(0, 1)) && !gameManager.crossPos.Contains(new Vector2(0, 1))))
                            relativeCPUSpawnPos = new Vector2(0, 1);
                    }
                    else if (gameManager.crossPos.Contains(new Vector2(1, 0)) || gameManager.crossPos.Contains(new Vector2(2, 0)))
                    {
                        if (gameManager.crossPos.Contains(new Vector2(1, 0)) && (!gameManager.circlePos.Contains(new Vector2(2, 0)) && !gameManager.crossPos.Contains(new Vector2(2, 0))))
                            relativeCPUSpawnPos = new Vector2(2, 0);
                        if (gameManager.crossPos.Contains(new Vector2(2, 0)) && (!gameManager.circlePos.Contains(new Vector2(1, 0)) && !gameManager.crossPos.Contains(new Vector2(1, 0))))
                            relativeCPUSpawnPos = new Vector2(1, 0);

                    }
                    else if (gameManager.crossPos.Contains(new Vector2(1, 1)) || gameManager.crossPos.Contains(new Vector2(2, 2)))
                    {
                        if (gameManager.crossPos.Contains(new Vector2(1, 1)) && (!gameManager.circlePos.Contains(new Vector2(2, 2)) && !gameManager.crossPos.Contains(new Vector2(2, 2))))
                            relativeCPUSpawnPos = new Vector2(2, 2);
                        if (gameManager.crossPos.Contains(new Vector2(2, 2)) && (!gameManager.circlePos.Contains(new Vector2(1, 1)) && !gameManager.crossPos.Contains(new Vector2(1, 1))))
                            relativeCPUSpawnPos = new Vector2(1, 1);
                    }

                    break;

                case Vector2 v when v.Equals(new Vector2(0, 1)):
                    if (gameManager.crossPos.Contains(new Vector2(0, 0)) || gameManager.crossPos.Contains(new Vector2(0, 2)))
                    {
                        if (gameManager.crossPos.Contains(new Vector2(0, 0)) && (!gameManager.circlePos.Contains(new Vector2(0, 2)) && !gameManager.crossPos.Contains(new Vector2(0, 2))))
                            relativeCPUSpawnPos = new Vector2(0, 2);
                        if (gameManager.crossPos.Contains(new Vector2(0, 2)) && (!gameManager.circlePos.Contains(new Vector2(0, 0)) && !gameManager.crossPos.Contains(new Vector2(0, 0))))
                            relativeCPUSpawnPos = new Vector2(0, 0);
                    }
                    else if (gameManager.crossPos.Contains(new Vector2(1, 1)) || gameManager.crossPos.Contains(new Vector2(2, 1)))
                    {
                        if (gameManager.crossPos.Contains(new Vector2(1, 1)) && (!gameManager.circlePos.Contains(new Vector2(2, 1)) && !gameManager.crossPos.Contains(new Vector2(2, 1))))
                            relativeCPUSpawnPos = new Vector2(2, 1);
                        if (gameManager.crossPos.Contains(new Vector2(2, 1)) && (!gameManager.circlePos.Contains(new Vector2(1, 1)) && !gameManager.crossPos.Contains(new Vector2(1, 1))))
                            relativeCPUSpawnPos = new Vector2(1, 1);
                    }

                    break;

                case Vector2 v when v.Equals(new Vector2(0, 2)):
                    if (gameManager.crossPos.Contains(new Vector2(0, 1)) || gameManager.crossPos.Contains(new Vector2(0, 0)))
                    {
                        if (gameManager.crossPos.Contains(new Vector2(0, 1)) && (!gameManager.circlePos.Contains(new Vector2(0, 0)) && !gameManager.crossPos.Contains(new Vector2(0, 0))))
                            relativeCPUSpawnPos = new Vector2(0, 0);
                        if (gameManager.crossPos.Contains(new Vector2(0, 0)) && (!gameManager.circlePos.Contains(new Vector2(0, 1)) && !gameManager.crossPos.Contains(new Vector2(0, 1))))
                            relativeCPUSpawnPos = new Vector2(0, 1);
                    }
                    else if (gameManager.crossPos.Contains(new Vector2(1, 2)) || gameManager.crossPos.Contains(new Vector2(2, 2)))
                    {
                        if (gameManager.crossPos.Contains(new Vector2(1, 2)) && (!gameManager.circlePos.Contains(new Vector2(2, 2)) && !gameManager.crossPos.Contains(new Vector2(2, 2))))
                            relativeCPUSpawnPos = new Vector2(2, 2);
                        if (gameManager.crossPos.Contains(new Vector2(2, 2)) && (!gameManager.circlePos.Contains(new Vector2(1, 2)) && !gameManager.crossPos.Contains(new Vector2(1, 2))))
                            relativeCPUSpawnPos = new Vector2(1, 2);
                    }
                    else if (gameManager.crossPos.Contains(new Vector2(1, 1)) || gameManager.crossPos.Contains(new Vector2(2, 0)))
                    {
                        if (gameManager.crossPos.Contains(new Vector2(1, 1)) && (!gameManager.circlePos.Contains(new Vector2(2, 0)) && !gameManager.crossPos.Contains(new Vector2(2, 0))))
                            relativeCPUSpawnPos = new Vector2(2, 0);
                        if (gameManager.crossPos.Contains(new Vector2(2, 0)) && (!gameManager.circlePos.Contains(new Vector2(1, 1)) && !gameManager.crossPos.Contains(new Vector2(1, 1))))
                            relativeCPUSpawnPos = new Vector2(1, 1);
                    }

                    break;

                case Vector2 v when v.Equals(new Vector2(1, 0)):
                    if (gameManager.crossPos.Contains(new Vector2(0, 0)) || gameManager.crossPos.Contains(new Vector2(2, 0)))
                    {
                        if (gameManager.crossPos.Contains(new Vector2(0, 0)) && (!gameManager.circlePos.Contains(new Vector2(2, 0)) && !gameManager.crossPos.Contains(new Vector2(2, 0))))
                            relativeCPUSpawnPos = new Vector2(2, 0);
                        if (gameManager.crossPos.Contains(new Vector2(2, 0)) && (!gameManager.circlePos.Contains(new Vector2(0, 0)) && !gameManager.crossPos.Contains(new Vector2(0, 0))))
                            relativeCPUSpawnPos = new Vector2(0, 0);
                    }
                    else if (gameManager.crossPos.Contains(new Vector2(1, 1)) || gameManager.crossPos.Contains(new Vector2(1, 2)))
                    {
                        if (gameManager.crossPos.Contains(new Vector2(1, 1)) && (!gameManager.circlePos.Contains(new Vector2(1, 2)) && !gameManager.crossPos.Contains(new Vector2(1, 2))))
                            relativeCPUSpawnPos = new Vector2(1, 2);
                        if (gameManager.crossPos.Contains(new Vector2(1, 2)) && (!gameManager.circlePos.Contains(new Vector2(1, 1)) && !gameManager.crossPos.Contains(new Vector2(1, 1))))
                            relativeCPUSpawnPos = new Vector2(1, 1);
                    }

                    break;

                case Vector2 v when v.Equals(new Vector2(1, 1)):
                    if (gameManager.crossPos.Contains(new Vector2(1, 0)) || gameManager.crossPos.Contains(new Vector2(1, 2)))
                    {
                        if (gameManager.crossPos.Contains(new Vector2(1, 0)) && (!gameManager.circlePos.Contains(new Vector2(1, 2)) && !gameManager.crossPos.Contains(new Vector2(1, 2))))
                            relativeCPUSpawnPos = new Vector2(1, 2);
                        if (gameManager.crossPos.Contains(new Vector2(1, 2)) && (!gameManager.circlePos.Contains(new Vector2(1, 0)) && !gameManager.crossPos.Contains(new Vector2(1, 0))))
                            relativeCPUSpawnPos = new Vector2(1, 0);
                    }
                    else if (gameManager.crossPos.Contains(new Vector2(0, 1)) || gameManager.crossPos.Contains(new Vector2(2, 1)))
                    {
                        if (gameManager.crossPos.Contains(new Vector2(0, 1)) && (!gameManager.circlePos.Contains(new Vector2(2, 1)) && !gameManager.crossPos.Contains(new Vector2(2, 1))))
                            relativeCPUSpawnPos = new Vector2(2, 1);
                        if (gameManager.crossPos.Contains(new Vector2(2, 1)) && (!gameManager.circlePos.Contains(new Vector2(0, 1)) && !gameManager.crossPos.Contains(new Vector2(0, 1))))
                            relativeCPUSpawnPos = new Vector2(0, 1);
                    }
                    else if (gameManager.crossPos.Contains(new Vector2(0, 0)) || gameManager.crossPos.Contains(new Vector2(2, 2)))
                    {
                        if (gameManager.crossPos.Contains(new Vector2(0, 0)) && (!gameManager.circlePos.Contains(new Vector2(2, 2)) && !gameManager.crossPos.Contains(new Vector2(2, 2))))
                            relativeCPUSpawnPos = new Vector2(2, 2);
                        if (gameManager.crossPos.Contains(new Vector2(2, 2)) && (!gameManager.circlePos.Contains(new Vector2(0, 0)) && !gameManager.crossPos.Contains(new Vector2(0, 0))))
                            relativeCPUSpawnPos = new Vector2(0, 0);
                    }
                    else if (gameManager.crossPos.Contains(new Vector2(0, 2)) || gameManager.crossPos.Contains(new Vector2(2, 0)))
                    {
                        if (gameManager.crossPos.Contains(new Vector2(0, 2)) && (!gameManager.circlePos.Contains(new Vector2(2, 0)) && !gameManager.crossPos.Contains(new Vector2(2, 0))))
                            relativeCPUSpawnPos = new Vector2(0, 2);
                        if (gameManager.crossPos.Contains(new Vector2(2, 0)) && (!gameManager.circlePos.Contains(new Vector2(0, 2)) && !gameManager.crossPos.Contains(new Vector2(0, 2))))
                            relativeCPUSpawnPos = new Vector2(0, 2);
                    }

                    break;

                case Vector2 v when v.Equals(new Vector2(1, 2)):
                    if (gameManager.crossPos.Contains(new Vector2(0, 2)) || gameManager.crossPos.Contains(new Vector2(2, 2)))
                    {
                        if (gameManager.crossPos.Contains(new Vector2(0, 2)) && (!gameManager.circlePos.Contains(new Vector2(2, 2)) && !gameManager.crossPos.Contains(new Vector2(2, 2))))
                            relativeCPUSpawnPos = new Vector2(2, 2);
                        if (gameManager.crossPos.Contains(new Vector2(2, 2)) && (!gameManager.circlePos.Contains(new Vector2(0, 2)) && !gameManager.crossPos.Contains(new Vector2(0, 2))))
                            relativeCPUSpawnPos = new Vector2(0, 2);
                    }
                    else if (gameManager.crossPos.Contains(new Vector2(1, 1)) || gameManager.crossPos.Contains(new Vector2(1, 0)))
                    {
                        if (gameManager.crossPos.Contains(new Vector2(1, 1)) && (!gameManager.circlePos.Contains(new Vector2(1, 0)) && !gameManager.crossPos.Contains(new Vector2(1, 0))))
                            relativeCPUSpawnPos = new Vector2(1, 0);
                        if (gameManager.crossPos.Contains(new Vector2(1, 0)) && (!gameManager.circlePos.Contains(new Vector2(1, 1)) && !gameManager.crossPos.Contains(new Vector2(1, 1))))
                            relativeCPUSpawnPos = new Vector2(1, 1);
                    }

                    break;

                case Vector2 v when v.Equals(new Vector2(2, 0)):
                    if (gameManager.crossPos.Contains(new Vector2(0, 0)) || gameManager.crossPos.Contains(new Vector2(1, 0)))
                    {
                        if (gameManager.crossPos.Contains(new Vector2(0, 0)) && (!gameManager.circlePos.Contains(new Vector2(1, 0)) && !gameManager.crossPos.Contains(new Vector2(1, 0))))
                            relativeCPUSpawnPos = new Vector2(1, 0);
                        if (gameManager.crossPos.Contains(new Vector2(1, 0)) && (!gameManager.circlePos.Contains(new Vector2(0, 0)) && !gameManager.crossPos.Contains(new Vector2(0, 0))))
                            relativeCPUSpawnPos = new Vector2(0, 0);
                    }
                    else if (gameManager.crossPos.Contains(new Vector2(2, 1)) || gameManager.crossPos.Contains(new Vector2(2, 2)))
                    {
                        if (gameManager.crossPos.Contains(new Vector2(2, 1)) && (!gameManager.circlePos.Contains(new Vector2(2, 2)) && !gameManager.crossPos.Contains(new Vector2(2, 2))))
                            relativeCPUSpawnPos = new Vector2(2, 2);
                        if (gameManager.crossPos.Contains(new Vector2(2, 2)) && (!gameManager.circlePos.Contains(new Vector2(2, 1)) && !gameManager.crossPos.Contains(new Vector2(2, 1))))
                            relativeCPUSpawnPos = new Vector2(2, 1);
                    }
                    else if (gameManager.crossPos.Contains(new Vector2(1, 1)) || gameManager.crossPos.Contains(new Vector2(0, 2)))
                    {
                        if (gameManager.crossPos.Contains(new Vector2(1, 1)) && (!gameManager.circlePos.Contains(new Vector2(0, 2)) && !gameManager.crossPos.Contains(new Vector2(0, 2))))
                            relativeCPUSpawnPos = new Vector2(0, 2);
                        if (gameManager.crossPos.Contains(new Vector2(0, 2)) && (!gameManager.circlePos.Contains(new Vector2(1, 1)) && !gameManager.crossPos.Contains(new Vector2(1, 1))))
                            relativeCPUSpawnPos = new Vector2(1, 1);
                    }

                    break;

                case Vector2 v when v.Equals(new Vector2(2, 1)):
                    if (gameManager.crossPos.Contains(new Vector2(2, 0)) || gameManager.crossPos.Contains(new Vector2(2, 2)))
                    {
                        if (gameManager.crossPos.Contains(new Vector2(2, 0)) && (!gameManager.circlePos.Contains(new Vector2(2, 2)) && !gameManager.crossPos.Contains(new Vector2(2, 2))))
                            relativeCPUSpawnPos = new Vector2(2, 2);
                        if (gameManager.crossPos.Contains(new Vector2(2, 2)) && (!gameManager.circlePos.Contains(new Vector2(2, 0)) && !gameManager.crossPos.Contains(new Vector2(2, 0))))
                            relativeCPUSpawnPos = new Vector2(2, 0);
                    }
                    else if (gameManager.crossPos.Contains(new Vector2(1, 1)) || gameManager.crossPos.Contains(new Vector2(0, 1)))
                    {
                        if (gameManager.crossPos.Contains(new Vector2(1, 1)) && (!gameManager.circlePos.Contains(new Vector2(0, 1)) && !gameManager.crossPos.Contains(new Vector2(0, 1))))
                            relativeCPUSpawnPos = new Vector2(0, 1);
                        if (gameManager.crossPos.Contains(new Vector2(0, 1)) && (!gameManager.circlePos.Contains(new Vector2(1, 1)) && !gameManager.crossPos.Contains(new Vector2(1, 1))))
                            relativeCPUSpawnPos = new Vector2(1, 1);
                    }

                    break;

                case Vector2 v when v.Equals(new Vector2(2, 2)):
                    if (gameManager.crossPos.Contains(new Vector2(1, 2)) || gameManager.crossPos.Contains(new Vector2(0, 2)))
                    {
                        if (gameManager.crossPos.Contains(new Vector2(1, 2)) && (!gameManager.circlePos.Contains(new Vector2(0, 2)) && !gameManager.crossPos.Contains(new Vector2(0, 2))))
                            relativeCPUSpawnPos = new Vector2(0, 2);
                        if (gameManager.crossPos.Contains(new Vector2(0, 2)) && (!gameManager.circlePos.Contains(new Vector2(1, 2)) && !gameManager.crossPos.Contains(new Vector2(1, 2))))
                            relativeCPUSpawnPos = new Vector2(1, 2);
                    }
                    else if (gameManager.crossPos.Contains(new Vector2(2, 1)) || gameManager.crossPos.Contains(new Vector2(2, 0)))
                    {
                        if (gameManager.crossPos.Contains(new Vector2(2, 1)) && (!gameManager.circlePos.Contains(new Vector2(2, 0)) && !gameManager.crossPos.Contains(new Vector2(2, 0))))
                            relativeCPUSpawnPos = new Vector2(2, 0);
                        if (gameManager.crossPos.Contains(new Vector2(2, 0)) && (!gameManager.circlePos.Contains(new Vector2(2, 1)) && !gameManager.crossPos.Contains(new Vector2(2, 1))))
                            relativeCPUSpawnPos = new Vector2(2, 1);
                    }
                    else if (gameManager.crossPos.Contains(new Vector2(1, 1)) || gameManager.crossPos.Contains(new Vector2(0, 0)))
                    {
                        if (gameManager.crossPos.Contains(new Vector2(1, 1)) && (!gameManager.circlePos.Contains(new Vector2(0, 0)) && !gameManager.crossPos.Contains(new Vector2(0, 0))))
                            relativeCPUSpawnPos = new Vector2(0, 0);
                        if (gameManager.crossPos.Contains(new Vector2(0, 0)) && (!gameManager.circlePos.Contains(new Vector2(1, 1)) && !gameManager.crossPos.Contains(new Vector2(1, 1))))
                            relativeCPUSpawnPos = new Vector2(1, 1);
                    }

                    break;
            }
        }

        return relativeCPUSpawnPos;
    }

    private Vector2 PosRelativeToCirclePos(Vector2 cpuSpawnPos)
    {
        Vector2 relativeCPUSpawnPos = cpuSpawnPos;

        foreach(Vector2 pos in gameManager.circlePos)
        {
            switch (pos)
            {
                case Vector2 v when v.Equals(new Vector2(0, 0)):
                    if (gameManager.circlePos.Contains(new Vector2(0, 1)) || gameManager.circlePos.Contains(new Vector2(0, 2)))
                    {
                        if (gameManager.circlePos.Contains(new Vector2(0, 1)) && !gameManager.crossPos.Contains(new Vector2(0,2)))
                            relativeCPUSpawnPos = new Vector2(0, 2);
                        if (gameManager.circlePos.Contains(new Vector2(0, 2)) && !gameManager.crossPos.Contains(new Vector2(0,1)))
                            relativeCPUSpawnPos = new Vector2(0, 1);
                    }
                    else if (gameManager.circlePos.Contains(new Vector2(1, 0)) || gameManager.circlePos.Contains(new Vector2(2, 0)))
                    {
                        if (gameManager.circlePos.Contains(new Vector2(1, 0)) && !gameManager.crossPos.Contains(new Vector2(2, 0)))
                            relativeCPUSpawnPos = new Vector2(2, 0);
                        if (gameManager.circlePos.Contains(new Vector2(2, 0)) && !gameManager.crossPos.Contains(new Vector2(1, 0)))
                            relativeCPUSpawnPos = new Vector2(1, 0);

                    }
                    else if (gameManager.circlePos.Contains(new Vector2(1, 1)) || gameManager.circlePos.Contains(new Vector2(2, 2)))
                    {
                        if (gameManager.circlePos.Contains(new Vector2(1, 1)) && !gameManager.crossPos.Contains(new Vector2(2, 2)))
                            relativeCPUSpawnPos = new Vector2(2, 2);
                        if (gameManager.circlePos.Contains(new Vector2(2, 2)) && !gameManager.crossPos.Contains(new Vector2(1, 1)))
                            relativeCPUSpawnPos = new Vector2(1, 1);
                    }

                    break;

                case Vector2 v when v.Equals(new Vector2(0, 1)):
                    if (gameManager.circlePos.Contains(new Vector2(0, 0)) || gameManager.circlePos.Contains(new Vector2(0, 2)))
                    {
                        if (gameManager.circlePos.Contains(new Vector2(0, 0)) && !gameManager.crossPos.Contains(new Vector2(0, 2)))
                            relativeCPUSpawnPos = new Vector2(0, 2);
                        if (gameManager.circlePos.Contains(new Vector2(0, 2)) && !gameManager.crossPos.Contains(new Vector2(0, 0)))
                            relativeCPUSpawnPos = new Vector2(0, 0);
                    }
                    else if (gameManager.circlePos.Contains(new Vector2(1, 1)) || gameManager.circlePos.Contains(new Vector2(2, 1)))
                    {
                        if (gameManager.circlePos.Contains(new Vector2(1, 1)) && !gameManager.crossPos.Contains(new Vector2(2, 1)))
                            relativeCPUSpawnPos = new Vector2(2, 1);
                        if (gameManager.circlePos.Contains(new Vector2(2, 1)) && !gameManager.crossPos.Contains(new Vector2(1, 1)))
                            relativeCPUSpawnPos = new Vector2(1, 1);
                    }

                    break;

                case Vector2 v when v.Equals(new Vector2(0, 2)):
                    if (gameManager.circlePos.Contains(new Vector2(0, 1)) || gameManager.circlePos.Contains(new Vector2(0, 0)))
                    {
                        if (gameManager.circlePos.Contains(new Vector2(0, 1)) && !gameManager.crossPos.Contains(new Vector2(0, 0)))
                            relativeCPUSpawnPos = new Vector2(0, 0);
                        if (gameManager.circlePos.Contains(new Vector2(0, 0)) && !gameManager.crossPos.Contains(new Vector2(0, 1)))
                            relativeCPUSpawnPos = new Vector2(0, 1);
                    }
                    else if (gameManager.circlePos.Contains(new Vector2(1, 2)) || gameManager.circlePos.Contains(new Vector2(2, 2)))
                    {
                        if (gameManager.circlePos.Contains(new Vector2(1, 2)) && !gameManager.crossPos.Contains(new Vector2(2, 2)))
                            relativeCPUSpawnPos = new Vector2(2, 2);
                        if (gameManager.circlePos.Contains(new Vector2(2, 2)) && !gameManager.crossPos.Contains(new Vector2(1, 2)))
                            relativeCPUSpawnPos = new Vector2(1, 2);
                    }
                    else if (gameManager.circlePos.Contains(new Vector2(1, 1)) || gameManager.circlePos.Contains(new Vector2(2, 0)))
                    {
                        if (gameManager.circlePos.Contains(new Vector2(1, 1)) && !gameManager.crossPos.Contains(new Vector2(2, 0)))
                            relativeCPUSpawnPos = new Vector2(2, 0);
                        if (gameManager.circlePos.Contains(new Vector2(2, 0)) && !gameManager.crossPos.Contains(new Vector2(1, 1)))
                            relativeCPUSpawnPos = new Vector2(1, 1);
                    }

                    break;

                case Vector2 v when v.Equals(new Vector2(1, 0)):
                    if (gameManager.circlePos.Contains(new Vector2(0, 0)) || gameManager.circlePos.Contains(new Vector2(2, 0)))
                    {
                        if (gameManager.circlePos.Contains(new Vector2(0, 0)) && !gameManager.crossPos.Contains(new Vector2(2, 0)))
                            relativeCPUSpawnPos = new Vector2(2, 0);
                        if (gameManager.circlePos.Contains(new Vector2(2, 0)) && !gameManager.crossPos.Contains(new Vector2(0, 0)))
                            relativeCPUSpawnPos = new Vector2(0, 0);
                    }
                    else if (gameManager.circlePos.Contains(new Vector2(1, 1)) || gameManager.circlePos.Contains(new Vector2(1, 2)))
                    {
                        if (gameManager.circlePos.Contains(new Vector2(1, 1)) && !gameManager.crossPos.Contains(new Vector2(1, 2)))
                            relativeCPUSpawnPos = new Vector2(1, 2);
                        if (gameManager.circlePos.Contains(new Vector2(1, 2)) && !gameManager.crossPos.Contains(new Vector2(1, 1)))
                            relativeCPUSpawnPos = new Vector2(1, 1);
                    }

                    break;

                case Vector2 v when v.Equals(new Vector2(1, 1)):
                    if (gameManager.circlePos.Contains(new Vector2(1, 0)) || gameManager.circlePos.Contains(new Vector2(1, 2)))
                    {
                        if (gameManager.circlePos.Contains(new Vector2(1, 0)) && !gameManager.crossPos.Contains(new Vector2(1, 2)))
                            relativeCPUSpawnPos = new Vector2(1, 2);
                        if (gameManager.circlePos.Contains(new Vector2(1, 2)) && !gameManager.crossPos.Contains(new Vector2(1, 0)))
                            relativeCPUSpawnPos = new Vector2(1, 0);
                    }
                    else if (gameManager.circlePos.Contains(new Vector2(0, 1)) || gameManager.circlePos.Contains(new Vector2(2, 1)))
                    {
                        if (gameManager.circlePos.Contains(new Vector2(0, 1)) && !gameManager.crossPos.Contains(new Vector2(2, 1)))
                            relativeCPUSpawnPos = new Vector2(2, 1);
                        if (gameManager.circlePos.Contains(new Vector2(2, 1)) && !gameManager.crossPos.Contains(new Vector2(0, 1)))
                            relativeCPUSpawnPos = new Vector2(0, 1);
                    }
                    else if (gameManager.circlePos.Contains(new Vector2(0, 0)) || gameManager.circlePos.Contains(new Vector2(2, 2)))
                    {
                        if (gameManager.circlePos.Contains(new Vector2(0, 0)) && !gameManager.crossPos.Contains(new Vector2(2, 2)))
                            relativeCPUSpawnPos = new Vector2(2, 2);
                        if (gameManager.circlePos.Contains(new Vector2(2, 2)) && !gameManager.crossPos.Contains(new Vector2(0, 0)))
                            relativeCPUSpawnPos = new Vector2(0, 0);
                    }
                    else if (gameManager.circlePos.Contains(new Vector2(0, 2)) || gameManager.circlePos.Contains(new Vector2(2, 0)))
                    {
                        if (gameManager.circlePos.Contains(new Vector2(0, 2)) && !gameManager.crossPos.Contains(new Vector2(2, 0)))
                            relativeCPUSpawnPos = new Vector2(0, 2);
                        if (gameManager.circlePos.Contains(new Vector2(2, 0)) && !gameManager.crossPos.Contains(new Vector2(0, 2)))
                            relativeCPUSpawnPos = new Vector2(0, 2);
                    }

                    break;

                case Vector2 v when v.Equals(new Vector2(1, 2)):
                    if (gameManager.circlePos.Contains(new Vector2(0, 2)) || gameManager.circlePos.Contains(new Vector2(2, 2)))
                    {
                        if (gameManager.circlePos.Contains(new Vector2(0, 2)) && !gameManager.crossPos.Contains(new Vector2(2, 2)))
                            relativeCPUSpawnPos = new Vector2(2, 2);
                        if (gameManager.circlePos.Contains(new Vector2(2, 2)) && !gameManager.crossPos.Contains(new Vector2(0, 2)))
                            relativeCPUSpawnPos = new Vector2(0, 2);
                    }
                    else if (gameManager.circlePos.Contains(new Vector2(1, 1)) || gameManager.circlePos.Contains(new Vector2(1, 0)))
                    {
                        if (gameManager.circlePos.Contains(new Vector2(1, 1)) && !gameManager.crossPos.Contains(new Vector2(1, 0)))
                            relativeCPUSpawnPos = new Vector2(1, 0);
                        if (gameManager.circlePos.Contains(new Vector2(1, 0)) && !gameManager.crossPos.Contains(new Vector2(1, 1)))
                            relativeCPUSpawnPos = new Vector2(1, 1);
                    }

                    break;

                case Vector2 v when v.Equals(new Vector2(2, 0)):
                    if (gameManager.circlePos.Contains(new Vector2(0, 0)) || gameManager.circlePos.Contains(new Vector2(1, 0)))
                    {
                        if (gameManager.circlePos.Contains(new Vector2(0, 0)) && !gameManager.crossPos.Contains(new Vector2(1, 0)))
                            relativeCPUSpawnPos = new Vector2(1, 0);
                        if (gameManager.circlePos.Contains(new Vector2(1, 0)) && !gameManager.crossPos.Contains(new Vector2(0, 0)))
                            relativeCPUSpawnPos = new Vector2(0, 0);
                    }
                    else if (gameManager.circlePos.Contains(new Vector2(2, 1)) || gameManager.circlePos.Contains(new Vector2(2, 2)))
                    {
                        if (gameManager.circlePos.Contains(new Vector2(2, 1)) && !gameManager.crossPos.Contains(new Vector2(2, 2)))
                            relativeCPUSpawnPos = new Vector2(2, 2);
                        if (gameManager.circlePos.Contains(new Vector2(2, 2)) && !gameManager.crossPos.Contains(new Vector2(2, 1)))
                            relativeCPUSpawnPos = new Vector2(2, 1);
                    }
                    else if (gameManager.circlePos.Contains(new Vector2(1, 1)) || gameManager.circlePos.Contains(new Vector2(0, 2)))
                    {
                        if (gameManager.circlePos.Contains(new Vector2(1, 1)) && !gameManager.crossPos.Contains(new Vector2(0, 2)))
                            relativeCPUSpawnPos = new Vector2(0, 2);
                        if (gameManager.circlePos.Contains(new Vector2(0, 2)) && !gameManager.crossPos.Contains(new Vector2(1, 1)))
                            relativeCPUSpawnPos = new Vector2(1, 1);
                    }

                    break;

                case Vector2 v when v.Equals(new Vector2(2, 1)):
                    if (gameManager.circlePos.Contains(new Vector2(2, 0)) || gameManager.circlePos.Contains(new Vector2(2, 2)))
                    {
                        if (gameManager.circlePos.Contains(new Vector2(2, 0)) && !gameManager.crossPos.Contains(new Vector2(2, 2)))
                            relativeCPUSpawnPos = new Vector2(2, 2);
                        if (gameManager.circlePos.Contains(new Vector2(2, 2)) && !gameManager.crossPos.Contains(new Vector2(2, 0)))
                            relativeCPUSpawnPos = new Vector2(2, 0);
                    }
                    else if (gameManager.circlePos.Contains(new Vector2(1, 1)) || gameManager.circlePos.Contains(new Vector2(0, 1)))
                    {
                        if (gameManager.circlePos.Contains(new Vector2(1, 1)) && !gameManager.crossPos.Contains(new Vector2(0, 1)))
                            relativeCPUSpawnPos = new Vector2(0, 1);
                        if (gameManager.circlePos.Contains(new Vector2(0, 1)) && !gameManager.crossPos.Contains(new Vector2(1, 1)))
                            relativeCPUSpawnPos = new Vector2(1, 1);
                    }

                    break;

                case Vector2 v when v.Equals(new Vector2(2, 2)):
                    if (gameManager.circlePos.Contains(new Vector2(1, 2)) || gameManager.circlePos.Contains(new Vector2(0, 2)))
                    {
                        if (gameManager.circlePos.Contains(new Vector2(1, 2)) && !gameManager.crossPos.Contains(new Vector2(0, 2)))
                            relativeCPUSpawnPos = new Vector2(0, 2);
                        if (gameManager.circlePos.Contains(new Vector2(0, 2)) && !gameManager.crossPos.Contains(new Vector2(1, 2)))
                            relativeCPUSpawnPos = new Vector2(1, 2);
                    }
                    else if (gameManager.circlePos.Contains(new Vector2(2, 1)) || gameManager.circlePos.Contains(new Vector2(2, 0)))
                    {
                        if (gameManager.circlePos.Contains(new Vector2(2, 1)) && !gameManager.crossPos.Contains(new Vector2(2, 0)))
                            relativeCPUSpawnPos = new Vector2(2, 0);
                        if (gameManager.circlePos.Contains(new Vector2(2, 0)) && !gameManager.crossPos.Contains(new Vector2(2, 1)))
                            relativeCPUSpawnPos = new Vector2(2, 1);
                    }
                    else if (gameManager.circlePos.Contains(new Vector2(1, 1)) || gameManager.circlePos.Contains(new Vector2(0, 0)))
                    {
                        if (gameManager.circlePos.Contains(new Vector2(1, 1)) && !gameManager.crossPos.Contains(new Vector2(0, 0)))
                            relativeCPUSpawnPos = new Vector2(0, 0);
                        if (gameManager.circlePos.Contains(new Vector2(0, 0)) && !gameManager.crossPos.Contains(new Vector2(1, 1)))
                            relativeCPUSpawnPos = new Vector2(1, 1);
                    }

                    break;
            }
        }

        return relativeCPUSpawnPos;
    }

    private void DisableHighlight(GameObject spawnnedCross)
    {
        foreach (GameObject tile in GameObject.FindGameObjectsWithTag("BoardTile"))
        {
            if (tile.GetComponent<BoxCollider2D>() != null)
            {
                if (spawnnedCross.transform.position == tile.transform.position)
                {
                    tile.GetComponent<BoxCollider2D>().enabled = !tile.GetComponent<BoxCollider2D>().enabled;
                }
            }
        }
    }
}

