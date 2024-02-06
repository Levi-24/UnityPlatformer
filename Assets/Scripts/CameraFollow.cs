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
        if (isFacingRight != target.localScale.x > 0)
        {
            isFacingRight = target.localScale.x > 0;
            offset.x += target.localScale.x > 0 ? 15f : -15;
        }

        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, delay * Time.deltaTime);

        if (transform.position.y < lowY)
        {
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        }
    }
}
