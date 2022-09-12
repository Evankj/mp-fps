using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public InputClass input;
    public InputClass previousInput;
    // Start is called before the first frame update
    void Start()
    {
        input = new InputClass();
    }

    // Update is called once per frame
    void Update()
    {
        input.UpdateInput();
        previousInput = input;
    }
}

public class InputClass
{

    public float keyHoldTime = 0.2f;
    float reloadHeldTimer;
    public float keyDoubleTapTime = 0.4f;
    float reloadDoubleTapTimer;


    public Vector2 moveVector;
    public Vector2 lookVector;
    public bool reloadDown;
    public bool reloadUp;
    public bool reloadHeld;
    public bool reloadTapped;
    public bool reloadDoubleTapped;

    public bool modifierDown;
    public bool modifierUp;
    public bool modifierHeld;
    public bool modifierTapped;
    public bool modifierDoubleTapped;

    public bool boltReleaseDown;
    public bool boltReleaseUp;
    public bool boltReleaseHeld;
    public bool boltReleaseTapped;
    public bool boltReleaseDoubleTapped;


    public void UpdateInput()
    {

        moveVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        lookVector = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        if (Input.GetKeyDown(KeyCode.R))
        {
            reloadDown = true;
            reloadHeldTimer = keyHoldTime;

        }
        reloadUp = Input.GetKeyUp(KeyCode.R);
        if (reloadUp)
        {
            reloadDown = false;
        }
        reloadTapped = reloadUp && reloadHeldTimer > 0;
        if (reloadUp)
        {
            reloadHeldTimer = 0;
        }
        reloadHeld = reloadDown && reloadHeldTimer <= 0;
        modifierHeld = Input.GetKey(KeyCode.Tab);
        boltReleaseTapped = Input.GetKeyUp(KeyCode.Q);


        HandleTimers();
    }

    void HandleTimers()
    {
        reloadHeldTimer -= Time.deltaTime;
        if (reloadHeldTimer <= 0)
        {
            reloadHeldTimer = 0;
        }

        reloadDoubleTapTimer -= Time.deltaTime;
        if (reloadDoubleTapTimer <= 0)
        {
            reloadDoubleTapTimer = 0;
        }
    }
}
