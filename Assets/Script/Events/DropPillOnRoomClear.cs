using UnityEngine;

public class DropPillOnRoomClear : MonoBehaviour
{
    public GameObject pill;
    private bool pillDropped;

    private void Start()
    {
        pillDropped = false;
    }
    void Update()
    {
        if (!pillDropped && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            DropPillBetweenPortals();
        }
    }

    void DropPillBetweenPortals()
    {
        var nextPortalPos = GameObject.FindGameObjectWithTag("NextPortal").transform.position;
        var previousPortalPos = GameObject.FindGameObjectWithTag("PreviousPortal").transform.position;

        var yBetween2Portals = (previousPortalPos.y + nextPortalPos.y) / 2;
        var dropPosition = new Vector3(nextPortalPos.x, yBetween2Portals, 0f);
        Instantiate(pill, dropPosition, new Quaternion(0f, 0f, 0f, 0f));

        pillDropped = true;
    }
}
