using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverScreen : MonoBehaviour
{
    public void ToMainMenu(){
        SceneManager.LoadScene("Main Menu");
    }
}
