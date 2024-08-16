public interface IDamageable
{
    float CurrentHealth { get; set; }
    void ApplyDamage(float damage);
    void ShowDamage(float damage);
}
