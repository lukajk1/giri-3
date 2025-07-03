using System.Collections.Generic;
using UnityEngine;

public class Plyr_Abilities : MonoBehaviour
{
    [SerializeField] private Ability Q;
    [SerializeField] private Ability W;
    [SerializeField] private Ability E;
    [SerializeField] private Ability R;
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q)) { }
        else if (Input.GetKeyDown(KeyCode.W)) { }
        else if (Input.GetKeyDown(KeyCode.E)) { }
        else if (Input.GetKeyDown(KeyCode.R)) R.Activate();

    }
}