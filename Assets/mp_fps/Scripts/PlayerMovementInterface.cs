using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementInterface : MonoBehaviour
{

    InputHandler inputHandler;
    MovementHandler movementHandler;
    // Start is called before the first frame update
    void Start()
    {
        inputHandler = GetComponent<InputHandler>();
        movementHandler = GetComponent<MovementHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        movementHandler.SetMoveVector(inputHandler.input.moveVector);
    }
}
