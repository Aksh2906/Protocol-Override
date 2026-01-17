using UnityEngine;
using System.Collections;
public class RedPlatform : MonoBehaviour
{
    EdgeCollider2D col;
    [SerializeField] private bool kill =false;
    [SerializeField] private bool osc = false;
    [SerializeField] private float moveDistance = 1.2f;
    [SerializeField] private float speed = 2f;

    [SerializeField] private Animator playerAnim;

    Vector3 startPos;
    float timer;

    void Awake()
    {
        playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    void Start()
    {
        startPos = transform.position;
        timer = Random.Range(0f, 2f); // desync spikes
        col = GetComponent<EdgeCollider2D>();
    }

    void Update()
    {
        if(!kill)
        {
            if (GlitchManager.Instance.redSolid)
                col.isTrigger = false;

        }
        if(!osc) return;
        timer += Time.deltaTime * speed;
        float offset = Mathf.Sin(timer) * moveDistance;
        transform.position = startPos + Vector3.up * offset;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(kill)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if(LevelManager.Instance.levelComplete) return;
                StartCoroutine(RestartLevelWithDelay(0.5f, UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex));
                //Restart Level with husrt animation
                
                
            }
        }
    }

    IEnumerator RestartLevelWithDelay(float delay, int buildIndex)
    {
        playerAnim.SetInteger("State", 5); // Hurt animation
        yield return new WaitForSeconds(delay);
        UnityEngine.SceneManagement.SceneManager.LoadScene(buildIndex);
    }
}
