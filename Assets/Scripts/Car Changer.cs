using System.Collections.Generic;
using UnityEngine;

public class CarChanger : MonoBehaviour
{
    [System.Serializable]
    public class CarChange
    {
        public List<GameObject> initialPlayers; // List of initial player cars
        public GameObject targetPlayer; // The target car to change to
    }

    public CarChange carChange; // Single car change configuration
    public FollowPlayer cameraFollow; // Reference to the FollowPlayer script

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider that entered is one of the initial players
        foreach (var initialPlayer in carChange.initialPlayers)
        {
            if (other.gameObject == initialPlayer)
            {
                ChangeCar();
                break; // Exit the loop once a match is found
            }
        }
    }

    private void ChangeCar()
    {
        string cubeName = gameObject.name; // Get the name of the cube

        // Log which car is being changed
        Debug.Log($"Changing based on cube: {cubeName}");

        // Hide all initial players
        foreach (var initialPlayer in carChange.initialPlayers)
        {
            initialPlayer.SetActive(false);
        }
        
        // Unhide the target player
        carChange.targetPlayer.SetActive(true);

        // Set the position of the target player to the position of one of the initial players (e.g., the first one)
        carChange.targetPlayer.transform.position = carChange.initialPlayers[0].transform.position;
        carChange.targetPlayer.transform.rotation = carChange.initialPlayers[0].transform.rotation;

        // Set the camera to follow the new player
        cameraFollow.SetPlayer(carChange.targetPlayer);
    }
}
