using UnityEngine;
using UnityEngine.SceneManagement; // Needed to change scenes

public class ClickToChangeScene : MonoBehaviour
{
    // This method runs every frame
    void Update()
    {
        // Check for any mouse click or tap (for mobile devices)
        if (Input.GetMouseButtonDown(0)) // 0 refers to left mouse button
        {
            // Load the main scene
            SceneManager.LoadScene("GameScene"); // Use the exact name of your main scene
        }
    }
}