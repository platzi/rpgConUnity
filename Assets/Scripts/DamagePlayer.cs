using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int damage;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            //Colision entre enemigo y jugador

            collision.gameObject.GetComponent<HealthManager>()
                .DamageCharacter(damage);
        }
    }
}
