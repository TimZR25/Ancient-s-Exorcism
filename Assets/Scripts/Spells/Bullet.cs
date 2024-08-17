using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public abstract class Bullet : MonoBehaviour
{
    [SerializeField] private ParticleSystem _hitParticle;

    private Rigidbody2D _rigidbody;

    protected float _damage;

    public void Inject(float damage)
    {
        _damage = damage;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void MoveTo(Vector3 target, float speed)
    {
        float rotateZ = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotateZ);

        _rigidbody.linearVelocity = transform.right * speed;
    }

    protected void SpawnParticle()
    {
        ParticleSystem particle = Instantiate(_hitParticle, transform.position, _hitParticle.transform.rotation);

        Destroy(particle.gameObject, particle.main.duration);
    }

    
}