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

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.layer == LayerMask.NameToLayer("Hitable"))
        {
            projectileController.Stop();
            Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (target.CompareTag("Enemy"))
        {
            EnemyHealth enemyhealth = target.gameObject.GetComponent<EnemyHealth>();
            enemyhealth.takeDamage(damage);
        }
    }
}
