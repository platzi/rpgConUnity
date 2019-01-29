using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class UIManager : MonoBehaviour
{
    public Slider playerHealthBar;
    public Text playerHealthText;


    public HealthManager playerHealthManager;


    // Update is called once per frame
    void Update()
    {
        //Por si subimos de nivel
        playerHealthBar.maxValue = playerHealthManager.maxHealth;
        playerHealthBar.value = playerHealthManager.currentHealth;

        StringBuilder sb = new StringBuilder("HP: ");
        sb.Append(playerHealthManager.currentHealth);
        sb.Append("/");
        sb.Append(playerHealthManager.maxHealth);
        playerHealthText.text = sb.ToString();
    }
}
