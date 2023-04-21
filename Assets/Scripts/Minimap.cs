using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform player;
    public Transform playerInner;


    private void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f, playerInner.eulerAngles.y, 0f);
    }
}
