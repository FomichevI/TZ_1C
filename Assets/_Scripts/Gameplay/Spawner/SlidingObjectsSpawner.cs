using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class SlidingObjectsSpawner : MonoBehaviour
{
    [SerializeField] private Line[] _lines;

    private int _currentLineIndex;
    private SlidingObjectsFactory _factory;
    private SpawnerConfig _config;
    private SessionConfig _sessionConfig;

    private CancellationTokenSource _cts;

    [Inject]
    private void Construct(SlidingObjectsFactory slidingObjectsFactory, SpawnerConfig spawnerConfig, SessionConfig sessionConfig)
    {
        _factory = slidingObjectsFactory;
        _config = spawnerConfig;
        _sessionConfig = sessionConfig;
    }

    private void OnEnable()
    {
        GlobalSignals.OnLevelStarted.AddListener(StartSpawning);
    }

    private void StartSpawning()
    {
        RandomizeNextLine();
        _cts = new CancellationTokenSource();
        CancellationToken token = _cts.Token;
        SpawningAsync(token);
    }

    private async void SpawningAsync(CancellationToken token)
    {
        while (_sessionConfig.IsPlaying && _sessionConfig.SpawnedFiguresCount < _sessionConfig.TargetFiguresCount)
        {
            await Task.Delay((int)(_config.GetRandomSpawnDelay() * 1000));
            if (_sessionConfig.IsPlaying && !token.IsCancellationRequested)
            {
                Spawn();
                RandomizeNextLine();
            }
        }
    }

    private void Spawn()
    {
        var slidingGo = _factory.Create();
        slidingGo.Transform.SetParent(_lines[_currentLineIndex].transform);
        slidingGo.Transform.position = _lines[_currentLineIndex].GetStartPosition();
        slidingGo.SetEndPosition(_lines[_currentLineIndex].GetEndPosition());
        slidingGo.StartSlide();
        GlobalSignals.OnFigureSpawn?.Invoke(slidingGo);
    }

    private void RandomizeNextLine()
    {
        _currentLineIndex = Random.Range(0, _lines.Length);
    }

    private void OnDestroy()
    {
        _cts.Cancel();
    }

    private void OnDisable()
    {
        GlobalSignals.OnLevelStarted.RemoveListener(StartSpawning);
    }
}
