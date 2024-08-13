using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

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
