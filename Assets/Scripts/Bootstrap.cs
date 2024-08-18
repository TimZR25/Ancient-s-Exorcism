using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Graveyard[] _graveyards;

    private void Awake()
    {
        _graveyards = FindObjectsByType<Graveyard>(FindObjectsSortMode.None);

        foreach (Graveyard graveyard in _graveyards)
        {
            graveyard.Inject(_player);
        }
    }
}
