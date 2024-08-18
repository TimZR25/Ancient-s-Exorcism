using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Graveyard : MonoBehaviour
{
    [SerializeField] private List<Grave> _graves;

    public int GravesCount => _graves.Count;

    public UnityAction Destroyed;

    public void Inject(Player player)
    {
        foreach (var grave in _graves)
        {
            grave.Inject(player);

            grave.Destroyed += OnDestroyed;
        }
    }

    public void OnDestroyed(Grave grave)
    {
        _graves.Remove(grave);

        grave.Destroyed -= OnDestroyed;

        if (_graves.Count <= 0)
        {
            Destroyed?.Invoke();
        }
    }
}
