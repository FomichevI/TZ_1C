using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private CanvasGroup _backGroundCg;
    [SerializeField] private float _backGroundAnimateTime;

    [Header("Popups")]
    [field: SerializeField] public Popup WinPopup { get; private set; }
    [field: SerializeField] public Popup LosePopup { get; private set; }

    private List<Popup> _openedPopups = new List<Popup>();

    private void OnEnable()
    {
        GlobalSignals.OnPopupOpened.AddListener(OnPopupOpened);
        GlobalSignals.OnPopupClosed.AddListener(OnPopupClosed);
    }

    private void OnPopupOpened(Popup popup)
    {
        if (!_openedPopups.Contains(popup))
            _openedPopups.Add(popup);
        UpdateBlureBg();
    }

    private void OnPopupClosed(Popup popup)
    {
        if (_openedPopups.Contains(popup))
            _openedPopups.Remove(popup);
        UpdateBlureBg();
    }

    private void UpdateBlureBg()
    {
        if (_openedPopups.Count > 0)
        {
            _backGroundCg.DOKill();
            _backGroundCg.DOFade(1, _backGroundAnimateTime).OnComplete(() =>
            {
                _backGroundCg.blocksRaycasts = true;
                _backGroundCg.interactable = true;
            });
        }
        else
        {
            _backGroundCg.DOKill();
            _backGroundCg.DOFade(0, _backGroundAnimateTime).OnComplete(() =>
            {
                _backGroundCg.blocksRaycasts = false;
                _backGroundCg.interactable = false;
            });
        }
    }

    private void OnDisable()
    {
        GlobalSignals.OnPopupOpened.RemoveListener(OnPopupOpened);
        GlobalSignals.OnPopupClosed.RemoveListener(OnPopupClosed);
    }
}
