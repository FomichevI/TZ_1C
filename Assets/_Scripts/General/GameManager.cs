
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    private GameplayConfig _gameplayConfig;
    private SessionConfig _sessionConfig;
    private List<ISlidingObject> _activeFigures = new List<ISlidingObject>();

    [Inject]
    private void Construct(GameplayConfig gameplayConfig, SessionConfig sessionConfig)
    {
        _gameplayConfig = gameplayConfig;
        _sessionConfig = sessionConfig;
    }

    private void OnEnable()
    {
        GlobalSignals.OnFigureSpawn.AddListener(OnFigureSpawn);
        GlobalSignals.OnFigureDestroy.AddListener(OnFigureDestroy);
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
        _activeFigures.Clear();
        InitSessionConfig();
        _sessionConfig.ContinueGame();
        GlobalSignals.OnLevelStarted?.Invoke();
    }

    private void InitSessionConfig()
    {
        _sessionConfig.Initialize(_gameplayConfig.GetTargetFuguresCount(), _gameplayConfig.StartHitPoints);
    }

    private void OnFigureSpawn(ISlidingObject slidingObject)
    {
        _activeFigures.Add(slidingObject);
        _sessionConfig.RiseSpawnedFiguresCount();
    }

    private void OnFigureDestroy(ISlidingObject slidingObject)
    {
        _activeFigures.Remove(slidingObject);

        if (_sessionConfig.SpawnedFiguresCount >= _sessionConfig.TargetFiguresCount &&
            _activeFigures.Count == 0 && _sessionConfig.HitPoints > 0)
        {
            StopGame();
            GlobalSignals.OnWinLevel?.Invoke();
        }
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
    }

    private void OnDisable()
    {
        GlobalSignals.OnFigureDetonate.RemoveListener(OnFigureDetonate);
        GlobalSignals.OnFigureCollected.RemoveListener(OnFigureCollected);
        GlobalSignals.OnRestartLevel.RemoveListener(RestartLevel);
    }
}
