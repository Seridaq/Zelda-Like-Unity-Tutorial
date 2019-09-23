using System.Collections;
using UnityEngine;
using UnityEngine.U2D;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;

    private Camera thisCameraComponent;
    private float halfHeight, halfWidth;

    // Start is called before the first frame update
    void Start()
    {
        thisCameraComponent = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        halfHeight = thisCameraComponent.orthographicSize;
        halfWidth = halfHeight * thisCameraComponent.aspect;

        if (transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x + halfWidth, maxPosition.x - halfWidth);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y + halfHeight, maxPosition.y - halfHeight);

            transform.position = Vector3.Lerp(transform.position,
                                              targetPosition, smoothing);
        }
    }
}
