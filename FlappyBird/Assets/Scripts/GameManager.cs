using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// The shared brain for game state. Tracks whether the run has started and whether
/// it's over; shows/hides the start prompt and the score board; handles restart.
/// </summary>
public class GameManager : MonoBehaviour
{
    // A single easy-to-reach reference so other scripts don't need Inspector wiring.
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject _startPanel; // "Click or Press Space to Start"
    [SerializeField] private GameObject _gameOverPanel; // score board, shown on game over
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _gameOverScoreText;
    [SerializeField] private Button _playAgainButton;
    [SerializeField] private Button _quitButton;
    
    private int _currentScore;
    private const int _startingScore = 0;

    public bool HasStarted { get; private set; }
    public bool IsGameOver { get; private set; }

    private void Awake()
    {
        Instance = this;
        
        _currentScore = _startingScore;
    }

    private void Start()
    {
        // Show the start prompt, hide the score board, and hook up Play Again.
        if (_startPanel != null)
            _startPanel.SetActive(true);

        if (_gameOverPanel != null)
            _gameOverPanel.SetActive(false);

        if (_playAgainButton != null)
            _playAgainButton.onClick.AddListener(RestartGame);
        
        if (_quitButton != null)
            _quitButton.onClick.AddListener(QuitGame);
        
        UpdateScore(_startingScore);
    }

    public void StartGame()
    {
        HasStarted = true;

        // The run has begun — hide the prompt.
        if (_startPanel != null)
            _startPanel.SetActive(false);
    }

    public void GameOver()
    {
        if (IsGameOver) return;   // only fire once

        IsGameOver = true;

        // Show the score board (with its Play Again button).
        if (_gameOverPanel != null)
            _gameOverPanel.SetActive(true);
        
        UpdateScore(_startingScore);
    }

    public void RestartGame()
    {
        // Reload the whole scene — the simplest, cleanest reset back to the ready state.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void UpdateScore(int score)
    {
        _currentScore += score;
        _scoreText.text = _currentScore.ToString();
        _gameOverScoreText.text = _currentScore.ToString();
    }
}
