using UnityEngine;

public class AlignWSCanvasToCam : MonoBehaviour
{
    [SerializeField] private bool isChildToATransform;
    private Camera cam;
    private Transform parentTransform;
    private Vector3 worldOffset = Vector3.zero;

    private void Start()
    {
        cam = Camera.main;
        parentTransform = transform.parent;
        if (isChildToATransform) worldOffset = transform.position - parentTransform.position;
    }

    private void LateUpdate()
    {
        if (isChildToATransform) transform.position = parentTransform.position + worldOffset;
        transform.LookAt(transform.position + cam.transform.forward);
    }
}
