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

    // public fields/proprties
    [Header("Package")]
    [Tooltip("arbitrary bundle of data for loading specific character behavior. Will include everything needed for the character..? Includes passive programming, model.. Ideally all I have to do is pass this in and the character will be loaded in. Well I guess in reality there will probably be little annoying differences so that I will just store these characters entirely as prefabs, but this package is still relevant bc it contains the passive code and whatnot.")]
    [SerializeField] private CompPackage Package;
    [HideInInspector] public Vector3 Destination { get => Movement.Destination; }

    [Header("Standard References")]
    [SerializeField] public Plyr_CamSnapIndicator SnapIndicator;
    [SerializeField] private Plyr_AttackRangeIndicator attackRangeIndicator;
    [SerializeField] private Plyr_BasicAttack attack;
    [SerializeField] public Plyr_MovementAnimation Movement;
    [SerializeField] public Plyr_Abilities Abilities;
    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>(); 
        
        // initialized first so other components can use instance stats
        InstanceStats.Init(this);

        Movement.Init(this, animator);
        attack.Init(this, animator);
        attackRangeIndicator.Init(this);
        Abilities.Init(this);

        // add arbitrary code bundle 
        GameObject child = Instantiate(Package.componentPackage);
        child.transform.SetParent(transform); 
        child.transform.localPosition = Vector3.zero;
        child.transform.localRotation = Quaternion.identity;
        child.transform.localScale = Vector3.one;
    }
    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.G))
        {
            Effect buff = new Effect()
            {
                duration = 3f,
                states = new List<CCState>() { }
            };
        }
    }

}
