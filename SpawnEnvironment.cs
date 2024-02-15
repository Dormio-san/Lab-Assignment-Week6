using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnvironment : MonoBehaviour
{
    // Variable used for creation of the forest.
    public int forestSize = 25; // Number of trees.

    // Variables used for creation of the pyramid.
    public int stonesRequired = 55;
    public GameObject[] stones;
    private float offset;
    private float height = 0.5f;
    private int stopInfiniteLoop;

    void Start()
    {
        CreateGround();
        CreateForest();
        CreatePyramid();
    }

    // Spawn the ground.
    void CreateGround()
    {
        // Spawn the ground plane, set its scale, set its color, and finally, set its name.
        
        GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Plane); // Spawn the ground plane.

        ground.transform.localScale = new Vector3(5.0f, ground.transform.localScale.y, 5.0f); // Set its scale.

        ground.GetComponent<Renderer>().material.color = new Color(Random.Range(0.35f, 1.0f), 0f, 0f); // Set its color.

        ground.name = "Ground"; // Set its name.
    }

    // Spawn the forest.
    void CreateForest()
    {
        // Create an empty game object that will house each of the trees.
        GameObject forestHousing = new GameObject("Forest");
        
        // As long as the forest size has not been reached, keep spawning trees.
        for(int i = 0; i < forestSize; i++)
        {
            // Spawn the tree, give it a random scale, give it a random position, give it a random green color, name it, and finally, house it in the parent.

            GameObject tree = GameObject.CreatePrimitive(PrimitiveType.Cylinder); // Spawn the tree.

            tree.transform.localScale = new Vector3(Random.Range(0.15f, 0.85f), Random.Range(0.35f, 0.8f), Random.Range(0.15f, 0.85f)); // Set the scale.
            
            // Create temp variable that stores the tree's scale in order to get an accurate y position, so the tree does not protrude through the ground.
            float groundZero = tree.transform.localScale.y;

            // Set the position, but for the y set it to the variable created above because scale influences the tree's y position or ground zero.
            // For example, if all trees are set to zero on the y, trees that have a high y scale will protrude through the bottom of the ground.
            tree.transform.position = new Vector3(Random.Range(-20.0f, -15.5f), groundZero, Random.Range(-20.0f, -15.5f));

            tree.GetComponent<Renderer>().material.color = new Color(0f, Random.Range(0.2f, 1.0f), 0f); // Change the color of the tree.

            tree.name = "Tree"; // Name the newly created cylinders.

            tree.transform.parent = forestHousing.transform; // Set parent object.
        }
    }

    // Function that spawns the pyramid.
    void CreatePyramid()
    {
        GameObject[] stones = new GameObject[stonesRequired];

        stopInfiniteLoop = 0;

        for (int i = 0; i < stones.GetLength(0); ++i)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(i + offset, height, 0);
            //Completes a column
            for (int j = 0; j < stones.GetLength(0); ++j)
            {
                GameObject cubeColumn = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cubeColumn.transform.position = new Vector3(i + offset, height, j - 0.95f);
            }
            offset += 0.05f;
            if (i == stones.GetLength(0) - 1 && stopInfiniteLoop < stones.GetLength(0))
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