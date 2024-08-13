using UnityEngine;

public class Player : MonoBehaviour, IPLayer
{
    public Vector3 Position => transform.position;
}