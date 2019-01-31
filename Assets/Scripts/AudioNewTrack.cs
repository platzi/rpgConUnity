using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioNewTrack : MonoBehaviour
{

    private AudioManager manager;
    public int newTrackID;
    public bool playOnStart;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<AudioManager>();
        if (playOnStart)
        {
            manager.PlayNewTrack(newTrackID);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            manager.PlayNewTrack(newTrackID);
            gameObject.SetActive(false);
        }
    }
}
