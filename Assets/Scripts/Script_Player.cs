using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Player : MonoBehaviour
{
    private Rigidbody rb { get { return GetComponent<Rigidbody>(); } }
    private float f_moveent_speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        float f_horizontal_input = Input.GetAxis("Horizontal");
        rb.velocity = (transform.forward * f_horizontal_input) * f_moveent_speed * Time.fixedDeltaTime;
    }
}
