using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CercleWaveform : MonoBehaviour
{
    // prefab reference
    public GameObject the_pfCube;
    // array of game objects
    public GameObject[] the_cubes = new GameObject[1024];

    public float radius = 500;

    // Start is called before the first frame update
    void Start()
    {
        

        for (int i = 0; i < the_cubes.Length; i++)
        {
            float angle = i * Mathf.PI * 2 / the_cubes.Length;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            Vector3 pos = transform.position + new Vector3(x, 0, z);
            float angleDegrees = -angle * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.Euler(0, angleDegrees, 0);
            // instantiate prefab game object
            GameObject go = Instantiate(the_pfCube, pos, rot);
            // color material
            go.GetComponent<Renderer>().material.SetColor("_BaseColor", new Color(.5f, .5f, 1));
            // give a name
            go.name = "cube" + i;
            // set a child of this waveform
            go.transform.parent = this.transform;
            // put into array
            the_cubes[i] = go;

        }
        

    }

    // Update is called once per frame
    void Update()
    {
        // local reference to the time domain waveform
        float[] wf = AudioInput.the_waveform;

        // position the cubes
        for (int i = 0; i < the_cubes.Length; i++)
        {
            the_cubes[i].transform.localPosition =
                new Vector3(the_cubes[i].transform.localPosition.x,
                          100 * wf[i],
                            the_cubes[i].transform.localPosition.z);
        }

    }
}
