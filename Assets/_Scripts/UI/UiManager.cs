using UnityEngine;
using Zenject;

public class UiManager : MonoBehaviour
{

    [Inject]
    private void Construct(SignalBus signalBus)
    {
        signalBus.Subscribe<GameLoseSignal>(OnGameLose);
        signalBus.Subscribe<GameWinSignal>(OnGameWin);
    }
    
    private void OnGameLose()
    {

    }

    private void OnGameWin()
    {

    }
}
