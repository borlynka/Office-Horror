using UnityEngine;

public class OfficeDistortionManager : MonoBehaviour
{
    public GameObject normalOffice;
    public GameObject crowdedOffice;
    public GameObject nightmareOffice;

    public int crowdedSuspicionLevel = 10;
    public int nightmareFearLevel = 12;

    void Start()
    {
        UpdateOfficeStage();
    }

    public void UpdateOfficeStage()
    {
        if (normalOffice != null)
            normalOffice.SetActive(true);

        if (crowdedOffice != null)
            crowdedOffice.SetActive(false);

        if (nightmareOffice != null)
            nightmareOffice.SetActive(false);

        if (HorrorProgress.suspicionLevel >= crowdedSuspicionLevel)
        {
            if (normalOffice != null)
                normalOffice.SetActive(false);

            if (crowdedOffice != null)
                crowdedOffice.SetActive(true);
        }

        if (HorrorProgress.fearLevel >= nightmareFearLevel)
        {
            if (normalOffice != null)
                normalOffice.SetActive(false);

            if (crowdedOffice != null)
                crowdedOffice.SetActive(false);

            if (nightmareOffice != null)
                nightmareOffice.SetActive(true);
        }
    }
}