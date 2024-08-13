using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();

        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private IPLayer _player;

    public void Inject(IPLayer pLayer)
    {
        _player = pLayer;
    }

    private void FixedUpdate()
    {
        _agent.SetDestination(_player.Position);

        FlipToTarget(_player.Position);
    }

    private void FlipToTarget(Vector3 target)
    {
        if (target.x - transform.position.x > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x),
                transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x),
                transform.localScale.y, transform.localScale.z);
        }
    }
}
