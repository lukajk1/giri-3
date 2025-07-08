using UnityEngine;

public class Unit_Movement : MonoBehaviour 
{
    protected void UnitLookAt(Vector3 pos)
    {
        Vector3 direction = pos - transform.position;
        direction.y = 0f;
        if (direction.sqrMagnitude > 0.001f)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}