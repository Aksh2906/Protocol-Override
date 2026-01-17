using UnityEngine;
using TMPro;

public class MovingTXT : MonoBehaviour
{
    [SerializeField] float speed = 150f;

    RectTransform rectTransform;
    Vector2 direction = Vector2.one.normalized;
    RectTransform canvasRect;
    TextMeshProUGUI txt;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasRect = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        txt = GetComponent<TextMeshProUGUI>();

    }

    void Update()
    {
        float hue = Mathf.PingPong(Time.time * speed, 2f);
        txt.color = Color.HSVToRGB(hue, 1f, 1f);
        rectTransform.anchoredPosition += direction * speed * Time.deltaTime;

        Vector2 pos = rectTransform.anchoredPosition;
        Vector2 size = rectTransform.sizeDelta;
        Vector2 canvasSize = canvasRect.sizeDelta;

        // Right
        if (pos.x + size.x / 2 > canvasSize.x / 2)
            direction.x *= -1;

        // Left
        if (pos.x - size.x / 2 < -canvasSize.x / 2)
            direction.x *= -1;

        // Top
        if (pos.y + size.y / 2 > canvasSize.y / 2)
            direction.y *= -1;

        // Bottom
        if (pos.y - size.y / 2 < -canvasSize.y / 2)
            direction.y *= -1;
    }
}
