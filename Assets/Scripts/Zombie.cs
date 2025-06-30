using UnityEngine;

public class Zombie : Enemy
{
    private Unit_Navigation nav;
    public float movespeed;
    protected override void Start()
    {
        base.Start();
        nav = GetComponent<Unit_Navigation>();
        nav.Init(movespeed);
    }
    protected override void Update()
    {
        base.Update();
        nav.PathTo(CommonAssets.i.Player.transform.position);
    }
}
