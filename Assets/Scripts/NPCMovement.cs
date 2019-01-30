using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public float speed = 1.5f;
    private Rigidbody2D npcRigidbody;

    public bool isWalking;

    public float walkTime = 1.5f;
    private float walkCounter;

    public float waitTime = 3.0f;
    private float waitCounter;

    private Vector2[] walkingDirection =
    {
        new Vector2(1,0),
        new Vector2(0,1),
        new Vector2(-1,0),
        new Vector2(0,-1)
    };

    private int currentDirection;

    public BoxCollider2D villagerZone;

    // Start is called before the first frame update
    void Start()
    {
        npcRigidbody = GetComponent<Rigidbody2D>();
        waitCounter = waitTime;
        walkCounter = walkTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking)
        {
            if(villagerZone != null)
            {
                if(this.transform.position.x < villagerZone.bounds.min.x ||
                   this.transform.position.x > villagerZone.bounds.max.x ||
                   this.transform.position.y < villagerZone.bounds.min.y ||
                   this.transform.position.y > villagerZone.bounds.max.y)
                {
                    StopWalking();
                }
            }



            npcRigidbody.velocity = walkingDirection[currentDirection] * speed;

            walkCounter -= Time.deltaTime;
            if (walkCounter < 0)
            {
                StopWalking();
            }
        }
        else
        {
            npcRigidbody.velocity = Vector2.zero;

            waitCounter -= Time.deltaTime;
            if (waitCounter < 0)
            {
                StartWalking();
            }
        }
    }

    private void StartWalking()
    {
        isWalking = true;
        currentDirection = Random.Range(0, 4);
        walkCounter = walkTime;
    }

    private void StopWalking()
    {
        isWalking = false;
        waitCounter = waitTime;
        npcRigidbody.velocity = Vector2.zero;
    }
}
