using UnityEngine;

public class Plyr_CamSnapIndicator : MonoBehaviour
{
    private MeshRenderer mr;
    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
        mr.enabled = false;
    }

    public void Set(bool value)
    {
        mr.enabled = value;
    }
}
