using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterAction : MonoBehaviour
{
    private Rigidbody2D rg2;
    [SerializeField] private float modificate = 150;
    public GameObject Bullet;
    private InputSystemPlayer cAction;

    private void Update()
    {
        Move(cAction.Player.Move.ReadValue<Vector2>());
    }
    private void Awake()
    {
        cAction = new InputSystemPlayer();
        rg2 = GetComponent<Rigidbody2D>();
        cAction.Player.Shot.started += _ => Shot();
    }
    private void OnEnable()
    {
        cAction.Enable();
    }
    private void OnDisable()
    {
        cAction.Disable();
    }
    public void Move(Vector2 dir)
    {
        rg2.velocity = dir * Time.deltaTime * modificate;
    }
 
    public void Shot()
    {
        Instantiate(Bullet, transform.position + transform.right, transform.rotation);
    }

}
