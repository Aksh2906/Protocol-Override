using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Sprite OpenGateSprite;
    public static LevelManager Instance;
    
    public LevelLoader levelLoader;
    public bool levelComplete = false;

    public void Awake()
    {
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(levelLoader.LoadNextLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && this.GetComponent<SpriteRenderer>().sprite == OpenGateSprite)
        {
            Debug.Log("Level Complete!");
            levelComplete = true;
            NextLevel();
        }
    }
}
