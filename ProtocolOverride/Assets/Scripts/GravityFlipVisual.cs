using UnityEngine;

public class GravityFlipVisual : MonoBehaviour
{
    Rigidbody2D rb;
    float horizontal;
    bool isUpsideDown = false;
    bool facingRight = true;

    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        
        // Detect if gravity has changed
        isUpsideDown = rb.gravityScale < 0;

        ApplyRotation();
    }

    void ApplyRotation()
    {
        float yRotation = 0f;
        float zRotation = 0f;

        // 1. Determine Horizontal Facing
        if (horizontal > 0) facingRight = true;
        else if (horizontal < 0) facingRight = false;

        // 2. Calculate Y Rotation (Facing)
        // If we are upside down, the horizontal axis is naturally inverted, 
        // so we compensate for that.
        if (facingRight)
        {
            yRotation = isUpsideDown ? 180f : 0f;
        }
        else
        {
            yRotation = isUpsideDown ? 0f : 180f;
        }

        // 3. Calculate Z Rotation (Gravity)
        zRotation = isUpsideDown ? 180f : 0f;

        // Apply the calculated rotation
        transform.rotation = Quaternion.Euler(0, yRotation, zRotation);
    }
}