using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Player_Detection_Manager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Ground"))
        {
            Script_Player.Instance.ResetJump();
        }

        if(other.CompareTag("Death"))
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
