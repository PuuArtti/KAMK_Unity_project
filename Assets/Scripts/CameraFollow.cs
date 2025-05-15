using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothingSpeed = 0.125f;
    public Vector3 offset;
    public float minY = -5f;
    public float maxY = 5f;


    private void FixedUpdate()
    {
        //Calculate position
        Vector3 desiredPosition = player.position + offset;

        //Clamp following to the X only
        desiredPosition = new Vector3 (desiredPosition.x, Mathf.Clamp(desiredPosition.y, minY, maxY), desiredPosition.z);

        //Smooth the camera movement
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothingSpeed);

        //Move the camera
        transform.position = smoothedPosition;


    }

}
