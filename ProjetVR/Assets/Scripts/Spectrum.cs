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
        
        float x = -512, y = 0, z = 0;
        // calculate
        float xIncrement = the_pfCube.transform.localScale.x * 2;

        for (int i = 0; i < the_cubes.Length; i++)
        {
            
            // instantiate prefab game object
            GameObject go = Instantiate(the_pfCube);
            // color material
            go.GetComponent<Renderer>().material.SetColor("_BaseColor", new Color(.5f, 1, .5f));
            // default position
            go.transform.position = new Vector3(x, y, z);
            // increment the x position
            x += xIncrement;
            // scale it to be 2x wider
            go.transform.localScale = new Vector3(2, 0, 1);
            // give a name
            go.name = "bin" + i;
            // set a child of this waveform
            go.transform.parent = this.transform;
            // put into array
            the_cubes[i] = go;

        }
        //position this
        this.transform.position = new Vector3(this.transform.position.x, -100, this.transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        // local reference to the spectrum
        float[] spectrum = AudioInput.the_spectrum;

        for(int i = 0; i < the_cubes.Length; i++)
        {
            float y = 600 * Mathf.Sqrt(spectrum[i]);
            the_cubes[i].transform.localScale =
                new Vector3(the_cubes[i].transform.localScale.x,
                y,
                the_cubes[i].transform.localScale.z);
            the_cubes[i].transform.localPosition =
                new Vector3(the_cubes[i].transform.localPosition.x,
                y/2,
                the_cubes[i].transform.localPosition.y);
        }
    }
}
