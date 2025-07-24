using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Scriptable Objects/GameSettings")]
public class GameSettings : ScriptableObject
{
    public SpawnerConfig SpawnerConfig;
    public SlidingFigureConfig SlidingFigureConfig;
    public GameplayConfig GameplayConfig;
    public SessionConfig SessionConfig;
}
