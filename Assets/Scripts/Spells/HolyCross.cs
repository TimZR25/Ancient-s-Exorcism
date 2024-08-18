using UnityEngine;

public class HolyCross : Spell
{
    [SerializeField] private Transform _firePoint;

    [SerializeField] private Bullet _bullet;

    [SerializeField] private float _speed;
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    [SerializeField] private float _damage;
    public float Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    [SerializeField] private float _castDelay;

    private float _delayTime = 0;

    private bool _isCooldown = false;

    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (_delayTime > 0)
        {
            _delayTime -= Time.deltaTime;
        }
        else
        {
            _isCooldown = false;
        }
    }

    public override bool TryCast()
    {
        if (_isCooldown == true) return false;

        Bullet bullet = Instantiate(_bullet, _firePoint.position, _firePoint.rotation);

        bullet.Inject(_damage);

        Vector3 cursorPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        bullet.MoveTo(cursorPosition, _speed);

        Destroy(bullet.gameObject, 3f);

        _delayTime = _castDelay;
        _isCooldown = true;

        return true;
    }
}