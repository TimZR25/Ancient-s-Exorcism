using UnityEngine;

public class Crosshair : MonoBehaviour
{
    private RectTransform _transform;

    private void Start()
    {
        _transform = GetComponent<RectTransform>();

        Cursor.visible = false;
    }

    private void Update()
    {
        Vector3 mouseWorldPosition = Input.mousePosition;

        _transform.position = mouseWorldPosition;
    }
}
