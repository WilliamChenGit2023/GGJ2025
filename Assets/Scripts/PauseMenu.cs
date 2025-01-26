using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu; // Reference to the menu GameObject
    private bool isMenuOpen = false;         // Tracks whether the menu is open

    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    // Toggles the menu on or off
    void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        menu.SetActive(isMenuOpen);

        // Pause the game when the menu is open, resume when closed
        Time.timeScale = isMenuOpen ? 0f : 1f;
    }

    // Optional: Close the menu explicitly (e.g., from a button)
    public void CloseMenu()
    {
        isMenuOpen = false;
        menu.SetActive(false);
        Time.timeScale = 1f;
    }
}
