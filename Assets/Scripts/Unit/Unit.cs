using System.Collections.Generic;
using UnityEngine;

public class Unit : Entity
{
    [Header("Stats")]
    [SerializeField] public UnitBaseStats BaseStats;
    [SerializeField] public Unit_InstanceStats InstanceStats;


    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {

    }

    public void Damage(DamageData damage) // change to a struct parameter at some point
    {
        InstanceStats.Damage(damage);
    }

    public void Heal(int heal)
    {
        InstanceStats.Heal(heal);
    }
}
