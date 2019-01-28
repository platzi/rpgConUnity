using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{

    private PlayerController thePlayer;
    private CameraFollow theCamera;
    public Vector2 facingDirection = Vector2.zero;

    public string placeName;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        theCamera = FindObjectOfType<CameraFollow>();

        if (!thePlayer.nextPlaceName.Equals(placeName))
        {
            return;
        }


        thePlayer.transform.position = this.transform.position;
        theCamera.transform.position = new Vector3(
                this.transform.position.x,
                this.transform.position.y,
                theCamera.transform.position.z
            );

        thePlayer.lastMovement = facingDirection;
    }

}
