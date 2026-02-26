using UnityEngine;
using UnityEngine.InputSystem;

public class GatherInput : MonoBehaviour
{
    private Controls myControls;

    public float valueX;

    private void Awake()
    {
        myControls = new Controls();
    }

    private void Update()
    {
        OnMove();
    }

    public void OnMove()
    {
        Vector2 moveInput = myControls.Player.Move.ReadValue<Vector2>();

        valueX = moveInput.x;
    }

    private void OnEnable()
    {
        myControls.Player.Enable();
    }

    private void OnDisable()
    {
        myControls.Player.Disable();
    }
}