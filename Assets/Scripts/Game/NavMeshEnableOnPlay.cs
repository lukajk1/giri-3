using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshEnableOnPlay : MonoBehaviour
{
    NavMeshSurface mesh; 
    void Awake()
    {
        mesh = GetComponent<NavMeshSurface>();
        mesh.enabled = true;
    }

}
