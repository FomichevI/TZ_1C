using UnityEngine.Events;

/// <summary>
/// Все основные события игры
/// </summary>
public static class GlobalSignals
{
    public static UnityEvent OnLevelStarted = new UnityEvent();
    public static UnityEvent OnWinLevel = new UnityEvent();
    public static UnityEvent OnLoseLevel = new UnityEvent();
    public static UnityEvent OnRestartLevel = new UnityEvent();
    public static UnityEvent OnFigureDetonate = new UnityEvent();
    public static UnityEvent OnFigureCollected = new UnityEvent();
    public static UnityEvent<Popup> OnPopupOpened = new UnityEvent<Popup>();
    public static UnityEvent<Popup> OnPopupClosed = new UnityEvent<Popup>();
    public static UnityEvent<ISlidingObject> OnFigureSpawn = new UnityEvent<ISlidingObject>();
    public static UnityEvent<ISlidingObject> OnFigureDestroy = new UnityEvent<ISlidingObject>();
}