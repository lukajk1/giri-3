using UnityEngine;
using UnityEngine.AI;

public class FatBoyController : EnemyController 
{
    private void Awake()
    {
        currentState = new EmptyState(this);
    }

    public override void Init(Unit unit) { }

    protected override void Update()
    {
        base.Update();

        Vector3 playerPos = CommonAssets.i.Player.transform.position;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(playerPos, out hit, 3.0f, NavMesh.AllAreas))
        {
            navAgent.destination = hit.position;
        }
    }
}
