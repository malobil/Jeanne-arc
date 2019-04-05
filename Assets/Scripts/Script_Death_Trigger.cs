using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Death_Trigger : MonoBehaviour
{
    public static Script_Death_Trigger Instance { get; private set; }
    [SerializeField] private float f_move_speed;
    private bool b_can_move;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Script_Game_Manager.Instance.GameOver();
        }
    }

    void Update()
    {
        if(b_can_move)
        {
            transform.Translate(Vector3.up * Time.deltaTime * f_move_speed);
        }
    }

    public void StartMoving()
    {
        b_can_move = true;
    }

    public void StopMoving()
    {
        b_can_move = false;
    }
}
