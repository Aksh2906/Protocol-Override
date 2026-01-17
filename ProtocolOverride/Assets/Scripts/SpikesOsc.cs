using UnityEngine;

public class SpikesOsc : MonoBehaviour
{
    [SerializeField] private bool osc = false;
    [SerializeField] private float moveDistance = 1.2f;
    [SerializeField] private float speed = 2f;

    Vector3 startPos;
    float timer;

    void Start()
    {
        startPos = transform.position;
        timer = Random.Range(0f, 2f); // desync spikes
    }

    void Update()
    {
        if(!osc) return;
        timer += Time.deltaTime * speed;
        float offset = Mathf.Sin(timer) * moveDistance;
        transform.position = startPos + Vector3.up * offset;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(LevelManager.Instance.levelComplete) return;
            // Restart the level on player collision
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
            );
        }
    }
}
