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


    private bool b_is_throw;
    [SerializeField] private GameObject g_weapon_prefab;
    [SerializeField] private GameObject g_player;

    [SerializeField] private float f_weapon_speed;

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
        if (Input.GetKeyDown("space") && i_double_jump > 0)
        {
            Jump();
        }

        Move();

        if(Input.GetKeyDown("e") && !b_is_throw)
        {
            ThrowWeapon();
        }
    }

    private void Move()
    {
        float f_horizontal_input = Input.GetAxis("Horizontal") * f_movement_speed;

        if(f_horizontal_input > 0)
        {
            g_player.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else if(f_horizontal_input < 0)
        {
            g_player.transform.rotation = new Quaternion(0, -180, 0, 0);
        }

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
        Debug.Log("OK");
        GameObject g_flag_spawned = Instantiate(g_weapon_prefab, g_player.transform.position,Quaternion.identity);
        g_flag_spawned.GetComponent<Rigidbody2D>().AddForce(transform.right * f_weapon_speed, ForceMode2D.Impulse);
        b_is_throw = true;
    }


}
