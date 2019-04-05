using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Trigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Script_Death_Trigger.Instance.StartMoving();
        }
    }
}
