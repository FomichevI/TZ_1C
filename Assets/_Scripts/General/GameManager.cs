using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    private GameplayConfig _gameplayConfig;
    private SessionConfig _sessionConfig;

    [Inject]
    private void Construct(GameplayConfig gameplayConfig, SessionConfig sessionConfig)
    {
        _gameplayConfig = gameplayConfig;
        _sessionConfig = sessionConfig;
    }

    private void OnEnable()
    {
        GlobalSignals.OnFigureDetonate.AddListener(OnFigureDetonate);
        GlobalSignals.OnFigureCollected.AddListener(OnFigureCollected);
        GlobalSignals.OnRestartLevel.AddListener(RestartLevel);
    }

    private void Start()
    {
        RestartLevel();
    }

    private void StopGame()
    {
        _sessionConfig.StopGame();
    }

    private void RestartLevel()
    {
        InitSessionConfig();
        _sessionConfig.ContinueGame();
        GlobalSignals.OnLevelStarted?.Invoke();
    }

    private void InitSessionConfig()
    {
        _sessionConfig.Initialize(_gameplayConfig.GetTargetFuguresCount(), _gameplayConfig.StartHitPoints);
    }

    private void OnFigureDetonate()
    {
        _sessionConfig.ReduseHitPoints();
        if (_sessionConfig.HitPoints <= 0)
        {
            StopGame();
            GlobalSignals.OnLoseLevel?.Invoke();
        }
    }

    private void OnFigureCollected()
    {
        _sessionConfig.CollectFigure();
        if (_sessionConfig.CurrentFiguresCollected >= _sessionConfig.TargetFiguresCount)
        {
            StopGame();
            GlobalSignals.OnWinLevel?.Invoke();
        }
    }

    private void OnDisable()
    {
        GlobalSignals.OnFigureDetonate.RemoveListener(OnFigureDetonate);
        GlobalSignals.OnFigureCollected.RemoveListener(OnFigureCollected);
        GlobalSignals.OnRestartLevel.RemoveListener(RestartLevel);
    }
}
