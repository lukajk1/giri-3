using UnityEngine;

public class Plyr_AttackRangeIndicator : MonoBehaviour
{
    private MeshRenderer mr;
    private float _attackRange;
    private Vector3 originalValues;
    public float Range
    {
        get => _attackRange;
        set
        {
            if (_attackRange != value && value > 0)
            {
                _attackRange = value;
                UpdateRange(value);
            }
        }
    }
    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();

        originalValues = transform.localScale;
    }
    public void Init(float value)
    {
        Range = value;
    }
    private void UpdateRange(float value)
    {
        float tf = value * 2;
        transform.localScale = new Vector3(tf, tf, originalValues.z);
    }

    private void Update()
    {
        if (Input.GetButton("ShowAttackRange"))
        {
            mr.enabled = true;
        }
        else mr.enabled = false;
    }
}
