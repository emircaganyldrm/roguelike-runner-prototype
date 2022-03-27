using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    public Transform player;
    private void FixedUpdate()
    {
        transform.position = transform.forward * player.position.z;
    }
}
