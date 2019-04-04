using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Weapon : MonoBehaviour
{
    private Rigidbody2D rb { get { return GetComponent<Rigidbody2D>(); } }

    void Start()
    {
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Ground"))
        {
            rb.Sleep();
        }

        if(other.CompareTag(""))
        {
            Script_Player.Instance.AllowThrowWeapon();
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Script_Player.Instance.AllowThrowWeapon();
        }
    }
}
