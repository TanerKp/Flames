public interface IDamageable
{
    int CurrentHealth { get; }
    void ApplyDamage(int damage);
}