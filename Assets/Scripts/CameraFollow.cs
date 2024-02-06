using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float delay;

    private Vector3 offset;
    private float lowY;
    private bool isFacingRight;

    private void Start()
    {
        offset = transform.position - target.position;
        lowY = transform.position.y;
        isFacingRight = true;
    }

    private void FixedUpdate()
    {
        isFacingRight = target.localScale.x > 0;
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, delay * Time.deltaTime);

        if (transform.position.y < lowY)
        {
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        }
    }
}
