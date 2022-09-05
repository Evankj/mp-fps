using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkComponentHandler : NetworkBehaviour
{
    public Behaviour[] localBehaviours;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Behaviour behaviour in localBehaviours) {
            behaviour.enabled = isLocalPlayer;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
