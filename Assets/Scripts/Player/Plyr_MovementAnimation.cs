using UnityEngine;
using UnityEngine.AI;

public class Plyr_MovementAnimation : Unit_Movement
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject inWorldMoveCursor;
    [HideInInspector] public Vector3 Destination;

    private NavMeshAgent agent;
    private Player player;
    private Animator animator;
    public void Init(Player player, Animator animator)
    {
        this.player = player;
        this.animator = animator;
        agent.speed = player.InstanceStats.currentMoveSpeed;
    }
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null) Debug.LogError("could not get navmeshagent from getcomponent");
        //agent.updateRotation = false;
    }

    private void Update()
    {
        if (Run.TimeScale > 0)
        {
            UpdateMovement();
        }

        //bool isWalking = Vector3.SqrMagnitude(inWorldMoveCursor.transform.position - transform.position) > 0.1f;
        //animator.SetBool("IsWalking", isWalking);
    }
    private void UpdateMovement()
    {
        UpdateInWorldCursor();
        //UnitLookAt(inWorldMoveCursor.transform.position);

        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetTrigger("Idle");
            inWorldMoveCursor.transform.position = transform.position;
        }
    }

    private void UpdateInWorldCursor()
    {
        if (Input.GetButton("MoveClick"))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
            {

                inWorldMoveCursor.transform.position = hit.point;
                WalkTo(hit.point);
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