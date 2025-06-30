using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public interface IDamageable
{
    public int I_Health { get; set; }
    public bool Damage(Agent source, Damage damage);
    public bool CrowdControl(Agent source, CC cc);
}
