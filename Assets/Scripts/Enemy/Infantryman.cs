using UnityEngine;
using UnityEngine.AI;

public class Infantryman : Enemy
{
    private NavMeshAgent agent;
    protected override void Start()
    {
        base.Start();

        agent = GetComponent<NavMeshAgent>();
        agent.speed = BaseStats.BaseMoveSpeed;
    }

    private void Update()
    {
        agent.destination = CommonAssets.i.Player.transform.position;
    }
}
