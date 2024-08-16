using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour, IDamageable
{
    [SerializeField] private Enemy _zombiePrefab;

    private List<Enemy> _enemyList = new List<Enemy>();

    private IPlayer _player;

    [SerializeField] private float _maxHealth;

    private float _currentHealth;
    public float CurrentHealth
    {
        get { return _currentHealth; }
        set
        {
            if (_currentHealth + value <= 0)
            {
                _currentHealth = 0;

                Destroy(gameObject);
                return;
            }

            _currentHealth = value;

            _image.fillAmount = _currentHealth / _maxHealth;
        }
    }

    [SerializeField] private DamageCanvas _damageCanvas;

    [SerializeField] private Image _image;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    public void Inject(IPlayer pLayer)
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

    public void ApplyDamage(float damage)
    {
        CurrentHealth -= damage;
        ShowDamage(damage);
    }

    public void ShowDamage(float damage)
    {
        if (_image.gameObject.activeSelf == false)
        {
            _image.gameObject.SetActive(true);
        }

        DamageCanvas damageCanvas = Instantiate(_damageCanvas, transform.position, Quaternion.identity);
        damageCanvas.ShowDamage(damage);

        Destroy(damageCanvas.gameObject, 3f);
    }
}
