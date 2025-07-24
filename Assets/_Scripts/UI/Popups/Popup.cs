using DG.Tweening;
using System;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public abstract class Popup : MonoBehaviour
{
    [Header("Popup settings")]
    [SerializeField] private float _animateTime = 0.5f;
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
        transform.localScale = Vector3.zero;
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
        transform.DOKill();
        transform.DOScale(Vector3.one * 1.1f, _animateTime).OnComplete(() =>
            transform.DOScale(Vector3.one, _animateTime / 3));
        GlobalSignals.OnPopupOpened?.Invoke(this);
    }

    public virtual void Hide()
    {
        transform.DOKill();
        transform.DOScale(Vector3.one * 1.1f, _animateTime / 3).OnComplete(() =>
            transform.DOScale(Vector3.zero, _animateTime).OnComplete(() =>
                {
                    _canvasGroup.alpha = 0f;
                    _canvasGroup.blocksRaycasts = false;
                    gameObject.SetActive(false);
                    GlobalSignals.OnPopupClosed?.Invoke(this);
                }));
    }
}
