using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnvironment : MonoBehaviour
{
    private int forestSize = 20;    

    void Start()
    {
        CreateGround();
        CreateForest();
    }

    // Spawn the ground.
    void CreateGround()
    {
        GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Plane); // Spawn the ground plane.
        ground.transform.localScale = new Vector3(5.0f, ground.transform.localScale.y, 5.0f); // Set its scale.
        ground.name = "Ground"; // Set its name to Ground.
    }

    // Spawn the forest.
    void CreateForest()
    {
        // Create an empty game object that will house each of the trees.
        GameObject forestHousing = new GameObject("Forest");
        
        // As long as the forest size has not been reach, keep spawning trees.
        for(int i = 0; i < forestSize; i++)
        {
            GameObject tree = GameObject.CreatePrimitive(PrimitiveType.Cylinder); // Spawn the tree.
            tree.transform.localScale = new Vector3(Random.Range(0.2f, 0.5f), Random.Range(0.5f, 1.5f),Random.Range(0.2f, 0.5f)); // Set the scale.
            tree.transform.position = new Vector3(Random.Range(-20.0f, -15.0f), 0f, Random.Range(-20.0f, -15.0f)); // Set the position.
            tree.GetComponent<Renderer>().material.color = new Color(0f, Random.Range(.3f, 1.0f), 0f); // Change the color of the tree.
            tree.name = "Tree"; // Name the newly created cylinders.
            tree.transform.parent = forestHousing.transform; // Set parent object.
        }
    }
}