using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GunHandler : NetworkBehaviour
{
    public Gun currentGun;
    InputHandler inputHandler;
    // Start is called before the first frame update
    void Start()
    {
        inputHandler = GetComponent<InputHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
