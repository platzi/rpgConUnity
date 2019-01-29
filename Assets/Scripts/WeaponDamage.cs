using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    public int damage;

    public GameObject hurtAnimation;
    public GameObject hitPoint;
    public GameObject damageNumber;

    private CharacterStats stats;

    private void Start()
    {
        stats = transform.parent.GetComponent<CharacterStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            int totalDamage = damage;
            if(stats != null)
            {
                totalDamage += stats.strengthLevels[stats.currentLevel];
            }


            collision.gameObject.GetComponent<HealthManager>()
                .DamageCharacter(totalDamage);
            Instantiate(hurtAnimation, hitPoint.transform.position,
                        hitPoint.transform.rotation);

            var clone = (GameObject)Instantiate(damageNumber,
                    hitPoint.transform.position,
                    Quaternion.Euler(Vector3.zero)
                );
            clone.GetComponent<DamageNumber>().damagePoints = totalDamage;
        }

    }

}
