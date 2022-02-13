using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("bgm").Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            SetMusic();
            SetSound();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMusic()
    {
        string track = PlayerPrefs.GetString("Track", "blippy-trance");
        gameObject.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("BGM/" + track);
        gameObject.GetComponent<AudioSource>().Play();
    }

    public void SetSound()
    {
        float volume = PlayerPrefs.GetFloat("Volume", 0.25f);
        gameObject.GetComponent<AudioSource>().volume = volume;
    }
}
