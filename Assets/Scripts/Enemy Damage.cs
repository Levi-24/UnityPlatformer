using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private float damageRate = 1f;
    [SerializeField] private float damage = 2;
    [SerializeField] private float pushForce = 20f;

    private float nextDamage;

    private void Start()
    {
        nextDamage = 0f;
    }

    private void OnTriggerStay2D(Collider2D player)
    {
        if (player.CompareTag("Player") && nextDamage < Time.time)
        {
            PlayerHealth playerHealth = player.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);
            nextDamage = Time.time + damageRate;
            PushBack(player.transform);
        }
    }

    private void PushBack(Transform player)
    {
        Rigidbody2D playerRb = player.gameObject.GetComponent<Rigidbody2D>();
        playerRb.velocity = Vector2.zero;
        playerRb.AddForce(new Vector2(0,1) * pushForce, ForceMode2D.Impulse);
    }
}
