using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Player : MonoBehaviour
{
    public static Script_Player Instance { get; private set; }

    private Rigidbody2D rb { get { return GetComponent<Rigidbody2D>(); } }
    [SerializeField]private float f_movement_speed;
    [SerializeField]private float f_jump_force;
    private int i_double_jump = 2;

    void Start()
    {

    }

    void Update()
    {
        Move();

        if(Input.GetKeyDown("e"))
        {
            Jump();
        }
    }

    private void Move()
    {
        float f_horizontal_input = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(f_horizontal_input, rb.velocity.y) * f_movement_speed;
    }

    private void Jump()
    {
        rb.AddForce(transform.up * f_jump_force);
        Debug.Log("Jump");
        //i_double_jump--;
    }

    public void ResetJump()
    {
        i_double_jump = 2;
    }
}
