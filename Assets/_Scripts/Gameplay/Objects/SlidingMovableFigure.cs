using UnityEngine;
using Zenject;

public class SlidingMovableFigure : MonoBehaviour, IDraggingObject, ISlidingObject
{
    // Поля интерфейсов
    public Transform Transform => transform;
    public float Speed => _speed;
    public bool IsMoving => _isMoving;
    public bool IsActive => _isActive;

    private float _speed;
    private bool _isActive = false;
    private bool _isMoving = false;

    // Собственные поля
    public string FigureIndex { get; private set; }
    [SerializeField] private SpriteRenderer _mainSr;
    private Vector2 _endPosition;

    // Ссылки на глобальные настройки
    private SlidingFigureConfig _config;

    [Inject]
    private void Construct(SlidingFigureConfig config)
    {
        _config = config;
    }

    public void SetEndPosition(Vector2 endPosition)
    {
        _endPosition = endPosition;
    }

    public void StartSlide()
    {
        Debug.Log("StartSlide");
        RandomizeFigure();
        _isActive = _isMoving = true;
    }

    public void StartDragging()
    {
        Debug.Log("StartDragging");
    }

    public void StopDragging()
    {
        Debug.Log("StopDragging");
    }

    private void FixedUpdate()
    {
        if (_isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, (Vector3)_endPosition, _speed);
            if (transform.position == (Vector3)_endPosition)
                DestroyObject();
        }
    }

    private void RandomizeFigure()
    {
        FigureInfo figureInfo = _config.FiguresInfo[Random.Range(0, _config.FiguresInfo.Length)];
        if (figureInfo == null)
            Debug.LogError("No one figure info in SlidingFigureConfig!");

        _mainSr.sprite = figureInfo.FigureSprite;
        FigureIndex = figureInfo.FigureIndex;
        _speed = _config.GetRandomSpeed();
    }

    private void DestroyObject()
    {
        Debug.Log("Достигнута полседняя точка");
        _isActive = _isMoving = false;
        Destroy(gameObject);
    }
}
