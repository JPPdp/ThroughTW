using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public Vector2 teleportPosition; // Set the target teleport position in the Inspector

    void Start()
    {
        TeleportPlayer();
    }

    void TeleportPlayer()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");

        if (Player != null)
        {
            Player.transform.position = teleportPosition;
        }
        else
        {
            Debug.LogWarning("No GameObject with tag 'Player' found in the scene!");
        }
    }
}