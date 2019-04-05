using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Script_UIManager : MonoBehaviour
{
    public static Script_UIManager Instance { get; private set; }

    public TextMeshProUGUI text_coin;
    [SerializeField] private GameObject g_game_over_screen;
    [SerializeField] private GameObject g_pause_screen;
    [SerializeField] private GameObject g_victory_screen;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        UpdateCoinUI();
    }

    public void UpdateCoinUI()
    {
        text_coin.text = Script_Game_Manager.Instance.i_coin + "<sprite=0>" ;
    }

    public void ShowGameOverScreen()
    {
        g_game_over_screen.SetActive(true);
    }

    public void UnShowGameOverScreen()
    {
        g_game_over_screen.SetActive(false);
    }

    public void ShowPauseScreen()
    {
        g_game_over_screen.SetActive(true);
    }

    public void UnShowPauseScreen()
    {
        g_game_over_screen.SetActive(false);
    }

    public void ShowVictoryScreen()
    {
        g_victory_screen.SetActive(true);
    }

    public void UnShowVictoryScreen()
    {
        g_victory_screen.SetActive(false);
    }
}
