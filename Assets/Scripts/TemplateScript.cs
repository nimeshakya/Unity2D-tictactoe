using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplateScript : MonoBehaviour
{
    public GameObject circle;
    public GameObject cross;

    public GameObject circleTemplate;
    public GameObject crossTemplate;

    public GameManager gameManager;
    [SerializeField]
    private LayerMask allTilesLayer;

    private Vector3 mousePos;
    private GameObject turnTemplate; // cirle or cross template based on turn

    // Update is called once per frame
    void Update()
    {
        CurrentTurn();
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));
        SpawnCircleOrCross();
    }

    // function to select circle or cross relative to turn
    private void CurrentTurn()
    {
        if(gameManager.currentTurn == 0)
        {
            circleTemplate.SetActive(true);
            crossTemplate.SetActive(false);
            turnTemplate = circleTemplate;
        } else
        {
            circleTemplate.SetActive(false);
            crossTemplate.SetActive(true);
            turnTemplate = crossTemplate;
        }
    }

    // function to spawn circle of cross
    private void SpawnCircleOrCross()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseRay = Camera.main.ScreenToWorldPoint(transform.position);
            RaycastHit2D rayHit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, allTilesLayer);

            if (rayHit.collider != null && rayHit.collider.CompareTag("BoardTile"))
            {
                // spawn circle or cross
                SpawnOnTurn();
                rayHit.collider.GetComponent<BoxCollider2D>().enabled = !rayHit.collider.GetComponent<BoxCollider2D>().enabled;
            } else
            {
                return;
            }
        }
    }

    // spawn circle or cross based on turn
    private void SpawnOnTurn()
    {
        if (turnTemplate.CompareTag("CircleTemplate"))
        {
            Instantiate(circle, transform.position, Quaternion.identity);
            gameManager.currentTurn = 1;
        }
        else
        {
            Instantiate(cross, transform.position, Quaternion.identity);
            gameManager.currentTurn = 0;
        }
    }
}
