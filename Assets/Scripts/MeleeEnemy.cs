using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField] private bool _isOneTouched = false;

    protected override void ApplyBodyDamage(IDamageable damageable)
    {
        if (damageable.TryApplyDamage(_bodyDamage))
        {
            if (_isOneTouched)
            {
                Destroy(gameObject);
            }
        }
    }
}
