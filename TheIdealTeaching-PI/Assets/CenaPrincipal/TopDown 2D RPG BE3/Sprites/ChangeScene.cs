using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private string sceneName;

    private void OnMouseDown()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
}

