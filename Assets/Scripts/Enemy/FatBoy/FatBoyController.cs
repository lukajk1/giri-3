using UnityEngine;
using UnityEngine.AI;

public class FatBoyController : EnemyController 
{
    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        currentState = new EmptyState(this);
    }

    protected virtual void Update()
    {
        base.Update();

        Vector3 playerPos = CommonAssets.i.Player.transform.position;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(playerPos, out hit, 3.0f, NavMesh.AllAreas))
        {
            navAgent.destination = hit.position;
        }
        else
        {
            // Optional fallback behavior if no position is found near the player
        }
    }
}
