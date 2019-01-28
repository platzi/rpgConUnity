using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{

    public float timeToRevivePlayer;
    private float timeRevivalCounter;
    private bool playerReviving;

    private GameObject thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerReviving)
        {
            timeRevivalCounter -= Time.deltaTime;
            if (timeRevivalCounter < 0)
            {
                playerReviving = false;
                thePlayer.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            //Colision entre enemigo y jugador
            collision.gameObject.SetActive(false);
            playerReviving = true;
            timeRevivalCounter = timeToRevivePlayer;
            thePlayer = collision.gameObject;
        }
    }
}
