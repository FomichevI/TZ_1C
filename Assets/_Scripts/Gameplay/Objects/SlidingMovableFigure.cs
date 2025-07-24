using DG.Tweening;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

[RequireComponent(typeof(FigureAnimator))]
public class SlidingMovableFigure : MonoBehaviour, IDraggingObject, ISlidingObject
{
    // Поля интерфейсов
    public Transform Transform => transform;
    public float Speed => _speed;
    public bool IsSliding => _isSliding;
    public bool IsActive => _isActive;

    private float _speed;
    private bool _isActive = false;
    private bool _isSliding = false;

    // Собственные поля
    public string FigureIndex { get; private set; }
    [SerializeField] private FigureAnimator _animator;
    [SerializeField] private SpriteRenderer _mainSr;
    [SerializeField] private float _replaceOnReleaseTime = 0.5f; //Время возвращения объекта на линию после того, как его отпустили
    private Vector2 _endPosition;
    private Vector2 _currentPositionOnLine; // Позиция, с которой объект начали перемещать

    // Ссылки на внешние зависимости
    private SlidingFigureConfig _config;
    private IFigureSorter _figureSorter;
    private SessionConfig _sessionConfig;

    [Inject]
    private void Construct(SlidingFigureConfig config, IFigureSorter figureSorter, SessionConfig sessionConfig)
    {
        _config = config;
        _figureSorter = figureSorter;
        _sessionConfig = sessionConfig;
    }

    private void Awake()
    {
        _animator = GetComponent<FigureAnimator>();
    }

    private void OnEnable()
    {
        GlobalSignals.OnRestartLevel.AddListener(SimpleDestroy);
    }

    public void SetEndPosition(Vector2 endPosition)
    {
        _endPosition = endPosition;
    }

    public void StartSlide()
    {
        RandomizeFigure();
        _animator.AnimateRising(() => _isActive = _isSliding = true);
    }

    public void StartDragging()
    {
        _isSliding = false;
        _currentPositionOnLine = new Vector2(transform.position.x, transform.position.y);
    }

    public void StopDragging()
    {
        // Найти ближайший Holder, который находится в пределах своей CatchDistance
        int nearestHolderIndex = -1;
        float nearestHolderSqrDistance = float.MaxValue;
        Vector2 currentPosition = transform.position;

        for (int i = 0; i < _figureSorter.Holders.Length; i++)
        {
            float sqrMagnitude = (currentPosition - _figureSorter.Holders[i].Position).sqrMagnitude;
            float sqrCatchDistance = Mathf.Sqrt(_figureSorter.Holders[i].CatchDistance);
            if (sqrMagnitude < sqrCatchDistance && sqrMagnitude < nearestHolderSqrDistance)
            {
                nearestHolderIndex = i;
                nearestHolderSqrDistance = sqrMagnitude;
            }
        }

        // Если такой Holder найден, то выполняем CatchByHolder
        if (nearestHolderIndex != -1)
            CatchByHolder(nearestHolderIndex);
        else
            ContinueSlidingOnRelease();
    }

    public void ContinueSlidingOnRelease()
    {
        _isActive = false;
        transform.DOMove(_currentPositionOnLine, _replaceOnReleaseTime).OnComplete(() =>
        {
            _isSliding = true;
            _isActive = true;
        });
    }

    private void CatchByHolder(int holderIndex)
    {
        if (_figureSorter.Holders[holderIndex].FigureIndex == FigureIndex)
            MoveToCorrectHolder(holderIndex);
        else
            DetonateObject();
    }

    private void MoveToCorrectHolder(int holderIndex)
    {
        _isActive = false;
        transform.DOMove(_figureSorter.Holders[holderIndex].Position, _replaceOnReleaseTime * 0.5f).OnComplete(() =>
            _animator.AnimateDisappear(() =>
            {
                if (_sessionConfig.IsPlaying)
                    GlobalSignals.OnFigureCollected?.Invoke();
                Destroy(gameObject);
            }));
    }

    private void FixedUpdate()
    {
        if (_isSliding && _sessionConfig.IsPlaying)
        {
            transform.position = Vector3.MoveTowards(transform.position, (Vector3)_endPosition, _speed);
            if (transform.position == (Vector3)_endPosition)
                DetonateObject();
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

    private void DetonateObject()
    {
        GlobalSignals.OnFigureDetonate?.Invoke();
        _isActive = _isSliding = false;
        _animator.AnimateDetonate(() => Destroy(gameObject));
    }

    private void SimpleDestroy()
    { 
        Destroy(gameObject); 
    }

    private void OnDestroy()
    {
        GlobalSignals.OnFigureDestroy?.Invoke(this);
    }

    private void OnDisable()
    {
        GlobalSignals.OnRestartLevel.RemoveListener(SimpleDestroy);
    }
}
