using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameOverUI _gameOverUI;

    [SerializeField] private WinUI _winUI;

    [SerializeField] private Timer _timer;

    private int _graveyardCount;

    public void Inject(int graveyardCount)
    {
        _graveyardCount = graveyardCount;
    }

    public void OnPlayerDead()
    {
        _gameOverUI.Init(_timer.CurrentTime);

        _timer.gameObject.SetActive(false);
        _gameOverUI.gameObject.SetActive(true);
    }

    public void OnDestroyedGraveyard()
    {
        _graveyardCount--;

        if (_graveyardCount <= 0)
        {
            _winUI.Init(_timer.CurrentTime);

            _timer.gameObject.SetActive(false);
            _winUI.gameObject.SetActive(true);
        }
    }
}
