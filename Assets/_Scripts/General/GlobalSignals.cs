using System.Collections.Generic;
using UnityEngine.Events;

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
}