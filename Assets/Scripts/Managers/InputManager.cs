using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get { return instance; } }

    public GameInput gameInput;

    public GameInput.GameplayActions GameplayActions { get; private set; }

    private PlayerHealth PlayerHealth { get; set; }
    private PlayerMovement PlayerMovement { get; set; }
    private ActiveWeapon ActiveWeapon { get; set; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);  

        gameInput = new GameInput();
        GameplayActions = gameInput.Gameplay;

        // Player Stuff
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerHealth = player.GetComponent<PlayerHealth>();
        PlayerMovement = player.GetComponent<PlayerMovement>();
        ActiveWeapon = player.GetComponent<ActiveWeapon>();

        GameplayActions.Attack.performed += ctx => ActiveWeapon.OnAttack();

        /* Debug / Testing */
        GameplayActions.Duck.performed += ctx => PlayerMovement.OnDuck();
    }

    private void OnEnable()
    {
        GameplayActions.Enable();
    }

    private void OnDisable()
    {
        GameplayActions.Disable();
    }
}
