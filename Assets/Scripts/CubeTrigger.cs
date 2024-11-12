using UnityEngine;

public class CubeTrigger : MonoBehaviour
{
    public GameObject playerCar; // Reference to the player car
    public GameObject carPrefabRed; // Car prefab for Red Rotate
    public GameObject carPrefabGreen; // Car prefab for Green Rotate
    // Add more car prefabs as needed

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider that entered is the player car
        if (other.gameObject == playerCar)
        {
            ChangeCar();
        }
    }

    private void ChangeCar()
    {
        string cubeName = gameObject.name; // Get the name of the cube
        GameObject newCarPrefab = null;

        // Determine which car prefab to use based on the cube's name
        switch (cubeName)
        {
            case "Red Rotate":
                newCarPrefab = carPrefabRed;
                Debug.Log("Changing to Red Car");
                break;

            case "Green Rotate":
                newCarPrefab = carPrefabGreen;
                Debug.Log("Changing to Green Car");
                break;

            // Add more cases for other cube names as needed
            default:
                Debug.Log("No car change defined for this cube.");
                return;
        }

        // Instantiate the new car
        Instantiate(newCarPrefab, playerCar.transform.position, playerCar.transform.rotation);

        // Optionally destroy or deactivate the old car
        Destroy(playerCar); // or playerCar.SetActive(false);
        playerCar = null; // Clear the reference if needed
    }
}
