using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAction : MonoBehaviour
{
    private Rigidbody2D rg2;
    private float modificate = 15;
    public GameObject Bullet;
    private void Awake()
    {
        rg2 = GetComponent<Rigidbody2D>();
    }
    public void MoveUp()
    {
        rg2.AddForce(Vector2.up* modificate);
    }
    public void MoveDown()
    {
        rg2.AddForce(Vector2.down * modificate);
    }
    public void MoveLeft()
    {
        rg2.AddForce(Vector2.left * modificate);
    }
    public void MoveRight()
    {
        rg2.AddForce(Vector2.right * modificate);
    }
    public void Shot()
    {
        Instantiate(Bullet, transform.position + transform.right, transform.rotation);
    }

}
