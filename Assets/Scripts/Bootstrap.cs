using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private AudioManager _audioManager;

    [SerializeField] private SpellBook _spellBook;

    private Graveyard[] _graveyards;

    private void Awake()
    {
        _graveyards = FindObjectsByType<Graveyard>(FindObjectsSortMode.None);

        foreach (Graveyard graveyard in _graveyards)
        {
            graveyard.Inject(_player);
        }

        _spellBook.Inject(_audioManager);
    }
}
