using System.Collections;
using UnityEngine;
using SocketIO;
using System.Collections.Generic;

public class TestSocketIO : MonoBehaviour
{
    private SocketIOComponent socket;

    private List<JSONObject> coordinates;

    private List<GameObject> objects;
    private bool allObjectsGenerated = false;

    private int screenHeight;
    private int screenWidth;
    public int distanceFromCamera = 10;
    public float distanceFromLeft = 0.2f;
    public GameObject wall;
    public GameObject bird;

    // WALL SPEED
    public float speed = 10.0f;
    private Vector3 leftEdge;
    private Vector3 rightEdge;

    Camera cam;

    public void Start()
    {
        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();
        objects = new List<GameObject>();

        socket.On("data", ReceivedData);
        coordinates = new List<JSONObject>();

        // GET SCREEN DIMENSIONS
        cam = Camera.main;
        screenHeight = Screen.height;
        screenWidth = Screen.width;

        // POSITION THE WALL
        wall.transform.position = new Vector3( wall.transform.position.x, wall.transform.position.y, cam.transform.position.z + distanceFromCamera );

        // GET LEFT EDGE FIELD OF VIEW OF CAMERA
        leftEdge = cam.ScreenToWorldPoint(new Vector3(0, screenHeight * .5f, distanceFromCamera));


    }

 public void ReceivedData(SocketIOEvent e)
    {
        coordinates = e.data[0][0].list;

    }

    private void Update()
    {
        moveBird(coordinates[10]);
        moveWall();

    }

    private void moveBird(JSONObject xy)
    {

        // EXTRACT AND CONVERT COORDINATES
        float y = 1 - xy[1].f;

        Vector3 pos = cam.ScreenToWorldPoint(new Vector3(screenWidth * distanceFromLeft, screenHeight * y, distanceFromCamera));

        // APPLY COORDINATES TO SPHERES
        bird.transform.position = pos;

    }


    private void moveWall()
    {
        wall.transform.position -= transform.right * Time.deltaTime * speed;
        // IF THE WALL IS OUT OF THE FIELD OF VIEW MOVE TO THE BEGINNING
        if(wall.transform.position.x<leftEdge.x)
        {
            rightEdge = cam.ScreenToWorldPoint(new Vector3(screenWidth, screenHeight * Random.Range(0.1f, .9f), distanceFromCamera));    
            wall.transform.position = rightEdge;
        }
    }

}
