using UnityEngine;

public class EnemyList : MonoBehaviour
{

    [SerializeField] public AudioClip enemyTakeDamage;

    #region singleton pattern
    public static EnemyList i;
    void Awake()
    {
        if (i == null) i = this; // no need to handle destruction since parent game manager does
    }
    #endregion
}