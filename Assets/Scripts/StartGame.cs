using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    [SerializeField]
    string scene;

    public void GameStart()
    {
        SceneManager.LoadScene(scene);
    }

    public void Quit()
    {
        System.Environment.Exit(0);
    }

}
