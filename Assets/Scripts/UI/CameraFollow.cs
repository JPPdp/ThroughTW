using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow Instance;
    private Transform player; // Reference to the player's transform
    [SerializeField] private float smoothSpeed = 0.125f; // Speed at which the camera follows
    [SerializeField] private Vector3 offset; // Offset from the player's position

    void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        // Check if there are any player objects found
        if (players.Length > 0)
        {
            player = players[0].transform; // Assign the transform of the first player
        }
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
    
    private void LateUpdate()
    {
        if (player == null) return; // If no player is assigned, do nothing



        // Calculate the desired position with offset
        Vector3 desiredPosition = player.position + offset;
        // Smoothly interpolate between the camera's current position and the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // Set the camera's position
        transform.position = smoothedPosition;
    }
}