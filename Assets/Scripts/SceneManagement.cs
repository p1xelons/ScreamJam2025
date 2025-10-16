using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    private int currentDay = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake()
    {
        // Make sure the SceneManager persists across scene changes
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// Loads the hallway of that specific day
    /// </summary>
    public void LoadHallway()
    {
        string sceneName = "Day" + currentDay + "_Hallway";
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// loads the room of that specific day
    /// </summary>
    public void LoadRoom()
    {
        string sceneName = "Day" + currentDay + "_Room";
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// increases day, then calls load hallway
    /// </summary>
    public void NextDay()
    {
        currentDay++;
        // if the player is on the last room
        // temp 3 for testing
        if (currentDay == 3)
        {
            // reset to day 1
            currentDay = 1;
        }
        LoadHallway();
    }

    /// <summary>
    /// goes back to previous day
    /// </summary>
    public void PreviousDay()
    {
        if (currentDay > 1)
        {
            currentDay--;
            LoadHallway();
        }
    }
}
