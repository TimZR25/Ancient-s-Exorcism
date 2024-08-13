using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _zombiePrefab;

    private List<Enemy> _enemyList = new List<Enemy>();

    private IPLayer _player;

    public void Inject(IPLayer pLayer)
    {
        _player = pLayer;
    }

    private void Spawn()
    {
        Enemy enemy = Instantiate(_zombiePrefab, transform.position, Quaternion.identity);

        enemy.Inject(_player);

        _enemyList.Add(enemy);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Spawn();
        }
    }
}
