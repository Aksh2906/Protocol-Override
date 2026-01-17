using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] float startTime = 15f;
    [SerializeField] TextMeshProUGUI timerText;

    float timeLeft;
    bool running = true;

    void Start()
    {
        timeLeft = startTime;
    }

    void Update()
    {
        if (!running) return;

        timeLeft -= Time.deltaTime;
        timerText.text = "Time Left: " + Mathf.Ceil(timeLeft).ToString();

        if (timeLeft <= 0f)
        {
            if(LevelManager.Instance.levelComplete) return;
            running = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
