using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerControll : MonoBehaviour
{
    public Transform player;
    public float cameraLevel = -10.00f; // -10 default
    // public float xOffset;
    // public float yOffset;
    // public float zOffset;
 
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, cameraLevel);  //every frame moves camera to match player position
    }
}
