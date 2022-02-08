using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplateScript : MonoBehaviour
{
    public GameObject circle;
    public GameObject cross;

    [SerializeField]
    private LayerMask allTilesLayer;

    private Vector3 mousePos;

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
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        circle.transform.position = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));
    }

    // function to spawn circle of cross
    private void SpawnCircleOrCross()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseRay = Camera.main.ScreenToWorldPoint(transform.position);
            RaycastHit2D rayHit = Physics2D.Raycast(mouseRay, Vector2.zero, Mathf.Infinity, allTilesLayer);

            if (rayHit.collider.CompareTag("BoardTile") && (!this.gameObject.CompareTag("CircleTemplate") && !this.gameObject.CompareTag("CrossTemplate")))
            {
                // spawn circle or cross
                Instantiate(circle, transform.position, Quaternion.identity);
            } else
            {
                return;
            }
        }
    }
}
