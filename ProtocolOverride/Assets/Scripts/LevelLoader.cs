using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
    public float transitionTime = 1f;
    public Animator transitionAnim;

    public IEnumerator LoadNextLevel(int levelIndex)
    {
        AudioManager.Instance.PlayTransition();
        yield return new WaitForSeconds(0.5f);
        transitionAnim.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelIndex);
    }
}
