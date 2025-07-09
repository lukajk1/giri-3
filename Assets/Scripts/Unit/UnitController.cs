using UnityEngine;

public abstract class UnitController : MonoBehaviour
{
    protected Unit unit;

    public virtual void Init(Unit unit)
    {
        this.unit = unit;
    }
}