using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public partial class Player : Unit
{
    // external refs
    private Animator animator;
    [HideInInspector] public Vector3 Destination { get => Movement.Destination; }

    [Header("Standard References")]
    [SerializeField] public PlyrCamSnapIndicator SnapIndicator;
    [SerializeField] private PlyrAttackRangeIndicator attackRangeIndicator;
    [SerializeField] private PlyrBasicAttack attack;
    [SerializeField] public PlyrMovementAndAnimation Movement;
    [SerializeField] public PlyrAbilities Abilities;
    protected override void Start()
    {
        // disabling base call for a bit to figure out state machine for witch case specifically
        SetBaseStats();
        healthbar.Init(this);
        //base.Start();

        animator = GetComponent<Animator>(); 

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
        base.AddBuff(buff);

        BuffManager.i.AddBuff(buff, BuffOnComplete); // pass oncomplete method as callback
    }
}
