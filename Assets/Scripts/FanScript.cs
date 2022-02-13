using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//Handles logic for the fan, namely when and how it swings along its arc
public class FanScript : MonoBehaviour
{
    public GameObject ball;
    public Camera cam;
    public Touch t;
    public Canvas canvas;
    public float fanClampFactor; //should always be <= 1 but > 0
    private GraphicRaycaster gRay;
    private EventSystem eventSys;
    private PointerEventData eventData;
    private float ellipseWidth;
    private float ellipseHeight;
    private float screenHalfWidth;
    private float screenHalfHeight;

    // Start is called before the first frame update
    void Start()
    {
        screenHalfHeight = cam.orthographicSize;
        ellipseHeight = -transform.position.y;
        screenHalfWidth = cam.orthographicSize * cam.aspect;
        ellipseWidth = cam.orthographicSize * cam.aspect;

        gRay = canvas.GetComponent<GraphicRaycaster>();
        eventSys = canvas.GetComponent<EventSystem>();
        eventData = new PointerEventData(eventSys);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale != 0)
        {
            if (Input.touchCount > 0)
            {
                t = Input.GetTouch(0);
                MoveFan(t.position);
            }
            else if (Input.GetMouseButton(0))
            {
                MoveFan(Input.mousePosition);
            }
        }
    }

    //Moves the fan along the bottom of an ellipse based on the player's input's x position
    //Clamped by fanClampFactor to ensure that it stops at the same point on both sides
    private void MoveFan(Vector3 inputOnScreen)
    {
        if(!ButtonClicked(inputOnScreen))
        {
            float xInWorldSpace = Mathf.Clamp(cam.ScreenToWorldPoint(inputOnScreen).x, -screenHalfWidth * fanClampFactor, screenHalfWidth * fanClampFactor);
            float yOnEllipse;
            if (Mathf.Abs(ellipseHeight) < Mathf.Abs(ellipseWidth))
            {
                yOnEllipse = -(ellipseWidth * Mathf.Sqrt(Mathf.Pow(ellipseHeight, 2) - Mathf.Pow(xInWorldSpace, 2))) / ellipseHeight;
            }
            else if (Mathf.Abs(ellipseHeight) > Mathf.Abs(ellipseWidth))
            {
                yOnEllipse = -(ellipseHeight * Mathf.Sqrt(Mathf.Pow(ellipseWidth, 2) - Mathf.Pow(xInWorldSpace, 2))) / ellipseWidth;
            }
            else
            {
                yOnEllipse = Mathf.Sqrt(Mathf.Pow(ellipseHeight, 2) - Mathf.Pow(xInWorldSpace, 2));
            }
            transform.position = new Vector3(xInWorldSpace, yOnEllipse, 0);
            transform.up = -transform.position; //Finds the opposite point to the object and makes that it's up vector
        }
    }

    //Uses raycasting to detect when the player clicks on the X button so the fan doesn't move position
    private bool ButtonClicked(Vector3 pos)
    {
        eventData.position = pos;
        List<RaycastResult> rayResults = new List<RaycastResult>();
        gRay.Raycast(eventData, rayResults);
        if(rayResults.Count > 0) //Valid as long as the X button is the only UI on screen; may want to change after adding more UI depending
        {
            return true;
        }
        return false;
    }
}
