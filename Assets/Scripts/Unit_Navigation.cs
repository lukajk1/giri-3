using UnityEngine;
using UnityEngine.AI;

public class Unit_Navigation : MonoBehaviour
{
    private NavMeshAgent agent;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null) Debug.LogError("could not get navmeshagent from getcomponent");
    }

    public void Init(float movespeed)
    {
        agent.speed = movespeed;
    }

    public void PathTo(Vector3 pos)
    {
        agent.SetDestination(pos);
    }

    public void SetEnabled(bool value)
    {
        agent.enabled = value;
    }
}