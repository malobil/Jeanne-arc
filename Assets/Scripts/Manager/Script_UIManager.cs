using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Script_UIManager : MonoBehaviour
{
    public static Script_UIManager Instance { get; private set; }

    public TextMeshProUGUI text_coin;

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
}
