using UnityEngine;

[CreateAssetMenu(fileName = "SpawnersConfig", menuName = "Scriptable Objects/SpawnersConfig")]
public class SpawnerConfig : ScriptableObject
{
    [SerializeField, Range(0.1f, 10)] private float _minSpawnDelay;
    [SerializeField, Range(0.1f, 10)] private float _maxSpawnDelay; 

    public float GetRandomSpawnDelay()
    {
        return Random.Range(_minSpawnDelay, _maxSpawnDelay);
    }
}
