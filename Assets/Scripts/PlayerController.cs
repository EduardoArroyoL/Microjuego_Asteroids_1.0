using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Collider2D playerCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        rb.gravityScale = 0;
    }

    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.gameOver)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        if (Keyboard.current == null) return;

        Vector2 movement = Vector2.zero;

        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            movement.y = 1;

        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            movement.y = -1;

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            movement.x = -1;

        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            movement.x = 1;

        rb.linearVelocity = movement.normalized * speed;


        


         // Límites de la cámara
        Vector3 position = transform.position;

        float cameraHeight = Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * Camera.main.aspect;

        // Tamaño de la hitbox
        Bounds bounds = playerCollider.bounds;

        float halfWidth = bounds.extents.x;
        float halfHeight = bounds.extents.y;

        // Limitar la nave teniendo en cuenta su hitbox
        position.x = Mathf.Clamp(
            position.x,
            -cameraWidth + halfWidth,
            cameraWidth - halfWidth
        );

        position.y = Mathf.Clamp(
            position.y,
            -cameraHeight + halfHeight,
            cameraHeight - halfHeight
        );

        transform.position = position;
    }
}