using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public PlayerHealth PlayerHealth { get; private set; }


    public GameObject Ui;
    public HealthBar healthbar;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        // Player Stuff
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerHealth = player.GetComponentInChildren<PlayerHealth>();

        // Ui Stuff
        Ui = GameObject.FindGameObjectWithTag("UI");
        healthbar = Ui.GetComponentInChildren<HealthBar>();

    }
}
