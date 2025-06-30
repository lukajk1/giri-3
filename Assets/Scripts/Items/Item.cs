using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string name { get; set; }
    public string description { get; set; }
    public float cost { get; set; }
    public float ad;
    public float cdr;
    public float crit; 
    public float moveSpeed; 
    public float health; 
    public float attackSpeed; 
    public int position;
    public Item(string Name, string Description, float Cost){
        name = Name;
        description = Description;
        cost = Cost;
    }
}
