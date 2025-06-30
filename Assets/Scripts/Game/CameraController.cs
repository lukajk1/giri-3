using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private int cameraSpeed;
    public Texture2D cursorTex;    
    private Vector3 cameraOffset;
    private Plyr_CamSnapIndicator snapIndicator;
    void Awake() { 
        Cursor.SetCursor(cursorTex, Vector2.zero, CursorMode.ForceSoftware);  
    }
    void Start() {
        Cursor.lockState = CursorLockMode.Confined;
        cameraOffset = transform.position;

        snapIndicator = GameObject.FindFirstObjectByType<Plyr_CamSnapIndicator>();
    }
    void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;
        UpdatePan();
        CheckSnapToPlayer();
    }
    private float distanceFromOrigin() {
        return Mathf.Sqrt(Mathf.Pow(transform.position.x - 8, 2f) + Mathf.Pow(transform.position.z + 7, 2f)); 
    }
    private void UpdatePan() {

        if ( Input.mousePosition.y >= Screen.height - 10 || Input.GetKey(KeyCode.UpArrow)) MoveCamera(1, 1);
        if (Input.mousePosition.y <= 10 || Input.GetKey(KeyCode.DownArrow)) MoveCamera(-1, -1);

        if ( Input.mousePosition.x >= Screen.width -10 || Input.GetKey(KeyCode.RightArrow)) MoveCamera(-1, 1);
        if ( Input.mousePosition.x <= 10 || Input.GetKey(KeyCode.LeftArrow)) MoveCamera(1, -1);
    }
    private void MoveCamera(int xVector, int zVector) {
        Vector3 newPos = transform.position;
        float speed = cameraSpeed * Time.deltaTime;

        newPos.x -= xVector * speed;
        newPos.z += zVector * speed;
        // add to x, subtract from z the same quantity to pan in one direction
        transform.position = newPos;
    }

    private void CheckSnapToPlayer() {
        if (Input.GetButton("SnapToPlayer")) {
            GameObject player = GameObject.Find("Player");
            Vector3 position = player.transform.position + cameraOffset;
            position.y -= 1.5f;
            transform.position = position;
            snapIndicator.Set(true);
        }
        else snapIndicator.Set(false);
    }
}
