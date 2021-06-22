using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform target;
    
    public Vector3 offset;

    private void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        transform.position = new Vector3(target.position.x + offset.x, target.position.y + offset.y, offset.z);
    }
}
