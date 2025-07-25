using System;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// ��������� ���������� ������������ ��������
/// </summary>
[CreateAssetMenu(fileName = "SlidingFiguresConfig", menuName = "Scriptable Objects/SlidingFiguresConfig")]
public class SlidingFigureConfig : ScriptableObject
{
    [field: SerializeField] public FigureInfo[] FiguresInfo { get; private set; }
    [SerializeField, Range(0, 1)] private float _minSlidingSpeed;
    [SerializeField, Range(0, 1)] private float _maxSlidingSpeed;

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