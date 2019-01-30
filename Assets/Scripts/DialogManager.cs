using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public bool dialogActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogActive && Input.GetKeyDown(KeyCode.Space))
        {
            dialogActive = false;
            dialogBox.SetActive(false);
        }
    }

    public void ShowDialog(string text)
    {
        dialogActive = true;
        dialogBox.SetActive(true);
        dialogText.text = text;
    }
}
