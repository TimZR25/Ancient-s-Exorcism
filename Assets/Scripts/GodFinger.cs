using UnityEngine;

public class GodFinger : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;

    [SerializeField] private HealingTrap _healingTrap;

    public void SpawnHealingTrap()
    {
        Instantiate(_healingTrap, _spawnPoint.position, Quaternion.identity);

        Destroy(gameObject, 1f);
    }
}
