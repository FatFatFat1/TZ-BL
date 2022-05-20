using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rg2;

    private void Awake()
    {
        rg2 = GetComponent<Rigidbody2D>();

    }

    void Start()
    {
        rg2.AddForce(transform.right * 100f);
    }

}
