using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsManagerScript : MonoBehaviour
{
    public GameObject infoGroup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void InfoOnOff()
    {
        infoGroup.SetActive(!infoGroup.activeSelf);
    }

    public void SetName(string name)
    {
        infoGroup.transform.Find("NameText").GetComponent<Text>().text = name;
    }

    public void SetPicture(Sprite picture)
    {
        infoGroup.transform.Find("Picture").GetComponent<Image>().sprite = picture;
    }

    public void SetDescription(string text)
    {
        if(text.Contains("MusicLicenses"))
        {
            text = text.Replace("MusicLicenses", "\n" + Resources.Load<TextAsset>("BGM/musiclicenses").text);
        }
        infoGroup.transform.Find("Scroll View/Viewport/Content/Text").GetComponent<Text>().text = text;
    }
}
