using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// The bird. Hovers at the start (gravity off); the first tap turns gravity on and
/// begins the run; every tap flaps it upward; touching anything solid ends the run.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class Bird : MonoBehaviour
{
    [SerializeField] private float _flapForce = 6f;

    private Rigidbody2D _rb;
    private float _gravityScale;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        // Remember the Gravity Scale set on the Rigidbody2D so we can hold it at 0 now
        // and restore YOUR value on the first tap. (Tune gravity on the Rigidbody.)
        _gravityScale = _rb.gravityScale;
    }

    private void Start()
    {
        _rb.gravityScale = 0f;   // hover in place until the first tap
    }

    private void Update()
    {
        // A dead bird doesn't flap.
        if (GameManager.Instance.IsGameOver)
            return;

        if (!FlapPressed())
            return;

        if (!GameManager.Instance.HasStarted)
            BeginGame();

        Flap();
    }

    private void BeginGame()
    {
        _rb.gravityScale = _gravityScale;   // physics kicks in
        GameManager.Instance.StartGame();   // wake the pipes
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Touched a pipe or the ground → crash.
        GameManager.Instance.GameOver();

        // Freeze the bird right where it hit.
        _rb.linearVelocity = Vector2.zero;
        _rb.simulated = false;
    }

    private bool FlapPressed()
    {
        // Pointer.current covers BOTH mouse click and touch (PC + mobile).
        bool space = Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame;
        bool tap = Pointer.current != null && Pointer.current.press.wasPressedThisFrame;
        return space || tap;
    }

    private void Flap()
    {
        // Cancel the current fall, then pop upward — the snappy Flappy feel.
        _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _flapForce);
    }
}
