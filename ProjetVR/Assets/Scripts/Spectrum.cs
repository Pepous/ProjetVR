using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectrum : MonoBehaviour
{
    // prefab reference
    public GameObject the_pfCube;
    // array of game objects
    public GameObject[] the_cubes = new GameObject[512];

    // Start is called before the first frame update
    void Start()
    {


        for (int i = 0; i < the_cubes.Length; i++)
        {

            // instantiate prefab game object
            GameObject go = Instantiate(the_pfCube);
            // scale it to be 2x wider
            go.transform.localScale = new Vector3(2, 0, 1);
            // give a name
            go.name = "bin" + i;
            // set a child of this waveform
            go.transform.parent = this.transform;
            // put into array
            the_cubes[i] = go;

        }

    }

    // Update is called once per frame
    void Update()
    {
        // local reference to the spectrum
        float[] spectrum = AudioInput.the_spectrum;

        for (int i = 0; i < the_cubes.Length; i++)
        {
            float spct = 600 * Mathf.Sqrt(spectrum[i]);
            the_cubes[i].transform.localScale =
                new Vector3(spct,
                spct,
                spct);
        }
    }
}
