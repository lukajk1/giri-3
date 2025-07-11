using System.Collections.Generic;
using UnityEngine;

public class TracerManager : MonoBehaviour
{
    public static TracerManager i;

    [SerializeField] AttackTracer tracerPrefab;
    [SerializeField] int poolSize = 10;
    Queue<AttackTracer> pool = new Queue<AttackTracer>();

    void Start()
    {
        if (i != null) Debug.LogError($"More than one TracerManager in scene");
        i = this;

        for (int j = 0; j < poolSize; j++)
        {
            AttackTracer tracer = Instantiate(tracerPrefab, Vector3.zero, Quaternion.identity);
            tracer.gameObject.transform.parent = transform;
            pool.Enqueue(tracer);
        }
    }

    public void FireTracer(CombatData data)
    {
        AttackTracer tracer = pool.Dequeue();

        tracer.gameObject.SetActive(true);
        tracer.Init(data);
        pool.Enqueue(tracer);
    }
}
