using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilesPrefabs;
    private Transform player;
    int[] lanes;
    public GameObject[] gameObstacles;
    private float spawnZ = 0.0f;
    public float tileLength = 100.0f;
    private float waitZone = 60.0f;
    private int noOfTilesOnScreen = 5;
    private List<GameObject> activeTiles ;
    private List<GameObject> activeObstacles;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        activeTiles = new List<GameObject>();
        activeObstacles = new List<GameObject>();
        lanes = new int[3];
        lanes[0] = -50;
        lanes[1] = 0;
        lanes[2] = 50;
        
           
        for(int i =0; i<noOfTilesOnScreen; i++)
        {
            SpawnTiles();
            SpawnObjects();

        }

    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.z - waitZone > (spawnZ - noOfTilesOnScreen * tileLength))
        {
            SpawnTiles();
            SpawnObjects();
            DeleteTiles();
        }
    }

    void SpawnTiles()
    {
        GameObject gameObject;
        gameObject = Instantiate(tilesPrefabs[0]) as GameObject;
        gameObject.transform.SetParent(transform);
        gameObject.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(gameObject);
    }
    
    void DeleteTiles()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    void SpawnObjects()
    {
        int randomObstacles;
        randomObstacles = Random.Range(0, 4);
        int lanePicked = Random.Range(0, lanes.Length);
        int currentLane = lanes[lanePicked];
        Vector3 obstaclePosition = new Vector3(currentLane, 3.5f, spawnZ);
        GameObject theObstacle = Instantiate(gameObstacles[randomObstacles]) as GameObject;
        theObstacle.transform.position = obstaclePosition;
        activeObstacles.Add(theObstacle);
    }
}
