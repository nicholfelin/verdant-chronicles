using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
    public Canvas canvas;

    void Start()
    {
        // Set the canvas position
        canvas.transform.position = new Vector3(0, 0, 0);
    }
    void Update()
    {
        // Detect any mouse click or touch input
        if (Input.GetMouseButtonDown(0))
        {
            LoadNextScene();
        }
    }

    // Load the next scene (you can replace "GameScene" with your next scene name)
    private void LoadNextScene()
    {
        SceneManager.LoadScene("Loading");
    }
}
