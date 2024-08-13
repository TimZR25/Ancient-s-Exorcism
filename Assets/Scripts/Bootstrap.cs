using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private EnemySpawner _enemySpawner;

    private void Awake()
    {
        _enemySpawner.Inject(_player);
    }
}
