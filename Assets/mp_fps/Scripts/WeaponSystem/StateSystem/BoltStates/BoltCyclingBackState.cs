using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltCyclingBackState : IBoltState
{
    public IBoltState DoState(Gun gun)
    {
        if (gun.boltStateTimer <= 0)
        {
            // Maybe check if we want to jam here?

            // Check if gun.currentMagazine has ammo and there's a magazine loaded, if so cycle forward, if not lock open
            if (gun.currentMagazine.bullets.Count > 0 && gun.currentMagazine != null)
            {
                // We have ammo, cycle forward
                return gun.boltCyclingForwardState;
            }
            else
            {
                // We have no more ammo or no magazine, lock open
                return gun.boltLockedOpenState;
            }
        }

        return this;
    }
    public void OnEnter(Gun gun, IBoltState previousState)
    {
        gun.boltStateTimer = gun.boltCycleBackDuration;
        gun.boltStartMarkerTransform = gun.boltForwardMarkerTransform;
        gun.boltEndMarkerTransform = gun.boltBackMarkerTransform;
        gun.boltAnimationDuration = gun.boltCycleBackDuration;
    }
    public void OnExit(Gun gun, IBoltState nextState)
    {
    }
}
