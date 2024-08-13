using UnityEngine;

public class Crosshair : MonoBehaviour
{
    private Camera _camera;

    private RectTransform _transform;

    private void Start()
    {
        _transform = GetComponent<RectTransform>();

        _camera = Camera.main;

        Cursor.visible = false;
    }

    private void Update()
    {
        Vector3 mouseWorldPosition = Input.mousePosition;

       // mouseWorldPosition.z = 0f;

        transform.position = mouseWorldPosition;
    }
}
