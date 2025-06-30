using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{

    public Item rustedTanto;
    public Item boots;
    void Awake()
    {
        rustedTanto = new Item("Rusted Tanto", "A crappy sword, but better than nothing", 150f);
        rustedTanto.ad = 10f;
        rustedTanto.cdr = 5f;

        boots = new Item("Boots", "Some boots! Now you can run faster.", 180f);
        boots.moveSpeed = 6.5f;
    }
}
