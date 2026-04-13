using UnityEngine;
using UnityEngine.SceneManagement; // Needed to change scenes
using UnityEngine.Video; // Needed if your cutscene is a Video Player

public class MainMenuHandler : MonoBehaviour
{
    public VideoPlayer cutscenePlayer; // Drag your VideoPlayer here
    public string nextSceneName;       // Type the name of your game level here

    public void StartGame()
    {
        // 1. Play the cutscene
        cutscenePlayer.Play();

        // 2. Subscribe to the "loopPointReached" event (when the video ends)
        cutscenePlayer.loopPointReached += TransitionToScene;
    }

    void TransitionToScene(VideoPlayer vp)
    {
        // 3. Load the actual game level
        SceneManager.LoadScene(nextSceneName);
    }
}