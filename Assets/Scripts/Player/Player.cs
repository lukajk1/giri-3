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
    [SerializeField] public Plyr_MovementAndAnimation Movement;
    [SerializeField] public Plyr_Abilities Abilities;
    protected override void Start()
    {
        base.Start();

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
