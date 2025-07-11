using UnityEngine;
using UnityEngine.AI;

public class Fatboy : Enemy
{
    private NavMeshAgent agent;
    protected override void Start()
    {
        base.Start();

        agent = GetComponent<NavMeshAgent>();
        agent.speed = BaseStats.BaseMoveSpeed;
    }
}
