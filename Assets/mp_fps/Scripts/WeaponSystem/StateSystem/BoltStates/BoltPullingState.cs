using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltPullingState : IBoltState
{
    public IBoltState DoState(Gun gun)
    {
        // We've finished pulling it open
        if (gun.boltStateTimer <= 0)
        {
            return gun.boltHeldOpenState;
        }
        return this;
    }
    public void OnEnter(Gun gun, IBoltState previousState)
    {
        gun.boltStateTimer = gun.boltPullDuration;
    }
    public void OnExit(Gun gun, IBoltState nextState) { }
}
