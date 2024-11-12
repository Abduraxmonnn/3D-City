using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player; // Reference to the player
    public float distance = 15.0f; // Distance behind the player
    public float height = 7.0f; // Height above the player

    // LateUpdate is called after all Update methods
    void LateUpdate()
    {
        if (player != null) // Check if the player reference is set
        {
            // Get the player's position and rotation
            Vector3 playerPosition = player.transform.position;
            Quaternion playerRotation = player.transform.rotation;

            // Calculate the desired camera position
            Vector3 offset = playerRotation * new Vector3(0, height, -distance);
            transform.position = playerPosition + offset;

            // Optionally, make the camera look at the player
            transform.LookAt(player.transform);
        }
    }

    // Method to set the player reference
    public void SetPlayer(GameObject newPlayer)
    {
        player = newPlayer;
    }
}
