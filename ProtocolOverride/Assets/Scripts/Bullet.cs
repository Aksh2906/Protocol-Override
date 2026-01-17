using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int direction = 1;

    void Update()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.stoneHit);
        if (GlitchManager.Instance.phaseBullets &&
            collision.gameObject.CompareTag("Wall"))
        {
            Physics2D.IgnoreCollision(
                collision.collider,
                GetComponent<Collider2D>()
            );
            return;
        }
        Debug.Log("Bullet collided with " + collision.gameObject.name);

        Destroy(gameObject);
    }
}