using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainGame : MonoBehaviour
{
    public void MoveToNextScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
