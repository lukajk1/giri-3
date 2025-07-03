using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Effect 
{
    public List<CCState> states = new();
    public StatMod statMods = new StatMod();
    public float duration = 3f;
    public bool indefinite = false;

    public Effect()
    {

    }
}