using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    [Header("Follow")]
    [SerializeField] Transform target;
    [SerializeField] float smoothSpeed = 5f;
    [SerializeField] Vector3 offset;

    [Header("Shake")]
    [SerializeField] float shakeDuration = 0.1f;
    [SerializeField] float shakeMagnitude = 0.15f;

    [Header("Damage Flash")]
    [SerializeField] SpriteRenderer redFlash;
    [SerializeField] float flashDuration = 0.15f;

    Vector3 originalPosition;
    Coroutine shakeRoutine;
    Coroutine flashRoutine;

    void LateUpdate()
    {
        if (!target) return;

        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );
    }

    // ---------------- SHAKE ----------------
    public void Shake()
    {
        if (shakeRoutine != null)
            StopCoroutine(shakeRoutine);

        shakeRoutine = StartCoroutine(ShakeRoutine());
    }

    IEnumerator ShakeRoutine()
    {
        originalPosition = transform.localPosition;

        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            Vector2 randomOffset = Random.insideUnitCircle * shakeMagnitude;
            transform.localPosition = originalPosition + (Vector3)randomOffset;

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPosition;
    }

    // ---------------- DAMAGE FLASH ----------------
    public void FlashRed()
    {
        if (flashRoutine != null)
            StopCoroutine(flashRoutine);

        flashRoutine = StartCoroutine(FlashRoutine());
    }

    IEnumerator FlashRoutine()
    {
        redFlash.color = new Color(1, 0, 0, 0.6f);
        yield return new WaitForSeconds(flashDuration);
        redFlash.color = new Color(1, 0, 0, 0);
    }
}
