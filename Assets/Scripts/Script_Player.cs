using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Player : MonoBehaviour
{
    public static Script_Player Instance { get; private set; }

    private Rigidbody2D rb { get { return GetComponent<Rigidbody2D>(); } }
    [SerializeField] private float f_movement_speed;
    [SerializeField] private float f_jump_force;
    [SerializeField] private float f_x_clamp_position = 4.61f;
    private int i_double_jump = 2;

    [SerializeField] private GameObject g_weapon_prefab;
    [SerializeField] private GameObject g_player;


    [SerializeField] private float f_weapon_speed;
    private GameObject g_weapon_spawned;
    private bool b_can_throw_weapon = true;

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
        if (Input.GetKeyDown(KeyCode.Space) && i_double_jump > 0)
        {
            Jump();
        }

        Move();

        if (Input.GetKeyDown("e") && b_can_throw_weapon)
        {
            ThrowWeapon();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Script_Game_Manager.Instance.ReturnGameState())
            {
                Script_Game_Manager.Instance.SetTimePause();
            }
            else if (!Script_Game_Manager.Instance.ReturnGameState())
            {
                Script_Game_Manager.Instance.SetTimeResume();
            }
        }
    }

    private void Move()
    {
        float f_horizontal_input = Input.GetAxis("Horizontal") * f_movement_speed;

        if (f_horizontal_input > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            Debug.Log("Droite");
        }
        else if (f_horizontal_input < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            Debug.Log("Gauche");
        }

        rb.velocity = new Vector2(f_horizontal_input, rb.velocity.y);

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -f_x_clamp_position, f_x_clamp_position), transform.position.y);
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
        if (g_weapon_spawned != null)
        {
            Destroy(g_weapon_spawned);
        }

        g_weapon_spawned = Instantiate(g_weapon_prefab, g_player.transform.position, Quaternion.identity);
        g_weapon_spawned.GetComponent<Rigidbody2D>().AddForce(transform.right * f_weapon_speed, ForceMode2D.Impulse);

        if (transform.localRotation == Quaternion.Euler(0, 180, 0))
        {
            g_weapon_spawned.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if(transform.localRotation == Quaternion.Euler(0, 0, 0))
        {
            g_weapon_spawned.transform.localRotation = Quaternion.Euler(0, 180, 0);

        }


        Debug.Log(g_weapon_spawned.transform.localEulerAngles);
        b_can_throw_weapon = false;
        StartCoroutine("WaitBeforeThrowWeapon");
    }

    IEnumerator WaitBeforeThrowWeapon()
    {
        yield return new WaitForSeconds(0.5f);
        b_can_throw_weapon = true;
    }
}
