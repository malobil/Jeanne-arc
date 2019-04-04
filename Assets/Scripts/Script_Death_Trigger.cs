using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Death_Trigger : MonoBehaviour
{
    [SerializeField] private float f_move_speed;
    private bool b_can_move;

    void Update()
    {
        if(b_can_move)
        {
            transform.Translate(Vector3.up * Time.deltaTime * f_move_speed);
        }
    }
}
