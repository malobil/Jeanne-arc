using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Player_Detection_Manager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Collider2D>() && !other.GetComponent<Collider2D>().isTrigger)
        {
            Script_Player.Instance.ResetJump();
        }

        if(other.CompareTag("SpecialGround"))
        {
            other.GetComponent<Collider2D>().isTrigger = false;
        }
    }
}
