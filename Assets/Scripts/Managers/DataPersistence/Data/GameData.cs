using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData {
    public int highScore;

    public GameData() { //default values
        this.highScore = 0;
    }

}