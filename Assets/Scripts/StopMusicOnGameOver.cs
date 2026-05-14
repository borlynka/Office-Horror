using UnityEngine;

public class StopMusicOnGameOver : MonoBehaviour
{
    void Start()
    {
        BackgroundMusicManager music = FindObjectOfType<BackgroundMusicManager>();

        if (music != null)
        {
            Destroy(music.gameObject);
        }
    }
}