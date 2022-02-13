using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Moves an object downwards relative to the position of the ball
public class AdjustRelativeScript : MonoBehaviour
{
    private GameObject mainObject;
    private Vector2 oldPosition;
    private Vector2 newPosition;
    // Start is called before the first frame update
    void Start()
    {
        mainObject = GameObject.Find("Ball");
        if(mainObject == null)
        {
            Debug.Log("Error - could not find Ball object.");
        }
        newPosition = mainObject.transform.position;
        oldPosition = newPosition;
    }

    // Update is called once per frame
    void Update()
    {
        newPosition = mainObject.transform.position;
        if (newPosition.y > oldPosition.y)
        {
            float distanceDelta = newPosition.y - oldPosition.y;
            transform.position = new Vector3(transform.position.x, transform.position.y - distanceDelta, transform.position.z);
        }
        oldPosition = newPosition;
    }
}
