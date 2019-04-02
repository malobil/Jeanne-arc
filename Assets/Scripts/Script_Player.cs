using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Player : MonoBehaviour
{
    private Rigidbody2D rb { get { return GetComponent<Rigidbody2D>(); } }
    [SerializeField]private float f_movement_speed;
    [SerializeField]private float f_jump_force;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(Input.GetButtonDown("space"))
        {
            Jump();
        }
    }

    public void Move()
    {
        float f_horizontal_input = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(f_horizontal_input, rb.velocity.y) * f_movement_speed;
    }

    public void Jump()
    {
        rb.AddForce(transform.up * f_jump_force);
    }
}
