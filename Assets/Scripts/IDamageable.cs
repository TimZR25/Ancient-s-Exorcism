public interface IDamageable
{
    float CurrentHealth { get; set; }
    bool TryApplyDamage(float damage);
    void ShowDamage(float damage);
}
