using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Player _player;

    private EnemySpawner[] _enemySpawners;

    private void Awake()
    {
        _enemySpawners = FindObjectsByType<EnemySpawner>(FindObjectsSortMode.None);

        foreach (EnemySpawner enemySpawner in _enemySpawners)
        {
            enemySpawner.Inject(_player);
        }
    }
}
