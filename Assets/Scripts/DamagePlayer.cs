using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int damage;

    public GameObject damageNumber;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            //Colision entre enemigo y jugador

            CharacterStats stats = collision.gameObject
                    .GetComponent<CharacterStats>();
            int totalDamage = damage - stats.defenseLevels[stats.currentLevel];
            if(totalDamage <= 0)
            {
                totalDamage = 1;
            }

            collision.gameObject.GetComponent<HealthManager>()
                .DamageCharacter(totalDamage);

            var clone = (GameObject)Instantiate(damageNumber,
                    collision.gameObject.transform.position,
                    Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageNumber>().damagePoints = totalDamage;
        }
    }
}
