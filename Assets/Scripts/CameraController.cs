using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(0, 12, -12);
   
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
