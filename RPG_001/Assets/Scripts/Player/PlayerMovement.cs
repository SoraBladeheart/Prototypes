using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 4f;
    [SerializeField] private float runSpeed = 8f;

    private Rigidbody2D _rb;
    private Vector2 _moveDir;
    private PlayerState _state;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void ApplyState(Vector2 move, PlayerState state)
    {
        _moveDir = move;
        _state = state;
    }

    private void FixedUpdate()
    {
        switch (_state)
        {
            case PlayerState.Run:
                Move(runSpeed);
                break;

            case PlayerState.Walk:
                Move(walkSpeed);
                break;

            default:
                Move(0f); // Idle or non-movement states
                break;
        }
    }

    private void Move(float speed)
    {
        _rb.linearVelocity = _moveDir * speed;
    }
}