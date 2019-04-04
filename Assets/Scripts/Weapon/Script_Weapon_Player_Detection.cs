using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Weapon_Player_Detection : MonoBehaviour
{
    private bool b_player_is_in = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            b_player_is_in = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player") && b_player_is_in)
        {
            Script_Player.Instance.AllowThrowWeapon();
            Destroy(transform.parent.gameObject);
        }
    }
}
