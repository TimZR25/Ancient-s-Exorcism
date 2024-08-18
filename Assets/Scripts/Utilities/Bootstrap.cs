using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private AudioManager _audioManager;

    [SerializeField] private SpellBook _spellBook;

    [SerializeField] private GameManager _gameManager;

    private Graveyard[] _graveyards;

    private void Awake()
    {
        _player.Dead += _gameManager.OnPlayerDead;

        _graveyards = FindObjectsByType<Graveyard>(FindObjectsSortMode.None);

        _gameManager.Inject(_graveyards.Length);

        foreach (Graveyard graveyard in _graveyards)
        {
            graveyard.Inject(_player);

            graveyard.Destroyed += _gameManager.OnDestroyedGraveyard;
        }

        _spellBook.Inject(_audioManager);
    }
}
