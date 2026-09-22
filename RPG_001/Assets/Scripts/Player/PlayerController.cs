using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerAnimatorController))]
public class PlayerController : MonoBehaviour
{
    private PlayerInput _input;
    private PlayerMovement _movement;
    private PlayerAnimatorController _anim;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _movement = GetComponent<PlayerMovement>();
        _anim = GetComponent<PlayerAnimatorController>();
    }

    private void Update()
    {
        PlayerState state = DetermineState();
        _movement.ApplyState(_input.Move, state);
        _anim.UpdateAnimation(_input.Move, state);
    }

    private PlayerState DetermineState()
    {
        // Movement states
        bool isMoving = _input.Move.sqrMagnitude > 0.1f; 
        if (isMoving)
        {
            if (_input.Run) 
                return PlayerState.Run;
            return PlayerState.Walk;
        }

        return PlayerState.Idle;
    }
}
