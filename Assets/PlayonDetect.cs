using UnityEngine;
using UnityEngine.Video;
using Vuforia;

public class PlayVideoOnDetect : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    private ObserverBehaviour observerBehaviour;

    void Start()
    {
        // Get the ObserverBehaviour component
        observerBehaviour = GetComponent<ObserverBehaviour>();
        if (observerBehaviour)
        {
            observerBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }

        // Get the VideoPlayer component from the child object (VideoPlane)
        videoPlayer = GetComponentInChildren<VideoPlayer>();
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
        {
            // Start playing the video when the target is recognized
            videoPlayer.Play();
        }
        else
        {
            // Pause the video when the target is lost
            videoPlayer.Pause();
        }
    }

    private void OnDestroy()
    {
        if (observerBehaviour)
        {
            observerBehaviour.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }
}