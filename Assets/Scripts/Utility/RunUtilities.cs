using UnityEngine;

public class RunUtilities : MonoBehaviour
{
    public static RunUtilities i;

    public LayerMask groundLayer;

    private void Awake()
    {
        if (i == null) i = this;
        else
        {
            Debug.LogError($"multiple {this} singletons found. (destroying extra)");
            Destroy(gameObject);
        }
    }
    public Vector3 CursorToWorldPos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            return hit.point;
        }
        else return Vector3.zero;
    }
}