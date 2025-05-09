using UnityEngine;
using UnityEngine.InputSystem;  // Required for new input system

public class LifeTester : MonoBehaviour
{
    private Controls controls;  // Use the name of your generated class

    void Awake()
    {
        controls = new Controls();
        controls.Test.LoseLife.performed += ctx => LoseLife();
    }

    void OnEnable()
    {
        controls.Test.Enable();
    }

    void OnDisable()
    {
        controls.Test.Disable();
    }

    void LoseLife()
    {
        Debug.Log("Lose Life triggered!");
        GameManager.Instance.LoseLife();
    }
}
