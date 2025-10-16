using Mono.Cecil;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorButtonScripts : MonoBehaviour
{
    public enum RoomType { HallwayToRoom, RoomToHallway}
    public RoomType roomType;
    private SceneManagement sceneManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneManager = FindFirstObjectByType<SceneManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        // check if its a hallway or room
        if (roomType == RoomType.HallwayToRoom)
        {
            sceneManager.LoadRoom();
        }
        else if (roomType == RoomType.RoomToHallway)
        {
            sceneManager.LoadHallway();
        }
    }
}
