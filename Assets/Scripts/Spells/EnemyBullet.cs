using UnityEngine;

public class EnemyBullet : Bullet
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bullet bullet)) return;

        if (collision.TryGetComponent(out Enemy enemy)) return;

        if (collision.TryGetComponent(out HealingTrap healingTrap)) return;

        if (collision.TryGetComponent(out IPlayer player))
        {
            if (collision.TryGetComponent(out IDamageable damageable))
            {
                damageable.ApplyDamage(_damage);

                SpawnParticle();

                Destroy(gameObject);

                return;
            }
        }

        if (collision.isTrigger)
        {
            SpawnParticle();

            Destroy(gameObject);
        }
    }
}
