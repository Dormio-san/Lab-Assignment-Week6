using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnvironment : MonoBehaviour
{
    // Variable used for creation of the forest.
    public int forestSize = 25; // Number of trees.

    //-------------------------------------------
    // Variables used for creation of the pyramid.
    //Length of pyramid in cubes
    public int lengthOfPyramid = 9;
    //Height of pyramid in cubes
    public int heightOfPyramid = 5;

    //This makes the pyramid center itself
    private int offset = 0;

    //Colors the pyramid
    private Color color;

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
            tree.transform.position = new Vector3(Random.Range(-11.5f, -5f), groundZero, Random.Range(0.5f, 6.5f));

            tree.GetComponent<Renderer>().material.color = new Color(0f, Random.Range(0.2f, 1.0f), 0f); // Change the color of the tree.

            tree.name = "Tree"; // Name the newly created cylinders.

            tree.transform.parent = forestHousing.transform; // Set parent object.
        }
    }

    // Function that spawns the pyramid.
    void CreatePyramid()
    {
        //Assigns all objects to parent "Pyramid"
        GameObject WholePyramid = new GameObject("Pyramid");
        //Assign random color for each height
        color = new Color(Random.Range(0.1f, 1.0f), Random.Range(0.1f, 1.0f), Random.Range(0.1f, 1.0f), Random.Range(0.1f, 1.0f));
        //Gets length to make pyramid
        int length = lengthOfPyramid;

        //Start construction and stops at desired height
        for (int h = 0; h < heightOfPyramid; ++h)
        {
            //Constructs length, only a line of cubes
            for (int l = 0 + offset; l < length; ++l)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                // The 0.5f added to the y value is to move the pyramid up so it does not clip into the plane
                cube.transform.position = new Vector3(l, h + 0.5f, offset);
                cube.GetComponent<Renderer>().material.color = color;
                //Assign to parent
                cube.transform.parent = WholePyramid.transform;
                //Stretches the line of cubes to the equal width
                for (int w = 0 + offset; w < length; ++w)
                {
                    GameObject line = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    line.GetComponent<Renderer>().material.color = color;
                    line.transform.position = new Vector3(l, h + 0.5f, w);
                    line.transform.parent = WholePyramid.transform;
                }
            }
            //These are needed to make the pyramid shape
            length--;
            offset++;
            //Random color for each height
            color = new Color(Random.Range(0.1f, 1.0f), Random.Range(0.1f, 1.0f), Random.Range(0.1f, 1.0f), Random.Range(0.1f, 1.0f));
        }
    }
}