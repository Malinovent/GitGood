using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameMode currentGameMode = GameMode.PLAY;

    /// <summary>
    /// Full a singleton
    /// </summary>
    public static GameManager Singleton;

    private void Awake()
    {
        if(Singleton == null)
        {
            Singleton = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }  
    }

    public void SwitchGameMode(GameMode newGameMode)
    {
        currentGameMode = newGameMode;
    }

    public void SwitchScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}

public enum GameMode
{
    PLAY,
    PAUSE
}