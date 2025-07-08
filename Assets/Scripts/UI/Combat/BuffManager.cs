using UnityEngine;

public class BuffManager : MonoBehaviour
{
    [SerializeField] private GameObject buffHorizontalLayoutParent;
    [SerializeField] private GameObject buffPrefab;

    #region singleton
    public static BuffManager i;
    private void Awake()
    {
        i = this;
    }
    #endregion
    private void Start()
    {
        foreach (Transform child in buffHorizontalLayoutParent.transform) // clear out the mockup buffs
        {
            Destroy(child.gameObject);
        }
    }
    public void AddBuff(BuffData buff, BuffCompleteDelegate callback)
    {
        GameObject newBuff = Instantiate(buffPrefab, buffHorizontalLayoutParent.transform);
        newBuff.GetComponent<BuffIcon>().Init(buff, callback);
        newBuff.SetActive(true);
    }
}