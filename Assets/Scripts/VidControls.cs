using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VidControls : MonoBehaviour {
    //actual vid player
    public VideoPlayer vidPlayer;
    public GameObject vidObject;

    //clip lists
    public List<VideoClip> weddingClips = new List<VideoClip>();

    //clip counters
    public int clipCounter;

    public bool playing;

    //for fast forwarding and reversing -- 0 is normal speed
    public int playBackSpeed = 0;

    void Start () {
        vidObject.SetActive(false);
        playBackSpeed = 0;
	}
	
	void Update () {
        

        //if(vidPlayer.frame == vidPlayer.frameCount)
        //{
            //load next vid
        //}

    }

    //called from UI || -- |> 
    public void PauseNPlay()
    {
        if (playing)
        {
            vidPlayer.Pause();
            //switch UI object's sprite to play Icon
        }
        else
        {
            vidPlayer.Play();
            //switch UI object's sprite to pause Icon
        }

        playing = !playing;
    }

    //called from UI |>|>
    public void FastForward()
    {
        //increase speed
        if(playBackSpeed < 3)
        {
            playBackSpeed++;
        }
        //set back to normal
        else
        {
            playBackSpeed = 0;
        }

        //fast forward levels
        switch (playBackSpeed)
        {
            case 0:
                vidPlayer.playbackSpeed = 1;
                break;
            case 1:
                vidPlayer.playbackSpeed = 2;
                break;
            case 2:
                vidPlayer.playbackSpeed = 8;
                break;
            case 3:
                vidPlayer.playbackSpeed = 16;
                break;
        }
    }

    //called from UI <|<|
    public void Reverse()
    {
        //increase speed
        if (playBackSpeed > -3)
        {
            playBackSpeed--;
        }
        //set back to normal
        else
        {
            playBackSpeed = 0;
        }

        //reverse levels
        switch (playBackSpeed)
        {
            case 0:
                vidPlayer.playbackSpeed = 1;
                break;
            case 1:
                vidPlayer.playbackSpeed = -2;
                break;
            case 2:
                vidPlayer.playbackSpeed = -8;
                break;
            case 3:
                vidPlayer.playbackSpeed = -16;
                break;
        }
    }

    //will be called from UI |--> 
    public void ChangeClipUp()
    {
        //count up through clips
        if (clipCounter < weddingClips.Count - 1)
        {
            clipCounter++;
        }
        else
        {
            clipCounter = 0;
        }

        vidPlayer.clip = weddingClips[clipCounter];

        vidPlayer.Play();
    }

    //will be called from UI <--| 
    public void ChangeClipDown()
    {
        //count down thru clips
        if (clipCounter > 0)
        {
            clipCounter--;
        }
        else
        {
            clipCounter = weddingClips.Count - 1;
        }

        vidPlayer.clip = weddingClips[clipCounter];

        vidPlayer.Play();
    }
}
