using Mono.Cecil;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorButtonScripts : MonoBehaviour
{
    public enum RoomType { HallwayToRoom, RoomToHallway, HallwayToStair}
    public RoomType roomType;
    private SceneManagement sceneManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneManager = FindObjectOfType<SceneManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        // check if mousebutton is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // change scene
            ChangeRoom();
        }
    }

    public void ChangeRoom()
    {
        // get mouse world position
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        // check its within the object's area using the bounds
        Bounds bound = GetComponent<SpriteRenderer>().bounds;

        // if mouse is there, then spawn in chip
        if (bound.Contains(worldPos))
        {
            if (roomType == RoomType.HallwayToRoom)
            {
                sceneManager.LoadRoom();
            }
            else if (roomType == RoomType.RoomToHallway)
            {
                sceneManager.LoadHallway();
            }
            else if (roomType == RoomType.HallwayToStair)
            {
                // increase day
                sceneManager.NextDay();
                // load hallway
                sceneManager.LoadHallway();
            }
        }
    }

}
