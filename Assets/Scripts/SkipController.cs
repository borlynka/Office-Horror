using UnityEngine;
using UnityEngine.SceneManagement; // Add this line!

public class SkipController : MonoBehaviour
{
    public void GoToMainGame()
    {
        SceneManager.LoadScene("Main Game");
    }
}