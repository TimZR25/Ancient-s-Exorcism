using NavMeshPlus.Components;
using UnityEngine;

[RequireComponent(typeof(NavMeshSurface))]
public class RealtimeNavMesh : MonoBehaviour
{
    private NavMeshSurface _navMeshSurface;

    private void Awake()
    {
        _navMeshSurface = GetComponent<NavMeshSurface>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Bake();
        }
    }

    public void Bake()
    {
        _navMeshSurface.BuildNavMesh();
    }
}
