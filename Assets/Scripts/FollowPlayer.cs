using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    private void Update()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 cameraPos = transform.position;
        
        transform.position = new Vector3(
            playerPos.x,
            playerPos.y,
            cameraPos.z
        );
    } 
}
