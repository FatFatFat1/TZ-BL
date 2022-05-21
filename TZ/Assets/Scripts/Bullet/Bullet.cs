using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rg2;
    private Vector3 lastVel;
    private GameObject _victim;

    private void Awake()
    {
        rg2 = GetComponent<Rigidbody2D>();

    }

    void Start()
    {
        rg2.AddForce(transform.right * 500f);
    }

    private void Update()
    {
        lastVel = rg2.velocity;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("wall"))
        {
            var speed = lastVel.magnitude;
            var direction = Vector3.Reflect(lastVel.normalized, collision.contacts[0].normal);
            rg2.velocity = direction * Mathf.Max(speed,10f);
        }
        if (collision.collider.CompareTag("Team 1"))
        {
            _victim = collision.gameObject;
            _victim.GetComponent<CharacterData>().scope += 1;
            Destroy(gameObject);
        }
        if (collision.collider.CompareTag("Team 2"))
        {
            _victim = collision.gameObject;
            _victim.GetComponent<CharacterData>().scope += 1;
            Destroy(gameObject);
        }

    }
}
