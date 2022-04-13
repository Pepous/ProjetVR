using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    public GameObject cube;

    private float angle;

    public int rows;
    public int cols;
    public float speed;

    private List<GameObject> goInt = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int z = 0; z < rows; z++)
        {
            for (int x = 0; x < cols; x++)
            {
                var pos = new Vector3(x - cols / 2, 0, z - rows / 2);
                var go = Instantiate(cube, pos, Quaternion.identity);
                

                goInt.Add(go);
            }
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float[] waveform = AudioInput.the_waveform;
        
        for (int i = 0; i< goInt.Count; i++)
        {
                var d = new Vector3(goInt[i].transform.localPosition.x, 0,
                       goInt[i].transform.localPosition.z).magnitude;
                // Get distance
                var offset = map(d, 0, rows / 2, -Mathf.PI, Mathf.PI);
                // value d from 0, 25, to -3.14, 3.14
                var a = angle + offset;
                var h = Mathf.Floor(map(Mathf.Sin(a), -1, 1, 5, waveform[i]));

            goInt[i].transform.localScale = new Vector3(1, h, 1);
        }
        

        angle -= speed;
    }

    float map(float x, float in_min, float in_max, float out_min,
              float out_max)
    {
        return (x - in_min) * (out_max - out_min) /
                (in_max - in_min) + out_min;
    }

}

