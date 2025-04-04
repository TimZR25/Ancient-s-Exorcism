using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Time.deltaTime <= 0) return;

        FlipToMouse();
    }

    private void FlipToMouse()
    {
        Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        mousePosition.Normalize();


        float rotateZ = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;

        if (rotateZ > -90 && rotateZ < 90)
        {
            _spriteRenderer.flipX = false;

        }
        else
        {
            _spriteRenderer.flipX = true;
        }
    }

    public void PlayAnimation(string animationName)
    {
        _animator.Play(animationName);
    }

    public struct AnimationNames
    {
        public const string PlayerIdle = "A_PlayerIdle";
        public const string PlayerMove = "A_PlayerMove";
    }
}
