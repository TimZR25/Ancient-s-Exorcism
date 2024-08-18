using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Rigidbody2D))]
public abstract class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private DamageCanvas _damageCanvas;

    [SerializeField] private float _bodyDamage;

    private float _currentHealth;
    public float CurrentHealth
    {
        get { return _currentHealth; }
        set
        {
            if (value <= 0)
            {
                _currentHealth = 0;

                Destroy(gameObject);
                return;
            }

            _currentHealth = value;
        }
    }

    protected NavMeshAgent _agent;

    public bool IsStopped
    {
        get => _agent.isStopped;
        set
        {
            _agent.isStopped = value;
        }
    }

    private Rigidbody2D _rigidbody;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    private AudioSource _audioSource;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();

        _rigidbody = GetComponent<Rigidbody2D>();

        _audioSource = GetComponent<AudioSource>();

        _agent.updateRotation = false;
        _agent.updateUpAxis = false;

        _currentHealth = _maxHealth;
    }

    protected Player _player;

    public void Inject(Player player)
    {
        _player = player;
    }

    private void FixedUpdate()
    {
        if (_player is null) return;

        _agent.SetDestination(_player.Position);


        FlipToTarget(_player.Position);
    }

    private void FlipToTarget(Vector3 target)
    {
        Vector3 direction = target - transform.position;
        direction.Normalize();


        float rotateZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (rotateZ > -90 && rotateZ < 90)
        {
            _spriteRenderer.flipX = false;

        }
        else
        {
            _spriteRenderer.flipX = true;
        }
    }

    public void ApplyDamage(float damage)
    {
        _spriteRenderer.material.SetColor("_DamageColor", Color.gray);

        _audioSource.Play();

        CurrentHealth -= damage;
        ShowDamage(damage);

        Invoke(nameof(ChangeColor), 0.1f);
    }

    private void ChangeColor()
    {
        _spriteRenderer.material.SetColor("_DamageColor", Color.black);
    }

    public void ShowDamage(float damage)
    {
        DamageCanvas damageCanvas = Instantiate(_damageCanvas, transform.position, Quaternion.identity);
        damageCanvas.ShowDamage(damage);

        Destroy(damageCanvas.gameObject, 3f);
    }

    public void ResetVelocity()
    {
        _rigidbody.linearVelocity = Vector3.zero;
    }

    public void ApplyForceTo(Vector3 to, Vector3 from)
    {
        _rigidbody.linearVelocity = Vector3.zero;

        _rigidbody.AddForceAtPosition(to, from, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IPlayer player))
        {
            if (collision.TryGetComponent(out IDamageable damageable))
            {
                damageable.ApplyDamage(_bodyDamage);
            }
        }
    }
}
