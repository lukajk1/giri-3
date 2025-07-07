using System.Collections;
using UnityEngine;

public class MoveCursor : MonoBehaviour
{
    float delay = 0.35f;
    Coroutine cr;
    MeshRenderer mr;
    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
        mr.enabled = false;
    }
    public void MoveCommand(Vector3 pos)
    {
        mr.enabled = true;

        transform.position = pos;
        if (cr != null)
        {
            StopCoroutine(cr);
        }
        cr = StartCoroutine(DelayCR());
    }

    private IEnumerator DelayCR()
    {
        yield return new WaitForSeconds(delay);
        mr.enabled = false;
    }
}