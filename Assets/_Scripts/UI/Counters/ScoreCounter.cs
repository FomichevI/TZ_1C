using System.Threading.Tasks;

public class ScoreCounter : Counter
{
    private void OnEnable()
    {
        GlobalSignals.OnFigureCollected.AddListener(UpdateScoreAsync);
        GlobalSignals.OnLevelStarted.AddListener(UpdateScoreAsync);
    }

    private async void  UpdateScoreAsync()
    {
        await Task.Yield();
        SetNewCount(_sessionConfig.CurrentFiguresCollected);
    }

    private void OnDisable()
    {
        GlobalSignals.OnFigureCollected.RemoveListener(UpdateScoreAsync);
        GlobalSignals.OnLevelStarted.RemoveListener(UpdateScoreAsync);
    }
}
