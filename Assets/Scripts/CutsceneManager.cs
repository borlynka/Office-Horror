using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; 
using System.Linq; // <--- This was the missing piece!

public class CutsceneManager : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += TransitionToGame;
        }
    }

    void Update()
    {
        // Check for any keyboard press
        if (Keyboard.current != null && Keyboard.current.anyKey.wasPressedThisFrame)
        {
            TransitionToGame(videoPlayer);
        }

        // Check for any gamepad button press (much cleaner version)
        if (Gamepad.current != null && Gamepad.current.allControls.Any(x => x is UnityEngine.InputSystem.Controls.ButtonControl button && button.wasPressedThisFrame))
        {
            TransitionToGame(videoPlayer);
        }
        
        // Also check for mouse click to be safe
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            TransitionToGame(videoPlayer);
        }
    }

    void TransitionToGame(VideoPlayer vp)
    {
        // Unsubscribe to prevent memory leaks or double-loading
        vp.loopPointReached -= TransitionToGame;
        SceneManager.LoadScene("Main Game");
    }
}