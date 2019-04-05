using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_Game_Manager : MonoBehaviour
{
    public int i_coin = 0;
    private bool b_game_run;

    public static Script_Game_Manager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        b_game_run = true;
    }

    void Update()
    {
        
    }

    public void AddCoin()
    {
        i_coin++;
        Script_UIManager.Instance.UpdateCoinUI();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Scene_Kevin");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        if(b_game_run)
        {
            Script_UIManager.Instance.ShowGameOverScreen();
            Time.timeScale = 0f;
            b_game_run = false;
        }
    }

    public void SetTimePause()
    {
        if(b_game_run)
        {
            Time.timeScale = 0.0001f;
            b_game_run = false;
        }
    }

    public void SetTimeResume()
    {
        if(!b_game_run)
        {
            Time.timeScale = 1f;
            b_game_run = true;
        }
    }

    public void RestartGame()
    {
        if(!b_game_run)
        {
            Script_UIManager.Instance.UnShowGameOverScreen();
            SetTimePause();
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    public void Pause()
    {
        if(b_game_run)
        {
            SetTimePause();
            Script_UIManager.Instance.ShowPauseScreen();
        }
    }

    public void Resume()
    {
        if(!b_game_run)
        {
            SetTimeResume();
            Script_UIManager.Instance.UnShowPauseScreen();
        }
    }

    public void Victory()
    {
        if(b_game_run)
        {
            SetTimePause();
            Script_UIManager.Instance.ShowVictoryScreen();
        }
    }

    public void ReturnToMainMenu()
    {
        if(!b_game_run)
        {
            SceneManager.LoadScene("Scene_Main_Menu");
        }
    }

    public bool ReturnGameState()
    {
        return b_game_run;
    }
}
