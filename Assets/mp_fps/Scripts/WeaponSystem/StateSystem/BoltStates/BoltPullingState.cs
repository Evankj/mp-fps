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
        if (gun.input.reloadUp)
        {
            return gun.boltCyclingForwardState;
        }
        return this;
    }
    public void OnEnter(Gun gun, IBoltState previousState)
    {
        gun.boltStateTimer = gun.boltPullDuration;

        gun.boltStartMarkerTransform = gun.boltForwardMarkerTransform;
        gun.boltEndMarkerTransform = gun.boltBackMarkerTransform;
        gun.boltAnimationDuration = gun.boltPullDuration;
    }
    public void OnExit(Gun gun, IBoltState nextState) { }
}
