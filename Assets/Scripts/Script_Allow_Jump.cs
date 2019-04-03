using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Allow_Jump : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Ground"))
        {
            //Script_Player.Instance.ResetJump();
        }
    }
}
