using UnityEngine;

/// <summary>
/// Параметры текущей игровой сессии
/// </summary>
[CreateAssetMenu(fileName = "SessionConfig", menuName = "Scriptable Objects/SessionConfig")]
public class SessionConfig : ScriptableObject
{
    [field: SerializeField] public bool IsPlaying { get; private set; }
    [field: SerializeField] public int TargetFiguresCount { get; private set; }
    [field: SerializeField] public int SpawnedFiguresCount { get; private set; }
    [field: SerializeField] public int HitPoints { get; private set; }
    [field: SerializeField] public int CurrentFiguresCollected { get; private set; }

    /// <summary>
    /// Инициализация стартовых параметров сессии
    /// </summary>
    public void Initialize(int targetFiguresCount, int hitPoints)
    {
        TargetFiguresCount = targetFiguresCount;
        HitPoints = hitPoints;
        CurrentFiguresCollected = 0;
        SpawnedFiguresCount = 0;
    }
    public void StopGame()
    { IsPlaying = false; }
    public void ContinueGame()
    { IsPlaying = true; }
    public void CollectFigure()
    { CurrentFiguresCollected++; }
    public void ReduseHitPoints()
    { HitPoints--; }
    public void RiseSpawnedFiguresCount()
    { SpawnedFiguresCount++; }
}
