using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;
    public Transform cameraLimits;

    public static FollowCamera instance;

    [Range(-150,150)]
    public float minModX, maxModX, minModY, maxModY;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }    
    }

    // Update is called once per frame
    void Update()
    {
        var minPosY = cameraLimits.GetComponent<BoxCollider2D>().bounds.min.y + minModY;
        var maxPosY = cameraLimits.GetComponent<BoxCollider2D>().bounds.max.y + maxModY;
        var minPosX = cameraLimits.GetComponent<BoxCollider2D>().bounds.min.x + minModX;
        var maxPosX = cameraLimits.GetComponent<BoxCollider2D>().bounds.max.x + maxModX;

        Vector3 clampedPos = new Vector3
        (
            Mathf.Clamp(player.position.x, minPosX, maxPosX),
            Mathf.Clamp(player.position.y, minPosY, maxPosY),
            Mathf.Clamp(player.position.z, -65f, -65f)
        );

        transform.position = new Vector3(clampedPos.x, clampedPos.y, clampedPos.z);
    }
}
