using UnityEngine;

/// <summary>
/// Основные настройки геймплея
/// </summary>
[CreateAssetMenu(fileName = "GameplayConfig", menuName = "Scriptable Objects/GameplayConfig")]
public class GameplayConfig : ScriptableObject
{
    [field: SerializeField, Range(0,3), Tooltip("Дистанция захвата детали сортером")] 
    public float CatchDistance { get; private set; }

    [SerializeField, Range(1, 50)] private int _minTargetFiguresCount;
    [SerializeField, Range(1, 50)] private int _maxTargetFiguresCount;
    [field: SerializeField, Range(1, 100)] public int StartHitPoints { get; private set; }

    public int GetTargetFuguresCount()
    {
        return Random.Range(_minTargetFiguresCount, _maxTargetFiguresCount);
    }
}
