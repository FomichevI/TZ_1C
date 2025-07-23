using System;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "SlidingFiguresConfig", menuName = "Scriptable Objects/SlidingFiguresConfig")]
public class SlidingFigureConfig : ScriptableObject
{
    [field: SerializeField] public FigureInfo[] FiguresInfo { get; private set; }
    [SerializeField, Range(0, 0.1f)] private float _minSlidingSpeed;
    [SerializeField, Range(0.1f, 0.2f)] private float _maxSlidingSpeed;

    public float GetRandomSpeed()
    {
        return Random.Range(_minSlidingSpeed, _maxSlidingSpeed);
    }
}

[Serializable]
public class FigureInfo
{
    [field: SerializeField] public string FigureIndex {  get; private set; }
    [field: SerializeField] public Sprite FigureSprite { get; private set; }
    [field: SerializeField] public Sprite HoleForFigureSprite { get; private set; }
}