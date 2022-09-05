using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public InputClass input;

    // Start is called before the first frame update
    void Start()
    {
        input = new InputClass();
    }

    // Update is called once per frame
    void Update()
    {
        input.UpdateInput();
    }
}

public class InputClass
{
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
        reloadHeld = Input.GetKey(KeyCode.R);
        reloadUp = Input.GetKeyUp(KeyCode.R);
        modifierHeld = Input.GetKey(KeyCode.Tab);
        boltReleaseTapped = Input.GetKeyUp(KeyCode.Q);
    }
}
