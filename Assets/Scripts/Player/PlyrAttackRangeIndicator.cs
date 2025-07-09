using UnityEngine;

public class PlyrAttackRangeIndicator : MonoBehaviour
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
    private void OnDisable()
    {
        player.OnStatsModified -= UpdateRange;
    }
    public void Init(Player player)
    {
        this.player = player;
        player.OnStatsModified += UpdateRange;
    }

    private void UpdateRange()
    {
        float dimension = player.currentAttackRange * 2;
        transform.localScale = new Vector3(dimension, dimension, originalValues.z);
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
