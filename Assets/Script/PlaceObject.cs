using UnityEngine;

public class PlaceObject : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPosition();

        // Optional: turn off physics while dragging
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void OnMouseUp()
    {
        isDragging = false;

        // Turn physics back on when you drop it
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.bodyType = RigidbodyType2D.Dynamic;
    }

    void Update()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPosition() + offset;
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f; // distance from camera
        return cam.ScreenToWorldPoint(mousePos);
    }
}
