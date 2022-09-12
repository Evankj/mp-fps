using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltLockedOpenState : IBoltState
{

    bool boltJustLocked = false;

    public IBoltState DoState(Gun gun)
    {
        if (gun.input.boltReleaseTapped)
        {
            return gun.boltCyclingForwardState;
        }
        if (!gun.inputHandler.previousInput.reloadHeld && gun.input.reloadHeld)
        {
            return gun.boltPullingState;
        }
        return this;
    }
    public void OnEnter(Gun gun, IBoltState previousState)
    {
        gun.boltStartMarkerTransform = gun.boltBackMarkerTransform;
        gun.boltEndMarkerTransform = gun.boltBackMarkerTransform;
        gun.boltAnimationDuration = 0;
        // boltJustLocked = true;
        // Play sound for locking bolt open!
    }
    public void OnExit(Gun gun, IBoltState nextState)
    {
        // Play sound for flicking bolt release
    }
}
