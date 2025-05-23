using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour, IPlayer, IDamageable
{
    [Header("Stats")]
    [SerializeField] private float _maxHealth;

    private float _currentHealth;
    public float CurrentHealth
    {
        get { return _currentHealth; }
        set
        {
            if (value <= 0)
            {
                _currentHealth = 0;

                Dead?.Invoke();
                gameObject.SetActive(false);
                return;
            }

            _currentHealth = value;

            _healthBar.fillAmount = CurrentHealth / _maxHealth;
        }
    }

    [SerializeField] private float _pushRadius;
    [SerializeField] private float _pushForce;

    [SerializeField] private float _delayInvulnerability;
    private float _timeInvulnerability;

    [Header("UI")]
    [SerializeField] private Image _healthBar;

    [SerializeField] private DamageCanvas _damageCanvas;
    [SerializeField] private Vector3 _canvasOffset;

    [Header("GodFinger")]
    [SerializeField] private GodFinger _godFinger;
    [SerializeField][Range(0, 100)] private float _chanceToSpawnGodFinger;
    [SerializeField] private float _radiusSpawn;
    [SerializeField] private float _delayToSpawnGod;
    private float _timeToSpawnGod;

    public Vector3 Position => transform.position;

    [Header("Audio")]
    [SerializeField] private AudioClip _healingClip;
    [SerializeField] private AudioClip _hurtClip;
    private AudioSource _audioSource;

    public UnityAction Dead;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        _currentHealth = _maxHealth;

        _timeToSpawnGod = _delayToSpawnGod;
    }

    private void Update()
    {
        if (_timeInvulnerability > 0)
        {
            _timeInvulnerability -= Time.deltaTime;
        }

        if (_timeToSpawnGod > 0)
        {
            _timeToSpawnGod -= Time.deltaTime * (_maxHealth / _currentHealth);
        }
        else
        {
            SpawnGodFinger();

            _timeToSpawnGod = _delayToSpawnGod;
        }
    }

    public bool TryApplyDamage(float damage)
    {
        if (_timeInvulnerability > 0) return false;

        CurrentHealth -= damage;

        if (CurrentHealth <= 0) return false;

        _audioSource.PlayOneShot(_hurtClip);

        ShowDamage(damage);

        float chance = Random.Range(0, 100);
        if (chance <= _chanceToSpawnGodFinger)
        {
            SpawnGodFinger();
        }

        _timeInvulnerability = _delayInvulnerability;

        return true;
    }

    public void ShowDamage(float damage)
    {
        DamageCanvas damageCanvas = Instantiate(_damageCanvas, transform.position + _canvasOffset, Quaternion.identity);

        StartCoroutine(PushAway());

        damageCanvas.ShowDamage(damage);

        Destroy(damageCanvas.gameObject, 3f);
    }

    private IEnumerator PushAway()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _pushRadius);

        List<Enemy> enemies = new List<Enemy>();

        foreach (Collider2D collider in colliders)
        {
            if (collider == null) continue;

            if (collider.TryGetComponent(out Enemy enemy))
            {
                enemy.IsStopped = true;

                Vector3 direction = enemy.transform.position - transform.position;

                direction = direction.normalized;

                enemy.ApplyForceTo(direction * _pushForce, transform.position);

                enemies.Add(enemy);
            }
        }

        yield return new WaitForSeconds(1);

        foreach (Enemy enemy in enemies)
        {
            if (enemy == null) continue;

            enemy.IsStopped = false;

            enemy.ResetVelocity();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;

        Gizmos.DrawWireSphere(transform.position, _pushRadius);

        Gizmos.color = Color.yellow;

        Gizmos.DrawWireCube(transform.position, Vector3.one * _radiusSpawn);
    }

    private void SpawnGodFinger()
    {
        float x = Random.Range(-1, 1) * _radiusSpawn;
        float y = Random.Range(-1, 1) * _radiusSpawn;

        Vector2 spawnPoint = new Vector2(Position.x + x, Position.y + y);

        Instantiate(_godFinger, spawnPoint, Quaternion.identity);
    }

    public void ApplyHeal(float amount)
    {
        CurrentHealth += amount;

        _audioSource.PlayOneShot(_healingClip);
    }
}