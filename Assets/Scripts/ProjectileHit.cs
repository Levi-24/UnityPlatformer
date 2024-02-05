using UnityEngine;

public class ProjectileHit : MonoBehaviour
{
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private float damage = 1f;

    private ProjectileController projectileController;

    private void Awake()
    {
        projectileController = GetComponentInParent<ProjectileController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Destroyable"))
        {
            projectileController.Stop();
            Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
