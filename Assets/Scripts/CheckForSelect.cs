using UnityEngine;

public class CheckForSelect : MonoBehaviour
{
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Unit e = hit.collider.gameObject.GetComponent<Unit>();

            if (e != null)
            {
                //e.I_Hover();
            }
        }
    }
}
