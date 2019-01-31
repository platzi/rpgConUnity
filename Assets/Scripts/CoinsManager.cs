using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsManager : MonoBehaviour
{
    public Text moneyText;
    public int currentGold;

    private const string goldkey = "CurrentGold";

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey(goldkey))
        {
            currentGold = PlayerPrefs.GetInt(goldkey);
        }
        else
        {
            currentGold = 0;
            PlayerPrefs.SetInt(goldkey, 0);
        }
        moneyText.text = currentGold.ToString();
    }

    public void AddMoney(int moneyCollected)
    {
        currentGold += moneyCollected;
        PlayerPrefs.SetInt(goldkey, currentGold);
        moneyText.text = currentGold.ToString();
    }
}
