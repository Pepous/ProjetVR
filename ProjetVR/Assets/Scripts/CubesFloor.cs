using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CubesFloor : MonoBehaviour
{

    public GameObject cubeFloor;

    public int floorWidth = 10;
    public int floorHeight = 10;

    public float spawnSpeed = 0;

    public List<int> valManhattan = new List<int>();
    public GameObject cube;

    void Start()
    {
        StartCoroutine(CreateCubeFloor());
    }

    IEnumerator CreateCubeFloor()
    {
        for (int x = 0; x < floorWidth; x++)
        {
            yield return new WaitForSeconds(spawnSpeed);

            for (int z = 0; z < floorHeight; z++)
            {
                yield return new WaitForSeconds(spawnSpeed);

                GameObject cube = Instantiate(cubeFloor, Vector3.zero, cubeFloor.transform.rotation) as GameObject;
                cube.transform.localPosition = new Vector3(x, 0, z);
                int Manhattan = ManhattanDistance(new Vector3(0, 0, 0), new Vector3(cube.transform.localPosition.x, cube.transform.localPosition.y, cube.transform.localPosition.z));
                
                if (!(valManhattan.Contains(Manhattan)))
                {
                    valManhattan.Add(Manhattan);
                    cube.name = "cube" + Manhattan;
                }
                else
                {
                    GameObject cubeParent = GameObject.Find("cube" + Manhattan);
                    cube.transform.parent = cubeParent.transform;
                }

                

            }
        }

        valManhattan.Sort();

        
    }

    void Update()
    {
        // local reference to the spectrum
        float[] wf = AudioInput.the_waveform;

        for (int i = 0; i < valManhattan.Count; i++)
        {
            
            int v = valManhattan[i];
            GameObject cube = GameObject.Find("cube" + valManhattan[i]);

            cube.transform.localScale =
                new Vector3(cube.transform.localScale.x,
                wf[i],
                cube.transform.localScale.z);
            
            
        }
    }

    public static int ManhattanDistance(Vector3 a, Vector3 b)
    {
        checked
        {
            return (int)(Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y) + Mathf.Abs(a.z - b.z));
        }
    }
}
