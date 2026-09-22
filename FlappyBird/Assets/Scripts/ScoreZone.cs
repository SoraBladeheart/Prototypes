using UnityEngine;

/// <summary>
/// An invisible trigger sitting in a pipe's gap. When the bird passes through it,
/// it scores one point — then locks itself so a single pipe can't score twice.
/// Lives as a child of the Pipe prefab, so it moves and dies with its pipe.
/// </summary>
public class ScoreZone : MonoBehaviour
{
    private bool _scored;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_scored) return;

        // Only the bird scores. Checking for the Bird component means we don't
        // depend on tags — anything else that wanders in is ignored.
        if (other.GetComponent<Bird>() == null) return;

        _scored = true;
        GameManager.Instance.UpdateScore(1);
    }
}
