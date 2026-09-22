using UnityEngine;

/// <summary>
/// Spawns pipe prefabs at a random height once the run has started, and stops
/// when it's over. The first pipe fires the instant the game begins.
/// </summary>
public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _pipePrefab;
    [SerializeField] private float _spawnInterval = 1.5f;
    [SerializeField] private float _spawnX = 8f;    // just off the right edge
    [SerializeField] private float _minY = -2f;
    [SerializeField] private float _maxY = 2f;

    private float _timer;

    private void Awake()
    {
        // Pre-load so the FIRST pipe fires the instant the game starts.
        _timer = _spawnInterval;
    }

    private void Update()
    {
        // Wait for the first tap, and stop once the run is over.
        if (!GameManager.Instance.HasStarted || GameManager.Instance.IsGameOver)
            return;

        _timer += Time.deltaTime;
        if (_timer >= _spawnInterval)
        {
            _timer = 0f;
            Spawn();
        }
    }

    private void Spawn()
    {
        // Random vertical position → the gap lands somewhere different every time.
        float y = Random.Range(_minY, _maxY);
        Instantiate(_pipePrefab, new Vector3(_spawnX, y, 0f), Quaternion.identity);
    }
}
