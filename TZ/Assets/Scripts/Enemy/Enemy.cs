using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private string state = "Idle";
    public GameObject myEnemy;
    int mylayer = 1 << 8;
    private void FixedUpdate()
    {
        ChooseState(myEnemy);
    }
    void ChooseState(GameObject player)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position, Mathf.Infinity, ~mylayer);

        if (hit.collider && hit.collider.gameObject.CompareTag("Team 1"))
        {
            //Debug.Log("Стреляю по прямой");
            return;
        }
        else
        {
            //Debug.Log("Ищу рикошет");
            state = "Search ricochet";
        }


        if (state == "Search ricochet")
        {
            float angle = 0;
            for (int i = 0; i < 360; i++)
            {
                float x = Mathf.Sin(angle);
                float y = Mathf.Cos(angle);
                angle += 2 * Mathf.PI / 360;
                Vector3 dir = new Vector3(transform.position.x + x, transform.position.y + y, 0);
                var hitPos = hit.point;
                hit = Physics2D.Raycast(hit.point, dir, Mathf.Infinity, ~mylayer);
                if (hit.collider)
                {
                    //Debug.DrawRay(hit.point, dir, Color.green);
                    if (hit.collider.gameObject.CompareTag("wall"))
                    {
                        var dirForReflect = Vector3.Reflect(dir.normalized, hit.point);
                        hitPos = hit.point.normalized;
                        hit = Physics2D.Raycast(hitPos, dirForReflect, Mathf.Infinity, ~mylayer);
                        //Debug.DrawRay(hitPos, hit.point, Color.red);
                        if (hit.collider && hit.collider.gameObject.CompareTag("Team 1")) // Рикошет в теории попадает в игрока
                        {
                            state = "Fire ricochet";
                            Debug.Log("Стреляю рикошетом");
                            return;
                        }

                    }
                }
            }
        }
        if (state != "Fire ricochet")
        {
            // Debug.Log("Не смог найти выстрел с рикошетом");
            // Движение патфандером, который надо сделать
        }
    }
}


