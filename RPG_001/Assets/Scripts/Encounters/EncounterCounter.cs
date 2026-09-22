using UnityEngine;

public class EncounterCounter : MonoBehaviour
{
    [SerializeField] private float stepLength = 1f;
    [SerializeField] private int minSteps = 20;
    [SerializeField] private int maxSteps = 40;

    private Vector2 _lastPosition;
    private float _distance;
    private int _steps;
    private int _stepsUntilEncounter;

    private void Start()
    {
        _lastPosition = transform.position;

        ResetEncounter();
    }

    private void Update()
    {
        Vector2 currentPosition = transform.position;

        _distance += Vector2.Distance(_lastPosition, currentPosition);
        _lastPosition = currentPosition;
        
        while(_distance >= stepLength)
        {
            _distance -= stepLength;
            _steps++;
            if (_steps >= _stepsUntilEncounter)
                TriggerEncounter();
        }
    }

    private void ResetEncounter()
    {
        _steps = 0;
        _stepsUntilEncounter = Random.Range(minSteps, maxSteps + 1);
    }

    private void TriggerEncounter()
    {
        Debug.Log($"Battle! after {_steps} steps");
        ResetEncounter();
    }
}
