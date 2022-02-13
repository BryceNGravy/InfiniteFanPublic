using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStuckScript : MonoBehaviour
{
    public GameObject gameManager;
    public AudioClip[] impactSounds;
    private int counter = -300; //Starting negative so the ReadyStart at the beginning doesn't count towards the counter
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume", 0.25f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(gameObject.GetComponent<Rigidbody2D>().IsSleeping())
        {
            counter++;
        }
        else
        {
            counter = 0;
        }
        if(counter >= 300)
        {
            gameManager.GetComponent<GameManagerScript>().GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.GetComponent<AudioSource>().clip = impactSounds[Random.Range(0, impactSounds.Length)];
        gameObject.GetComponent<AudioSource>().Play();
    }
}
