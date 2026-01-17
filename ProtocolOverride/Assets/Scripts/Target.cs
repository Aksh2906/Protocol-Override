using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    [SerializeField] SpriteRenderer GateImage;
    [SerializeField] Sprite OpenGateSprite;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Bullet"))
        {
            //Open Gate
            GateImage.sprite = OpenGateSprite;
            AudioManager.Instance.PlaySFX(AudioManager.Instance.exitButton);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Bullet"))
        {
            //Open Gate
            GateImage.sprite = OpenGateSprite;
            AudioManager.Instance.PlaySFX(AudioManager.Instance.exitButton);
        }
    }
}
