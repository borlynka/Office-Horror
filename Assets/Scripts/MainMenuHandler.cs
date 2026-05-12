using UnityEngine;
using UnityEngine.SceneManagement; // Needed to change scenes
using UnityEngine.Video; // Needed if your cutscene is a Video Player

public class MainMenuHandler : MonoBehaviour
{
    public VideoPlayer cutscenePlayer; // Drag your VideoPlayer here
    public string nextSceneName;       // Type the name of your game level here

    public void StartGame()
    {
        SceneManager.LoadScene("Begin Cutscene"); 
    }
    public void options(){
        SceneManager.LoadScene("options");
    }
    void TransitionToScene(VideoPlayer vp)
    {
        // 3. Load the actual game level
        SceneManager.LoadScene(nextSceneName);
    }
}