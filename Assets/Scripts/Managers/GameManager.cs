using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public PlayerHealth PlayerHealth { get; private set; }

    private void Awake()
    {
        if (instance == null)
            instance = this;

        // Player Stuff
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerHealth = player.GetComponent<PlayerHealth>();
    }
}
