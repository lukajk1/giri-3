using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public interface IDamageable
{
    public int I_Health { get; set; }
    public bool Damage(Unit source, Damage damage);
    public bool CrowdControl(Unit source, CC cc);
}
