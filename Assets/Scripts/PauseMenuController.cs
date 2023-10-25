using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;

    private bool _isPaused = false;

    private void Start()
    {
        CloseMenu();
    }

    public void ToggleMenu()
    {
        _isPaused = !_isPaused;

        if(_isPaused)
        {
            OpenMenu();
        }
        else 
        { 
            CloseMenu(); 
        }
    }

    public void OpenMenu()
    {
        pauseMenuUI.SetActive(true);
        GameManager.Singleton.SwitchGameMode(GameMode.PAUSE);
        //Go to GameManager to pause the game
    }

    public void CloseMenu()
    {
        pauseMenuUI.SetActive(false);
        GameManager.Singleton.SwitchGameMode(GameMode.PLAY);
        //Go to GameManager to play the game
    }
}
