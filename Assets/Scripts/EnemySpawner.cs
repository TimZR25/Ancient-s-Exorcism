using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _zombiePrefab;

    private List<Enemy> _enemyList = new List<Enemy>();

    private IPLayer _player;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    public void Inject(IPLayer pLayer)
    {
        _player = pLayer;
    }

    private IEnumerator Spawn()
    {
        Enemy enemy = Instantiate(_zombiePrefab, transform.position, Quaternion.identity);

        enemy.Inject(_player);

        _enemyList.Add(enemy);

        yield return new WaitForSeconds(10f);

        StartCoroutine(Spawn());
    }
}
