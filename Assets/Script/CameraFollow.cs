using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void Update()
    {
        if (player.position.x > 30 && player.position.y > -20)
        {
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position
        }
        else if (player.position.x < 30 && player.position.y > -20)
        {
            transform.position = new Vector3(30 + offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position
        }
        else if (player.position.x > 30 && player.position.y < -20)
        {
            transform.position = new Vector3(player.position.x + offset.x, offset.y - 20 , offset.z); // Camera follows the player with specified offset position
        }

    }
}
