using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Game_Manager : MonoBehaviour
{
    public int i_coin = 0;

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
        
    }

    void Update()
    {
        
    }

    public void AddCoin()
    {
        i_coin++;
        Script_UIManager.Instance.UpdateCoinUI();
    }


}
