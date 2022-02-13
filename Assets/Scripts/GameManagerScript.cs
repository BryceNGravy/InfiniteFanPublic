using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Used to control the main game and UI, including building chunks and the border around the screen, as well as handling the game ending/repeating
public class GameManagerScript : MonoBehaviour
{
    public GameObject ball;
    public GameObject border;
    public GameObject gameOver;
    public Camera cam;
    public Button returnButton;
    public Text scoreText;
    public Text highScoreText;
    public float chunkCount;
    private float screenHalfHeight;
    private float screenHalfWidth;
    private float ballSpriteHeight;
    private float ballPreviousHeight;
    private float ballDownTime = 0;
    private float score;
    private float chunkStartHeight;
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        string playerAnimal = PlayerPrefs.GetString("Animal", "pig");
        ball.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Animals/" + playerAnimal);
        ballSpriteHeight = ball.GetComponent<SpriteRenderer>().bounds.size.y;
        ballPreviousHeight = ball.transform.position.y;

        screenHalfHeight = cam.orthographicSize;
        screenHalfWidth = cam.orthographicSize * cam.aspect;

        chunkStartHeight = screenHalfHeight * 1.5f;
        BuildBorder();
        BuildChunks();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameOver)
        {
            CheckBallHeight();
        }
    }

    //Create a border of obstacles that are sized based on the length and height of the screen
    private void BuildBorder()
    {
        GameObject topBorder = Instantiate(border, new Vector3(0, screenHalfHeight, 0), Quaternion.identity);
        topBorder.transform.localScale = new Vector3(screenHalfWidth * 2, 0.1f, 1);
        GameObject rightBorder = Instantiate(border, new Vector3(screenHalfWidth, 0, 0), Quaternion.identity);
        rightBorder.transform.localScale = new Vector3(0.1f, screenHalfHeight * 2, 1);
        GameObject leftBorder = Instantiate(border, new Vector3(-screenHalfWidth, 0, 0), Quaternion.identity);
        leftBorder.transform.localScale = new Vector3(0.1f, screenHalfHeight * 2, 1);
    }

    //Generate an appropriate amount of chunks, which are continually reused and moved upwards
    private void BuildChunks()
    {
        for(int i = 0; i < chunkCount; i++)
        {
            GameObject newChunk = new GameObject("Chunk" + i);
            newChunk.AddComponent<AdjustRelativeScript>();
            newChunk.AddComponent<ChunkScript>();
            newChunk.GetComponent<ChunkScript>().chunkPos = new Vector3(0, chunkStartHeight + (screenHalfHeight * 2 * i), 0);
            newChunk.GetComponent<ChunkScript>().chunkNum = chunkCount;
            newChunk.GetComponent<ChunkScript>().screenHalfHeight = screenHalfHeight;
            newChunk.GetComponent<ChunkScript>().screenHalfWidth = screenHalfWidth;
            newChunk.GetComponent<ChunkScript>().ball = ball;
        }
    }

    //Checks the ball's height and either ends the game or updates the score based on its position
    private void CheckBallHeight()
    {
        if(ball.transform.position.y < -screenHalfHeight - ballSpriteHeight)
        {
            GameOver();
        }
        else if(ball.transform.position.y > ballPreviousHeight)
        {
            score += (ball.transform.position.y - ballPreviousHeight);
            scoreText.text = "Score: " + (int)(score * 10);
        }
        ballPreviousHeight = ball.transform.position.y;
    }

    public void GameOver()
    {
        ball.SetActive(false);
        returnButton.gameObject.SetActive(false);
        gameOver.SetActive(true);
        isGameOver = true;
        Time.timeScale = 0;
        if(PlayerPrefs.GetInt("High Score", 0) < (int)(score * 10))
        {
            PlayerPrefs.SetInt("High Score", (int)(score * 10));
        }
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("High Score", 0);
    }

    public void ReturnConfirm(GameObject returnGroup)
    {
        Time.timeScale = 0;
        returnGroup.SetActive(true);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void ReturnToGame(GameObject returnGroup)
    {
        returnGroup.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
