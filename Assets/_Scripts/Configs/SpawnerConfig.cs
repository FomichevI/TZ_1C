using UnityEngine;

[CreateAssetMenu(fileName = "SpawnersConfig", menuName = "Scriptable Objects/SpawnersConfig")]
public class SpawnerConfig : ScriptableObject
{
    [SerializeField, Range(1, 2)] private float _minSpawnDelay;
    [SerializeField, Range(2, 5)] private float _maxSpawnDelay; 

    public float GetRandomSpawnDelay()
    {
        return Random.Range(_minSpawnDelay, _maxSpawnDelay);
    }
}
