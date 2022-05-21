using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterData : MonoBehaviour
{   
    public int scope = 0;
    public GameObject MyscopeBoard;

    void OnCollisionEnter2D(Collision2D collision)
    {
        MyscopeBoard.GetComponent<Text>().text = "Î×ÊÈ " + scope;
    }
}
