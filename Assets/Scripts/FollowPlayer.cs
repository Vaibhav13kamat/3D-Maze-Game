using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's Transform component
    public float offset = 10.0f; // Distance offset from the player

    private Vector3 initialPosition; // Initial position of the camera

    // just a comment for the 2nd piush

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position - playerTransform.position; // Calculate initial offset
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the camera's position to be relative to the player's position with the initial offset
        transform.position = playerTransform.position + initialPosition;

        // Keep the camera's rotation as is (no rotation)
        transform.rotation = Quaternion.identity;
    }
}
