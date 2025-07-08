using UnityEngine;

public class Plyr_AttackRangeIndicator : MonoBehaviour
{
    private MeshRenderer mr;
    private float _attackRange;
    private Vector3 originalValues;
    private Player player;
    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
        originalValues = transform.localScale;
    }
    public void Init(Player player)
    {
        this.player = player;
    }

    private void UpdateRange()
    {
        float tf = player.currentAttackRange * 2;
        transform.localScale = new Vector3(tf, tf, originalValues.z);
    }

    private void Update()
    {
        if (Input.GetButton("ShowAttackRange"))
        {
            UpdateRange();
            mr.enabled = true;
        }
        else mr.enabled = false;
    }
}
