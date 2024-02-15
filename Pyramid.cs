using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyramid : MonoBehaviour
{
    public int stonesRequired;
    public GameObject[] stones;
    private float offset;
    private float height = 0.5f;
    private int stopInfiniteLoop;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] stones = new GameObject[stonesRequired];
        
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        
        plane.GetComponent<Renderer>().material.color = Color.red;
        stopInfiniteLoop = 0;
        
        for(int i = 0; i < stones.GetLength(0); ++i)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(i + offset, height, 0);
            //Completes a column
            for(int j = 0; j < stones.GetLength(0); ++j)
            {
                GameObject cubeColumn = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cubeColumn.transform.position = new Vector3(i + offset, height, j - 0.95f);
            }
            offset += 0.05f;
            if(i == stones.GetLength(0) - 1 && stopInfiniteLoop < stones.GetLength(0))
            {
                height++;
                i = 0;
                Debug.Log("Reached");
            }
            ++stopInfiniteLoop;
        }

        /*offset = 0;
        for (int i = 0; i < stones.GetLength(0) - 1; ++i)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(i + offset + 0.25f, 1.5f, 0.25f);

            //Completes a column
            for (int j = 0; j < stones.GetLength(0); ++j)
            {
                GameObject cubeColumn = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cubeColumn.transform.position = new Vector3(i + offset + 0.25f, 1.5f, j - 0.95f + 0.25f);
            }
            offset += 0.05f;
        } */
    }
}
