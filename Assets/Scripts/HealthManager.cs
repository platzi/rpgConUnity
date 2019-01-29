using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public bool flashActive;
    public float flashLength;
    private float flashCounter;

    private SpriteRenderer characterRenderer;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        characterRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }

        if (flashActive)
        {
            flashCounter -= Time.deltaTime;

            if(flashCounter > flashLength * 0.66f)
            {
                ToggleColor(false);
            }else if(flashCounter > flashLength * 0.33f)
            {
                ToggleColor(true);
            } else if(flashCounter > 0)
            {
                ToggleColor(false);
            }
            else
            {
                ToggleColor(true);
                flashActive = false;
            }
        }
    }

    public void DamageCharacter(int damage)
    {
        currentHealth -= damage;
        if (flashLength > 0)
        {
            flashActive = true;
            flashCounter = flashLength;
        }
    }

    public void UpdateMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
        currentHealth = maxHealth;
    }


    private void ToggleColor(bool visible)
    {
        characterRenderer.color = new Color(
                characterRenderer.color.r,
                characterRenderer.color.g,
                characterRenderer.color.b,
                (visible ? 1.0f : 0.0f));
    }

}
