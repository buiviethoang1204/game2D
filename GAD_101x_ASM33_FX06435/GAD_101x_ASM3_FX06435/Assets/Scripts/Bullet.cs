using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private float bulletDamage;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * bulletSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Block"))
        {
            Debug.Log("OnTriggerEnter2D with Block");
            collision.SendMessageUpwards("OnDamaged", bulletDamage);
        }

        if (!collision.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }

   
}
