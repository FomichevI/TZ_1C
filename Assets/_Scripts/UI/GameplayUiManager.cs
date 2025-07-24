using UnityEngine;

public class GameplayUiManager : MonoBehaviour
{
    [SerializeField] private PopupManager _popupManager;

    private void OnEnable()
    {
        GlobalSignals.OnWinLevel.AddListener(OnGameWin);
        GlobalSignals.OnLoseLevel.AddListener(OnGameLose);
    }

    private void OnGameWin()
    {
        _popupManager.WinPopup.Show();
    }

    private void OnGameLose()
    {
        _popupManager.LosePopup.Show();
    }

    private void OnDisable()
    {
        GlobalSignals.OnWinLevel.RemoveListener(OnGameWin);
        GlobalSignals.OnLoseLevel.RemoveListener(OnGameLose);
    }
}
