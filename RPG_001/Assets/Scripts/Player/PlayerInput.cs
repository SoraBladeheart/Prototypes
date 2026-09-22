using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerControls _controls;

    public Vector2 Move { get; private set; }
    public bool Run  { get; private set; }

    private void Awake()
    {
        _controls = new PlayerControls();
    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    private void Update()
    {
        // Movement (Vector2)
        Move = _controls.Player.Move.ReadValue<Vector2>();
        
        // Continuous actions (Bools)
        Run = _controls.Player.Run.IsPressed();
    }
}