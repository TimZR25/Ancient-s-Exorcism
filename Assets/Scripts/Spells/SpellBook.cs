using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class SpellBook : MonoBehaviour
{
    [SerializeField] private List<Spell> _spells;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Camera _mainCamera;

    private CinemachineCamera _camera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        RotateTo(_mainCamera.ScreenToWorldPoint(Input.mousePosition));

        if (Input.GetMouseButton(0))
        {
            Spell();
        }
    }

    private void RotateTo(Vector3 to)
    {
        Vector3 mousePosition = to - transform.position;
        mousePosition.Normalize();


        float rotateZ = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);

        if (rotateZ > -90 && rotateZ < 90)
        {
            _spriteRenderer.flipY = false;

        }
        else
        {
            _spriteRenderer.flipY = true;
        }
    }

    private void Spell()
    {
        _spells[0].Cast();
    }
}
