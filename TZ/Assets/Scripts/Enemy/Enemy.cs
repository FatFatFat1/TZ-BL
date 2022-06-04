using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private string state = "Idle";
    public GameObject Bullet;
    public GameObject myEnemy;
    public Camera Camera;
    Vector2 playerPos;
    int mylayer = 1 << 8;
    private void Update()
    {
        ChooseState(myEnemy);
    }
    void ChooseState(GameObject player)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position, Mathf.Infinity, ~mylayer);

        if (hit.collider && hit.collider.gameObject.CompareTag("Team 1"))
        {
            playerPos = new Vector2(player.GetComponent<Rigidbody2D>().transform.position.x + (player.GetComponent<SpriteRenderer>().bounds.size.x * (player.transform.position.x > GetComponent<Rigidbody2D>().transform.position.x ? 1 : -1)), GetComponent<Rigidbody2D>().transform.position.y);
            Vector3 dir = player.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, angle));
            Debug.Log("������� �� ������");
            return;
        }
        else
        {
            //Debug.Log("��� �������");
            state = "Search ricochet";
            Debug.Log("��� �������");
        }


        if (state == "Search ricochet")
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 300f, ~mylayer); //������ ��� ������� ������
            foreach (Collider2D i in hits)
            {
                hit = Physics2D.Raycast(transform.position, i.transform.position, Mathf.Infinity, ~mylayer); //������� � ������� ������
                Debug.DrawRay(transform.position, i.transform.position , Color.green);
                if (hit.collider && hit.collider.gameObject.CompareTag("wall"))
                {
                    var hitPos = hit.point;
                    var dirForReflect = Vector2.Reflect(i.transform.position.normalized, hit.normal);
                    hit = Physics2D.Raycast(hitPos, dirForReflect, Mathf.Infinity, ~mylayer);
                    Debug.DrawRay(hitPos, dirForReflect, Color.red);
                    if (hit.collider && hit.collider.gameObject.CompareTag("Team 1"))
                    {
                        Debug.DrawRay(hitPos, dirForReflect, Color.blue);
                        state = "Fire ricochet";
                        float WallAngle = Mathf.Atan2(hitPos.y, hitPos.x) * Mathf.Rad2Deg;
                        Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, WallAngle));
                        Debug.Log("������� ���������");
                        return;
                    }

                }

            }
        }
        if (state != "Fire ricochet")
        {
            // Debug.Log("�� ���� ����� ������� � ���������");
            // �������� �����������, ������� ���� �������
        }
    }
}


