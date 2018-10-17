using RenderHeads.Media.AVProVideo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoCtr : MonoBehaviour {
    public MediaPlayer mediaPlayer;
    public DisplayUGUI displayUGUI;
	// Use this for initialization

    private void showVideo() {
        displayUGUI.GetComponent<Animator>().SetBool("Show", true);
    }

    private void HideVideo() {
        displayUGUI.GetComponent<Animator>().SetBool("Show", false);
    }

    public void PlayVideo(string path, bool loop = true) {
        showVideo();
        mediaPlayer.Control.SetLooping(loop);
        mediaPlayer.OpenVideoFromFile(MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder, path,true);
    }

    public void StopVideo() {
        HideVideo();
        mediaPlayer.Stop();
    }
}
