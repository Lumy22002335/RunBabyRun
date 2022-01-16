using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public FpsController fpsController;
    private PlayerInput playerInput;
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    private void Start()
    {
       playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        if (playerInput.actions["Pause"].triggered)
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        fpsController.enabled = true;
        pauseMenuUI.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        fpsController.enabled = false;
        pauseMenuUI.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }

    
     public void Menu ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
