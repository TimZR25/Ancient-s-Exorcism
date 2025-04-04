using UnityEngine;

public class Hint : GodMiracle
{
    private void Start()
    {
        Destroy(gameObject, 30f);
    }
}
