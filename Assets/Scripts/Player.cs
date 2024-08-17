using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, IPlayer, IDamageable
{
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

                Debug.Log("Player is Dead");
                return;
            }

            _currentHealth = value;
        }
    }

    [SerializeField] private float _pushRadius;
    [SerializeField] private float _pushForce;

    [SerializeField] private DamageCanvas _damageCanvas;
    [SerializeField] private Vector3 _canvasOffset;

    public Vector3 Position => transform.position;

    [SerializeField] private Image _healthBar;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void ApplyDamage(float damage)
    {
        CurrentHealth -= damage;

        _healthBar.fillAmount = CurrentHealth/_maxHealth;

        if (CurrentHealth <= 0) return;
        ShowDamage(damage);
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
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(transform.position, _pushRadius);
    }
}