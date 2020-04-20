using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ControllerTest : MonoBehaviour
{
    private InputController inputController;
    void Awake()
    {
        inputController = new InputController();
        inputController.Player.Jump.performed += ctx => TestInput();
    }

    private void OnEnable()
    {
        inputController.Enable();
    }

    private void OnDisable()
    {
        inputController.Disable();
    }

    private void TestInput()
    {
        Debug.Log("Input test!");
    }
}

