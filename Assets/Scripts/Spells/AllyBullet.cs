using UnityEngine;

public class AllyBullet : Bullet
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bullet bullet)) return;

        if (collision.TryGetComponent(out IDamageable damageable))
        {
            damageable.ApplyDamage(_damage);

            SpawnParticle();

            Destroy(gameObject);
        }

        if (collision.isTrigger)
        {
            SpawnParticle();

            Destroy(gameObject);
        }
    }
}
