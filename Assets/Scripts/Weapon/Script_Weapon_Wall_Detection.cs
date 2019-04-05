using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Weapon_Wall_Detection : MonoBehaviour
{
    private Rigidbody2D rb { get { return GetComponentInParent<Rigidbody2D>(); } }

    void Start()
    {

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Wall"))
        {
            rb.bodyType = RigidbodyType2D.Static;
            rb.velocity = new Vector2(0, 0);
        }
    }
}
