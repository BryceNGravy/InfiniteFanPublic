using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Used for UI on the main menu
public class MenuManagerScript : MonoBehaviour
{
    public Text highScoreText;
    private void Start()
    {
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("High Score", 0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToScene(int i)
    {
        SceneManager.LoadScene(i);
    }
}
