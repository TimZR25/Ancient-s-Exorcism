using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Graveyard _graveyard;

    [SerializeField] private float _radius;

    [SerializeField] private Transform _pointerTransform;
    private void Update()
    {
        if (Vector3.Distance(_pointerTransform.position, _graveyard.transform.position) <= _radius)
        {
            _pointerTransform.gameObject.SetActive(false);
        }
        else
        {
            _pointerTransform.gameObject.SetActive(true);
        }

        if (_graveyard != null)
        {
            RotateTo(_graveyard.transform.position);
        }

        if (_graveyard.GravesCount <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void RotateTo(Vector3 to)
    {
        Vector3 mousePosition = to - transform.position;
        mousePosition.Normalize();


        float rotateZ = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(_pointerTransform.position, _radius);
    }
}
