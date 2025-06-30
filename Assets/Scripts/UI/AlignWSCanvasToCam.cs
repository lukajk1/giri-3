using UnityEngine;

public class AlignWSCanvasToCam : MonoBehaviour
{
    private Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + Camera.main.transform.forward);

    }
}