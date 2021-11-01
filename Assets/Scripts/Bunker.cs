using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunker : MonoBehaviour
{
    public SpriteRenderer sprite;
    public int health = 100;
    public int damage = 10;
    void OnTriggerEnter2D(Collider2D collision)
    {
        health -= damage;
        if (health<= 0)
        Destroy(gameObject);
    }
}
