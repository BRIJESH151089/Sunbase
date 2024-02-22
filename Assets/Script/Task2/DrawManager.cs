using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public GameObject drawingPrefab;
    private List<GameObject> circles = new List<GameObject>();
    private GameObject instantiateDrawingObject;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject drawing = Instantiate(drawingPrefab);
            lineRenderer = drawing.GetComponent<LineRenderer>();
            instantiateDrawingObject = drawing;
        }

        if (Input.GetMouseButton(0))
        {
            FreeDraw();
            MouseOver();
        }

        if (Input.GetMouseButtonUp(0))
        {
            DestroyGameObject();
            
        }
    }

    void FreeDraw()
    {
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, Camera.main.ScreenToWorldPoint(mousePos));

    }


    private void DestroyGameObject()
    {

        foreach (var go in circles)

        {

            Destroy(go);

        }
        Destroy(instantiateDrawingObject);
    }
    void MouseOver()
    {

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            print(hit.collider.name);
            circles.Add(hit.collider.gameObject);

        }


    }
   


}