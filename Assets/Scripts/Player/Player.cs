using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Serialization;
using UnityEngine.AI;

public partial class Player : Unit
{
    // external refs
    private Animator animator;
    [HideInInspector] public Vector3 Destination { get => Movement.Destination; }

    [Header("Standard References")]
    [SerializeField] public Plyr_CamSnapIndicator SnapIndicator;
    [SerializeField] private Plyr_AttackRangeIndicator attackRangeIndicator;
    [SerializeField] private Plyr_BasicAttack attack;
    [SerializeField] public Plyr_MovementAnimation Movement;
    [SerializeField] public Plyr_Abilities Abilities;
    protected void Start()
    {
        animator = GetComponent<Animator>(); 
        
        // initialized first so other components can use instance stats
        InstanceStats.Init(this);

        Movement.Init(this, animator);
        attack.Init(this, animator);
        attackRangeIndicator.Init(this);
        Abilities.Init(this);
    }
    protected void Update()
    {

    }

    public override void AddBuff(BuffData buff)
    {
        Debug.Log("Buff was added in player");
        BuffManager.i.AddBuff(buff, BuffOnComplete); // pass oncomplete method as callback
    }

}
