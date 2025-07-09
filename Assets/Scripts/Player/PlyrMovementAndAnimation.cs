using System.Collections;
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
    private Coroutine turning;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    public void Init(Player player, Animator animator)
    {
        this.player = player;
        this.animator = animator;
        agent.speed = player.currentMoveSpeed;
        agent.updateRotation = false;
        player.OnStatsModified += UpdateStats;
    }
    private void OnDisable()
    {
        player.OnStatsModified -= UpdateStats;
    }

    void UpdateStats()
    {
        animator.SetFloat("MoveSpeed", player.currentMoveSpeed / player.BaseStats.BaseMoveSpeed);
        agent.speed = player.currentMoveSpeed;

        animator.SetFloat("AttackSpeed", player.currentAttackSpeed);

        //Debug.Log(animator.GetFloat("MoveSpeed"));
        //Debug.Log(animator.GetFloat("AttackSpeed"));
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

        if (Input.GetKeyDown(KeyCode.X)) // stop key
        {
            agent.SetDestination(transform.position);
        }

        //if (Vector3.Distance(moveCursor.transform.position, transform.position) < 0.1f) { }

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            animator.SetBool("IsMoving", false);
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
        animator.SetBool("IsMoving", true);
        agent.SetDestination(pos);

        // instant snap to new dir
        //agent.transform.eulerAngles = new Vector3(0, Quaternion.LookRotation(agent.velocity).eulerAngles.y, 0);

        if (turning != null)
        {
            StopCoroutine(turning);
        }
        Vector3 direction = (pos - transform.position);
        turning = StartCoroutine(RotateToDirectionCR(direction));
    }

    private IEnumerator RotateToDirectionCR(Vector3 direction)
    {
        direction.y = 0f;
        if (direction == Vector3.zero) yield break;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        float turnSpeed = 180f / player.BaseStats.TurnSpeed; // degrees per second

        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                turnSpeed * Time.deltaTime
            );

            yield return null;
        }

        transform.rotation = targetRotation;
        turning = null;
    }

    public void Attack(Vector3 pos)
    {
        agent.SetDestination(transform.position);
        UnitLookAt(pos);
        animator.SetTrigger("Attack");
    }
}