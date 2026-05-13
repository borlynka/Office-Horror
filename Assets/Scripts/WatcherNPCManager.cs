using UnityEngine;

public class WatcherNPCManager : MonoBehaviour
{
    public GameObject watcherPrefab;
    public Transform[] spawnPoints;

    public int minimumFearLevel = 3;
    public float appearChance = 0.5f;
    public float disappearAfterSeconds = 4f;

    private GameObject currentWatcher;

    public int minimumSuspicionLevel = 5;

    public void TrySpawnWatcher()
    {
        if (HorrorProgress.fearLevel < minimumFearLevel && HorrorProgress.suspicionLevel < minimumSuspicionLevel)
            return;

        if (currentWatcher != null)
            return;

        if (watcherPrefab == null || spawnPoints.Length == 0)
            return;

        float roll = Random.value;

        if (roll > appearChance)
            return;

        int index = Random.Range(0, spawnPoints.Length);

        currentWatcher = Instantiate(
            watcherPrefab,
            spawnPoints[index].position,
            spawnPoints[index].rotation
        );

        WatcherMoveWhenNotSeen moveScript =
            currentWatcher.AddComponent<WatcherMoveWhenNotSeen>();

        moveScript.playerCamera = Camera.main;
        moveScript.playerTarget = Camera.main.transform;

        Invoke(nameof(RemoveWatcher), disappearAfterSeconds);
    }

    void RemoveWatcher()
    {
        if (currentWatcher != null)
        {
            Destroy(currentWatcher);
            currentWatcher = null;
        }
    }
}