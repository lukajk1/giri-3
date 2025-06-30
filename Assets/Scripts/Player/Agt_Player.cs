using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Serialization;
using UnityEngine.AI;

public partial class Agt_Player : Agent
{
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private GameObject inWorldMoveCursor;

    public float AttackRange { get; private set; } = 6f;

    private GameObject attackRangeIndicator;

    private Unit_Navigation nav;
    private float movespeed = 4f;
    protected override void Start()
    {
        base.Start();
        nav = GetComponent<Unit_Navigation>();
        nav.Init(movespeed);

        GameObject.FindFirstObjectByType<Plyr_AttackRangeIndicator>().Init(AttackRange);
        GameObject.FindFirstObjectByType<Plyr_AttackMove>().Init(this, inWorldMoveCursor.transform);

    }
    protected override void Update()
    {
        base.Update();

        if (Run.TimeScale > 0)
        {
            UpdateMovement();
            UnitLookAt(inWorldMoveCursor.transform.position);
        }

    }

    private Vector3? CursorToWorldPos() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            return hit.point;
        }
        else return null;
    }
    private void UpdateMovement() {
        UpdateInWorldCursor();

        if (Input.GetKeyDown(KeyCode.X))
        {
            inWorldMoveCursor.transform.position = transform.position;
            nav.PathTo(transform.position);
        }
    }

    private void UpdateInWorldCursor() {
        if (Input.GetButton("MoveClick")) {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
            {
                if (hit.collider.gameObject.CompareTag("Ground"))
                {
                    inWorldMoveCursor.transform.position = hit.point;
                    nav.PathTo(hit.point);
                }
            }
        }
    }
}
