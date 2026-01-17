using UnityEngine;
using UnityEngine.SceneManagement;
public class MovingSpikes : MonoBehaviour
{
    private float speed = 4f;
    [SerializeField] private float startX;
    [SerializeField] private float endX;

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if(transform.position.x>=endX)
        {
            Vector2 pos = new Vector2(startX, transform.position.y);
            transform.position = pos;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(LevelManager.Instance.levelComplete) return;
            //start courtine of dead player using masked img
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }
}
