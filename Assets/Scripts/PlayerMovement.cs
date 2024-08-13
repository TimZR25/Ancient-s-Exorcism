using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference _inputMove;

    [SerializeField] private float _moveSpeed;

    [SerializeField] private PlayerAnimator _playerAnimator;

    private Rigidbody2D _rigidbody;

    private Vector2 _moveDirection;

    private bool IsMoving => _moveDirection != Vector2.zero;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _moveDirection = _inputMove.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        if (IsMoving)
        {
            Move();
            return;
        }

        Idle();
    }

    private void Move()
    {
        _playerAnimator.PlayAnimation(PlayerAnimator.AnimationNames.PlayerMove);

        _rigidbody.linearVelocity = _moveDirection * _moveSpeed;

        transform.localScale = _moveDirection.x > 0
            ? new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y)
            : new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
    }

    private void Idle()
    {
        _rigidbody.linearVelocity = Vector2.zero;

        _playerAnimator.PlayAnimation(PlayerAnimator.AnimationNames.PlayerIdle);
    }
}
