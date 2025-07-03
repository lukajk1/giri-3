using UnityEngine;

public class Eivel_Ultimate : Ability
{
    [SerializeField] private MeshRenderer mr;
    private void Awake()
    {
        mr.enabled = false;
    }
    public override bool Activate()
    {
        mr.enabled = true;
        return true;
    }
}