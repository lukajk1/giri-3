using UnityEngine;

public class AlignWSCanvasToCam : MonoBehaviour
{
    private Camera cam;
    private Transform parentTransform;
    private Vector3 worldOffset;

    private void Start()
    {
        cam = Camera.main;
        parentTransform = transform.parent;
        worldOffset = transform.position - parentTransform.position;
    }

    private void LateUpdate()
    {
        transform.position = parentTransform.position + worldOffset;
        transform.LookAt(transform.position + cam.transform.forward);
    }
}
