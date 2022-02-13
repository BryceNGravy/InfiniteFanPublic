using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallSelectManagerScript : MonoBehaviour
{
    public GameObject animalSelector;
    public GameObject musicSelector;
    public GameObject volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        MoveAnimalSelector();
        MoveMusicSelector();
        volumeSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Volume", 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void SetBallSprite(string animal)
    {
        PlayerPrefs.SetString("Animal", animal);
        PlayerPrefs.Save();
        MoveAnimalSelector();
    }

    public void ChangeTrack(string newTrack)
    {
        PlayerPrefs.SetString("Track", newTrack);
        PlayerPrefs.Save();
        GameObject audioObject = GameObject.FindGameObjectWithTag("bgm");
        audioObject.GetComponent<SoundManagerScript>().SetMusic();
        MoveMusicSelector();
    }

    public void ChangeVolume(float sliderValue)
    {
        PlayerPrefs.SetFloat("Volume", sliderValue);
        PlayerPrefs.Save();
        GameObject audioObject = GameObject.FindGameObjectWithTag("bgm");
        audioObject.GetComponent<SoundManagerScript>().SetSound();
    }

    private void MoveAnimalSelector()
    {
        string animal = PlayerPrefs.GetString("Animal", "pig");
        GameObject animalIcon = GameObject.FindWithTag(animal);
        animalSelector.transform.position = new Vector3(animalIcon.transform.position.x, animalIcon.transform.position.y - 100, 0);
    }

    private void MoveMusicSelector()
    {
        string music = PlayerPrefs.GetString("Track", "blippy-trance");
        GameObject musicIcon = GameObject.FindWithTag(music);
        musicSelector.transform.position = new Vector3(musicIcon.transform.position.x, musicIcon.transform.position.y - 100, 0);
    }
}
