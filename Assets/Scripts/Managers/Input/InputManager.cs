using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get { return instance; } }

    public GameInput gameInput;

    public GameInput.GameplayActions GameplayActions { get; private set; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);  

        gameInput = new GameInput();
        GameplayActions = gameInput.Gameplay;
    }
}
