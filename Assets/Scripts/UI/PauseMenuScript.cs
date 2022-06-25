using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public void Resume()
    {
        // Set Cursor state back to locked and turn visibility off
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        // Resumes time
        Time.timeScale = 1f;

        // TODO: Set pause menu object inactive

    }

    public void PauseGame()
    {
        // TODO: Set pause menu object active

        // Unlock cursor and make it visible
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        // Freezes time
        Time.timeScale = 0f;
    }
}
