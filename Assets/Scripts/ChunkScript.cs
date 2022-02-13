using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles logic for chunks, including building subchunks, randomizing obstacles, and moving after the ball has passed the chunk
public class ChunkScript : MonoBehaviour
{
    public GameObject ball;
    public Object[] obstacleOptions;
    public Vector2 chunkPos;
    public float screenHalfHeight;
    public float screenHalfWidth;
    public float chunkNum;
    private GameObject[] chunkObstacles;
    private Vector2[] pointArray;
    private Vector2[,] subchunkArray;
    private int numObstacles = 3;

    // Start is called before the first frame update
    void Start()
    {
        obstacleOptions = Resources.LoadAll("ChunkObstacles");
        if(obstacleOptions.Length < 1)
        {
            Debug.Log("Chunk obstacle load error.");
        }
        gameObject.transform.position = new Vector3(chunkPos.x, chunkPos.y, 0);
        chunkObstacles = new GameObject[numObstacles];
        pointArray = new Vector2[8];
        subchunkArray = new Vector2[9,2];
        PopulatePointArray();
        BuildSubchunks();
        RandomizeObstacles();
    }

    // Update is called once per frame
    void Update()
    {
        if(ball.transform.position.y > transform.position.y + screenHalfHeight * 3)
        {
            AdjustPos();
        }
    }

    //Gets the 8 points on the screen necessary to create a 3x3 grid
    private void PopulatePointArray()
    {
        pointArray[0] = new Vector2(-screenHalfWidth, screenHalfHeight); //top left corner of screen
        pointArray[1] = new Vector2((float)(screenHalfWidth / 3.0f), screenHalfHeight);
        pointArray[2] = new Vector2((float)(-screenHalfWidth / 3.0f), (float)(screenHalfHeight / 3.0f));
        pointArray[3] = new Vector2(screenHalfWidth, (float)(screenHalfHeight / 3.0f));
        pointArray[4] = new Vector2(-screenHalfWidth, (float)(-screenHalfHeight / 3.0f));
        pointArray[5] = new Vector2((float)(screenHalfWidth / 3.0f), (float)(-screenHalfHeight / 3.0f));
        pointArray[6] = new Vector2((float)(-screenHalfWidth / 3.0f), -screenHalfHeight);
        pointArray[7] = new Vector2(screenHalfWidth, -screenHalfHeight); //bottom right corner of screen
    }

    //Creates the 9 subchunks using combinations of two points from the point array; initially used loops but changed to hardcoding due to comparison issues usually stemming from strange data typings
    private void BuildSubchunks()
    {
        //Subchunk 0
        subchunkArray[0, 0] = pointArray[0];
        subchunkArray[0, 1] = pointArray[2];
        //Subchunk 1
        subchunkArray[1, 0] = pointArray[1];
        subchunkArray[1, 1] = pointArray[2];
        //Subchunk 2
        subchunkArray[2, 0] = pointArray[1];
        subchunkArray[2, 1] = pointArray[3];
        //Subchunk 3
        subchunkArray[3, 0] = pointArray[2];
        subchunkArray[3, 1] = pointArray[4];
        //Subchunk 4
        subchunkArray[4, 0] = pointArray[2];
        subchunkArray[4, 1] = pointArray[5];
        //Subchunk 5
        subchunkArray[5, 0] = pointArray[3];
        subchunkArray[5, 1] = pointArray[5];
        //Subchunk 6
        subchunkArray[6, 0] = pointArray[4];
        subchunkArray[6, 1] = pointArray[6];
        //Subchunk 7
        subchunkArray[7, 0] = pointArray[5];
        subchunkArray[7, 1] = pointArray[6];
        //Subchunk 8
        subchunkArray[8, 0] = pointArray[5];
        subchunkArray[8, 1] = pointArray[7];
    }

    //Clears any obstacles in the chunk and spawns obstacles in separate subchunks
    private void RandomizeObstacles()
    {
        if(chunkObstacles.Length > 0)
        {
            foreach(GameObject ob in chunkObstacles)
            {
                Destroy(ob);
            }
        }
        List<int> availableSubchunks = new List<int>();
        for(int i = 0; i < subchunkArray.Length / 2; i++)
        {
            availableSubchunks.Add(i);
        }
        for(int i = 0; i < numObstacles; i++)
        {
            int chunkIndex = availableSubchunks[Random.Range(0, availableSubchunks.Count)];
            availableSubchunks.Remove(chunkIndex); //Once a subchunk is used, remove it from the available pool of chunks so it's not used again
            int randObIndex = Random.Range(0, obstacleOptions.Length);
            GameObject randOb = (GameObject)obstacleOptions[randObIndex]; //Pick a random object to spawn from the pool of objects
            //Variables for adjusting where the object can spawn using half its size; changes to negative based on the positions of the x and y to ensure that bounds are shrunk instead of expanded
            float xAdjust = (subchunkArray[chunkIndex, 0].x < subchunkArray[chunkIndex, 1].x) ? randOb.GetComponent<SpriteRenderer>().bounds.size.x + ball.GetComponent<SpriteRenderer>().bounds.size.x : -randOb.GetComponent<SpriteRenderer>().bounds.size.x - ball.GetComponent<SpriteRenderer>().bounds.size.x;
            float yAdjust = (subchunkArray[chunkIndex, 0].x < subchunkArray[chunkIndex, 1].x) ? randOb.GetComponent<SpriteRenderer>().bounds.size.y + ball.GetComponent<SpriteRenderer>().bounds.size.y : -randOb.GetComponent<SpriteRenderer>().bounds.size.y - ball.GetComponent<SpriteRenderer>().bounds.size.y;
            float xPos = Random.Range(subchunkArray[chunkIndex, 0].x + xAdjust, subchunkArray[chunkIndex, 1].x - xAdjust);
            float yPos = Random.Range(subchunkArray[chunkIndex, 0].y + yAdjust, subchunkArray[chunkIndex, 1].y - yAdjust) + transform.position.y; //Use the points of the subchunk as the bounds for where the obstacle can spawn
            chunkObstacles[i] = Instantiate(randOb, new Vector3(xPos, yPos, 0), Quaternion.identity);
            chunkObstacles[i].gameObject.transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)));
            chunkObstacles[i].transform.parent = transform;
        }
    }

    //When the ball is far enough from the chunk, relocates the chunk higher and rerandomizes it
    private void AdjustPos()
    {
        float newYPos = transform.position.y + (screenHalfHeight * 2 * chunkNum);
        transform.position = new Vector3(0, newYPos, 0);
        RandomizeObstacles();
    }
}
