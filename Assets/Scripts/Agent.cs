using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Agent : Entity, ISelectable, IDamageable
{
    [SerializeField] MeshRenderer meshRenderer;

    public int I_Health {  get; set; }

    private bool selected;

    public void I_Hover()
    {
        selected = true;
    }

    protected virtual void Start()
    {
        // fetch outline material and add it to meshrenderer 
        Material[] mats = meshRenderer.materials;
        List<Material> matList = new List<Material>(mats);
        matList.Insert(0, CommonAssets.i.OutlineShader);
        meshRenderer.materials = matList.ToArray(); 
    }

    protected virtual void Update()
    {
        UpdateSelection();
    }
    public bool Damage(Agent source, Damage damage) 
    {

        return true;
    }
    public bool CrowdControl(Agent source, CC cc) { return false; }

    private void UpdateSelection()
    {
        if (selected) meshRenderer.materials[0].EnableKeyword("ENABLE_OUTLINE");
        else meshRenderer.materials[0].DisableKeyword("ENABLE_OUTLINE");
        selected = false;
    }

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
