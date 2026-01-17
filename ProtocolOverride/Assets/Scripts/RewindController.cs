using UnityEngine;
using System.Collections.Generic;

public class RewindController : MonoBehaviour
{
    Rigidbody2D rb;
    List<Vector2> positions = new List<Vector2>();

    [SerializeField] int maxFrames = 60; // ~1 second

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!GlitchManager.Instance.rewindTime)
            return;

        positions.Insert(0, rb.position);

        if (positions.Count > maxFrames)
            positions.RemoveAt(positions.Count - 1);
    }

    public void Rewind()
    {
        if (positions.Count > 0)
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.rewind);

            rb.position = positions[positions.Count - 1];
            positions.Clear();
        }
    }
}
