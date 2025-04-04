using UnityEngine;

public class GodFinger : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;

    [SerializeField] private GodMiracle _godMiracle;

    public void SpawnHealingTrap()
    {
        Instantiate(_godMiracle, _spawnPoint.position, Quaternion.identity);

        Destroy(gameObject, 1f);
    }
}
