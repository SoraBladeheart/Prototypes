using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimatorController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    private Animator _animator;
    private float _lastFaceX = 1f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void UpdateAnimation(Vector2 move, PlayerState state)
    {
        // -----------------------------
        // Facing / Sprite flipping
        // -----------------------------
        if (move.x > 0.01f) _lastFaceX = 1f;
        else if (move.x < -0.01f) _lastFaceX = -1f;

        spriteRenderer.flipX = _lastFaceX < 0;

        // -----------------------------
        // Movement blend (Idle/Walk/Run)
        // -----------------------------
        _animator.SetFloat("Speed", move.sqrMagnitude);

        // -----------------------------
        // Continuous states (bools)
        // -----------------------------
        _animator.SetBool("IsRunning", state == PlayerState.Run);
    }
}