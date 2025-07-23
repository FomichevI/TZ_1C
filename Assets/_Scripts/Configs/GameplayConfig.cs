using UnityEngine;

[CreateAssetMenu(fileName = "GameplayConfig", menuName = "Scriptable Objects/GameplayConfig")]
public class GameplayConfig : ScriptableObject
{
    [field: SerializeField, Range(0,3), Tooltip("Дистанция захвата детали сортером")] 
    public float CatchDistance { get; private set; } 

    public bool IsPlaying { get; private set; } = true;
}
