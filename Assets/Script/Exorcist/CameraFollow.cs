using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void Update()
    {
        if (player == null)
        {
            player = GameObject.Find("Exorcist").transform;
        }
        if(player)
        {
            // if (player.position.x > 10 && player.position.y > -62)
            // {
                transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position
            // }
            // else if (player.position.x < 10 && player.position.y > -62)
            // {
            //     transform.position = new Vector3(10 + offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position
            // }
            // else if (player.position.x > 10 && player.position.y < -62)
            // {
            //     transform.position = new Vector3(player.position.x + offset.x, offset.y - 62, offset.z); // Camera follows the player with specified offset position
            // }
        }
       
    }
}
