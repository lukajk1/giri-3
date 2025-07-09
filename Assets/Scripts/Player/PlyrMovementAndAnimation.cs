using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class PlyrMovementAndAnimation : Unit_Movement
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private MoveCursor moveCursor;
    [HideInInspector] public Vector3 Destination;

    private NavMeshAgent agent;
    private Player player;
    private Animator animator;
    public void Init(Player player, Animator animator)
    {
        this.player = player;
        this.animator = animator;
        agent.speed = player.currentMoveSpeed; 
        player.OnStatsModified += UpdateStats;
    }
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null) Debug.LogError("could not get navmeshagent from getcomponent");
        //agent.updateRotation = false;
    }
    private void OnDisable()
    {
        player.OnStatsModified -= UpdateStats;
    }

    void UpdateStats()
    {
        animator.SetFloat("MoveSpeed", player.currentMoveSpeed / player.BaseStats.BaseMoveSpeed);
        agent.speed = player.currentMoveSpeed;

        animator.SetFloat("AttackSpeed", player.currentAttackSpeed / player.BaseStats.BaseAttackSpeed);

        Debug.Log(animator.GetFloat("testtsstts"+"MoveSpeed"));
    }

    private void Update()
    {
        if (Run.TimeScale > 0)
        {
            UpdateMovement();
        }

    }
    private void UpdateMovement()
    {
        UpdateInWorldCursor();

        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetTrigger("Idle");
            moveCursor.MoveCommand(transform.position);
        }
    }

    private void UpdateInWorldCursor()
    {
        if (Input.GetButton("MoveClick"))
        {
            if (RunUtilities.CursorToWorldPos(out Vector3 point))
            {
                moveCursor.MoveCommand(point);
                WalkTo(point);
            }
        }
    }

    public void WalkTo(Vector3 pos)
    {
        animator.SetTrigger("Walk");
        agent.SetDestination(pos);
    }

    public void SetNavAgent(bool value)
    {
        agent.enabled = value;
    }

    public void Attack(Vector3 pos)
    {
        agent.SetDestination(transform.position);
        UnitLookAt(pos);
        animator.SetTrigger("Attack");
    }
}