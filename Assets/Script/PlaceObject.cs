using UnityEngine;

public class PlaceObject : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Camera cam;

    [Header("Settings")]
    public bool canMove = true; 
    public float rotationStep = 15f;

    void Start()
    {
        cam = Camera.main;
    }

    void OnMouseDown()
    {
        if (canMove)
        {
            isDragging = true;
            offset = transform.position - GetMouseWorldPosition();

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    void OnMouseUp()
    {
        if (canMove)
        {
            isDragging = false;

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    void Update()
    {
        if (canMove && isDragging)
        {
            transform.position = GetMouseWorldPosition() + offset;
        }

        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RotateObject(rotationStep);
        }
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.R))
        {
            RotateObject(-rotationStep);
        }

        float scroll = Input.mouseScrollDelta.y;
        if (scroll != 0)
        {
            RotateObject(scroll * rotationStep);
        }
    }

    void RotateObject(float degrees)
    {
        transform.Rotate(0, 0, degrees);
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        return cam.ScreenToWorldPoint(mousePos);
    }
}


