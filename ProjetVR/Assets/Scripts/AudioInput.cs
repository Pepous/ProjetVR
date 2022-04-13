using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInput : MonoBehaviour
{
    bool play;
    bool toggleChange;
    // The audio source
    public AudioSource the_audioSource;
    public AudioClip[] listeMusiques;
    // time domain waveforms (mono)
    public static float[] the_waveform = new float[1024];
    //magnitude spectrum
    public static float[] the_spectrum = new float[512];

    // Start is called before the first frame update
    void Start()
    {
        // get audio source r�f�rence the game object
        the_audioSource = GetComponent<AudioSource>();
        the_audioSource.loop = true;
        play = true;
    }

    // Update is called once per frame
    void Update()
    {
        // get the time domain waveforce
        the_audioSource.GetOutputData(the_waveform, 0);
        // get the magnitude
        the_audioSource.GetSpectrumData(the_spectrum, 0, FFTWindow.Hanning);

    }
    public void Play()
    {
        the_audioSource.Play();
    }
    public void Pause()
    {
        the_audioSource.Pause();
    }
    void OnGUI()
    {
        //Switch this toggle to activate and deactivate the parent GameObject
        play = GUI.Toggle(new Rect(10, 10, 100, 30), play, "Play Music");

        //Detect if there is a change with the toggle
        if (GUI.changed)
        {
            //Change to true to show that there was just a change in the toggle state
            toggleChange = true;
        }
    }
}
