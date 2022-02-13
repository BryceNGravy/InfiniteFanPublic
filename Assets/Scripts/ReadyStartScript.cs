using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Creates a delay before the beginning of each game
public class ReadyStartScript : MonoBehaviour
{
    public GameObject ball;
    public Button backButton;
    public Text readyStartText;
    private int counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        ball.GetComponent<Rigidbody2D>().Sleep();
        backButton.interactable = false;
    }

    // Using FixedUpdate to ensure a consistent countdown
    void FixedUpdate()
    {
        counter++;
        if (counter > 200)
        {
            ball.GetComponent<Rigidbody2D>().WakeUp();
            backButton.interactable = true;
            Destroy(gameObject);
        }
        else if(counter > 100)
        {
            readyStartText.text = "Start!";
        }
    }
}
