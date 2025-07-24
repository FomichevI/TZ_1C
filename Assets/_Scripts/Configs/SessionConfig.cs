using UnityEngine;

[CreateAssetMenu(fileName = "SessionConfig", menuName = "Scriptable Objects/SessionConfig")]
public class SessionConfig : ScriptableObject
{
    [field: SerializeField] public bool IsPlaying { get; private set; }
    [field: SerializeField] public int TargetFiguresCount { get; private set; }
    [field: SerializeField] public int HitPoints { get; private set; }
    [field: SerializeField] public int CurrentFiguresCollected { get; private set; }

    public void Initialize(int targetFiguresCount, int hitPoints)
    {
        TargetFiguresCount = targetFiguresCount;
        HitPoints = hitPoints;
        CurrentFiguresCollected = 0;
    }
    public void StopGame()
    { IsPlaying = false; }
    public void ContinueGame()
    { IsPlaying = true; }
    public void CollectFigure()
    { CurrentFiguresCollected++; }
    public void ReduseHitPoints()
    { HitPoints--; }
}
