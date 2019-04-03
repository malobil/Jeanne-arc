using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Coin : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Script_Game_Manager.Instance.AddCoin();
            Destroy(gameObject);
        }
    }
}
