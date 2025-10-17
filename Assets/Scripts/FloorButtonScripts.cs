//using Mono.Cecil;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class FloorButtonScripts : MonoBehaviour
{
    public enum RoomType { HallwayToRoom, RoomToHallway, HallwayToStair}
    public RoomType roomType;
    private SceneManagement sceneManager;
    private AudioSource soundEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneManager = FindObjectOfType<SceneManagement>();
        soundEffect = GetComponent<AudioSource>();
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
            // Start the coroutine to handle sound + scene change
            StartCoroutine(SoundAndChange());
        }
    }

    private IEnumerator SoundAndChange()
    {
        if (soundEffect != null && soundEffect.clip != null)
        {
            soundEffect.PlayOneShot(soundEffect.clip);
            yield return new WaitForSeconds(soundEffect.clip.length);
        }

        switch (roomType)
        {
            case RoomType.HallwayToRoom:
                sceneManager.LoadRoom();
                break;
            case RoomType.RoomToHallway:
                sceneManager.LoadHallway();
                break;
            case RoomType.HallwayToStair:
                sceneManager.NextDay();
                sceneManager.LoadHallway();
                break;
        }
    }

}
