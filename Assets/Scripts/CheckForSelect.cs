using UnityEngine;

public class CheckForSelect : MonoBehaviour
{
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Agent e = hit.collider.gameObject.GetComponent<Agent>();

            if (e != null)
            {
                e.I_Hover();
            }
        }
    }
}
