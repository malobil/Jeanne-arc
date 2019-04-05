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

    public void GameOver()
    {
        if(b_game_run)
        {
            //Script_UIManager.Instance.ShowGameOverScreen();
            Time.timeScale = 0.00001f;
            b_game_run = false;
        }
    }

    public void RestartGame()
    {
        if(!b_game_run)
        {
            Script_UIManager.Instance.UnShowGameOverScreen();
            Time.timeScale = 1f;
            b_game_run = true;
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    public void ReturnToMainMenu()
    {
        if(!b_game_run)
        {

        }
    }

}
