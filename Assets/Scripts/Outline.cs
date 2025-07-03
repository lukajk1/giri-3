using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour, ISelectable
{
    [SerializeField] MeshRenderer meshRenderer;

    private bool selected;
    void Start()
    {
        Material[] mats = meshRenderer.materials;
        List<Material> matList = new List<Material>(mats);
        matList.Insert(0, CommonAssets.i.OutlineShader);
        meshRenderer.materials = matList.ToArray();
    }
    void Update()
    {
        UpdateSelection();
    }
    public void I_Hover()
    {
        selected = true;
    }
    private void UpdateSelection()
    {
        if (selected) meshRenderer.materials[0].EnableKeyword("ENABLE_OUTLINE");
        else meshRenderer.materials[0].DisableKeyword("ENABLE_OUTLINE");
        selected = false;
    }

}