using DG.Tweening;
using System;
using UnityEngine;

public class FigureAnimator : MonoBehaviour
{
    [SerializeField] private float _animaionsTime = 0.5f;
    [SerializeField] private GameObject _detonateParticlesGo;

    public void AnimateRising(Action onCompleted)
    {
        transform.DOKill();
        transform.localScale = Vector3.zero;
        transform.DOScale(1.1f, _animaionsTime * 0.5f).OnComplete(() =>
            transform.DOScale(1f, _animaionsTime * 0.2f).OnComplete(() =>
                onCompleted?.Invoke()
            ));
    }

    public void AnimateDisappear(Action onCompleted)
    {
        transform.DOKill();
        transform.DOScale(1.1f, _animaionsTime * 0.2f).OnComplete(() =>
            transform.DOScale(0f, _animaionsTime * 0.3f).OnComplete(() =>
                onCompleted?.Invoke()
            ));
    }

    public void AnimateDetonate(Action onCompleted)
    {
        onCompleted?.Invoke();
    }
}
