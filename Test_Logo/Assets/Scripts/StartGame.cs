using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Animator fader;
    public void startGame()
    {
        StartCoroutine(_start());
    }
    private IEnumerator _start()
    {
        fader.SetTrigger("Fade");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
}
