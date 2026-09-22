using UnityEngine;

/// <summary>
/// Moves a pipe steadily to the left, deletes it once off-screen, and freezes
/// the moment the run ends.
/// </summary>
public class PipeMover : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _destroyX = -12f;

    private void Update()
    {
        // Stop scrolling as soon as the game's over.
        if (GameManager.Instance.IsGameOver)
            return;

        transform.position += Vector3.left * (_speed * Time.deltaTime);

        if (transform.position.x < _destroyX)
            Destroy(gameObject);
    }
}
