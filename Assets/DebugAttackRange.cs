using UnityEngine;

public class DebugAttackRange : MonoBehaviour
{
    [SerializeField] private Unit unit;
    [SerializeField] private bool activate = true;
    private MeshRenderer mr;

    private void Awake()
    {
        if (!activate)
        {
            this.enabled = false;
            return;
        }

        mr = GetComponent<MeshRenderer>();
        mr.enabled = true;
        unit.OnStatsModified += SetRange;
    }

    private void OnDisable()
    {
        unit.OnStatsModified -= SetRange;
    }

    void SetRange()
    {
        float range = unit.currentAttackRange * 2;
        transform.localScale = new Vector3(range, range, transform.localScale.z);
    }
}
