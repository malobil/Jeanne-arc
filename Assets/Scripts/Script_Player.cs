﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Player : MonoBehaviour
{
    public static Script_Player Instance { get; private set; }

    private Rigidbody2D rb { get { return GetComponent<Rigidbody2D>(); } }
    [SerializeField]private float f_movement_speed;
    [SerializeField]private float f_jump_force;
    private int i_double_jump = 2;

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
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown("e") && i_double_jump > 0)
        {
            Jump();
        }

        Move();
    }

    private void Move()
    {
        float f_horizontal_input = Input.GetAxis("Horizontal") * f_movement_speed;

        rb.velocity = new Vector2(f_horizontal_input, rb.velocity.y);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(transform.up * f_jump_force, ForceMode2D.Impulse);
        i_double_jump--;
    }

    public void ResetJump()
    {
        i_double_jump = 2;
    }

    public void ThrowWeapon()
    {

    }
}
