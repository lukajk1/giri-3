using UnityEngine;
using UnityEngine.AI;

public class Witch : Enemy
{
    private NavMeshAgent agent;
    protected override void Start()
    {
        base.Start();

        agent = GetComponent<NavMeshAgent>();
        agent.speed = BaseStats.BaseMoveSpeed;
    }
}
