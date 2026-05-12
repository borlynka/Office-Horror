using UnityEngine;

public class HorrorSoundManager : MonoBehaviour
{
    [System.Serializable]
    public class HorrorSound
    {
        public AudioClip clip;
        public float volume = 0.8f;
        public float spatialBlend = 0.7f;
        public float pitchMin = 0.95f;
        public float pitchMax = 1.05f;
        public float maxPlayTime = 2.5f; // cuts sound after this many seconds
    }

    public AudioSource audioSource;
    public HorrorSound[] scarySounds;

    public int minimumFearLevel = 2;

    public void TryPlayScarySound()
    {
        if (HorrorProgress.fearLevel < minimumFearLevel)
            return;

        if (scarySounds.Length == 0 || audioSource == null)
            return;

        int index = Random.Range(0, scarySounds.Length);
        HorrorSound sound = scarySounds[index];

        if (sound.clip == null)
            return;

        audioSource.Stop();

        audioSource.clip = sound.clip;
        audioSource.volume = sound.volume;
        audioSource.spatialBlend = sound.spatialBlend;
        audioSource.pitch = Random.Range(sound.pitchMin, sound.pitchMax);

        audioSource.Play();

        CancelInvoke(nameof(StopSound));
        Invoke(nameof(StopSound), sound.maxPlayTime);
    }

    void StopSound()
    {
        if (audioSource != null)
            audioSource.Stop();
    }
}