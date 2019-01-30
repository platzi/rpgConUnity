using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    public string[] dialog;
    private DialogManager manager;
    private bool playerInTheZone;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<DialogManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            playerInTheZone = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (playerInTheZone && Input.GetKeyDown(KeyCode.Return))
        {
            manager.ShowDialog(dialog);
            if (gameObject.GetComponentInParent<NPCMovement>() != null)
            {
                gameObject.GetComponentInParent<NPCMovement>().isTalking = true;
            }
        }
    }
}
