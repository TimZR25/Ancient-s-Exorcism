using UnityEngine;

public interface IPlayer
{
    Vector3 Position { get; }

    void ApplyHeal(float amount);
}
