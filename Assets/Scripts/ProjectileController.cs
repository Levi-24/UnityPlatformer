using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 15;
    private AudioSource audio;
    private Rigidbody2D rigidbody2d;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        rigidbody2d.AddForce(new Vector2(transform.rotation.z == 0 ? 1 : -1, 0) * projectileSpeed, ForceMode2D.Impulse);
    }

    public void Stop()
    {
        audio.mute = true;
        rigidbody2d.velocity = new(0, 0);
    }
}
