using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject followTarget;
    [SerializeField]
    private Vector3 targetPosition;
    [SerializeField]
    private float cameraSpeed = 4.0f;

    private Camera theCamera;
    private Vector3 minLimits, maxLimits;

    private float halfWidth, halfHeight;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = new Vector3(followTarget.transform.position.x,
                                     followTarget.transform.position.y,
                                    this.transform.position.z);

        this.transform.position = Vector3.Lerp(this.transform.position,
                                              targetPosition,
                                              cameraSpeed * Time.deltaTime);

        float clampX = Mathf.Clamp(this.transform.position.x,
                                minLimits.x + halfWidth,
                                maxLimits.x - halfWidth);
        float clampY = Mathf.Clamp(this.transform.position.y,
                                minLimits.y + halfHeight,
                                maxLimits.y - halfHeight);
        this.transform.position = new Vector3(clampX, clampY,
                             this.transform.position.z);
    }


    public void ChangeLimits(BoxCollider2D newCameraLimits)
    {
        minLimits = newCameraLimits.bounds.min;
        maxLimits = newCameraLimits.bounds.max;

        theCamera = GetComponent<Camera>();
        halfWidth = theCamera.orthographicSize;
        halfHeight = halfWidth / Screen.width * Screen.height;
    }
}
