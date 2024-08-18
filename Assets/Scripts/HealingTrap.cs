using UnityEngine;

public class HealingTrap : MonoBehaviour
{
    [SerializeField] private float _healAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IPlayer player))
        {
            player.ApplyHeal(_healAmount);

            Destroy(gameObject);
        }
    }
}
