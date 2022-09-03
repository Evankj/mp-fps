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

public class InputClass {
    public Vector2 moveVector;
    public Vector2 lookVector;

    public void UpdateInput() {
        moveVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        lookVector = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }
}
