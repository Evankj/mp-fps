using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltClosedState : IBoltState
{
    public IBoltState DoState(Gun gun)
    {
        if (gun.input.reloadHeld)
        {
            // We want to pull the slide
            return gun.boltMovingToPullState;
        }
        if (gun.firing)
        {
            return gun.boltCyclingBackState;
        }

        return this;
    }
    public void OnEnter(Gun gun, IBoltState previousState)
    {
        // Chamber a round if we can!
        // Play bolt closing sound!

        gun.boltStartMarkerTransform = gun.boltForwardMarkerTransform;
        gun.boltEndMarkerTransform = gun.boltForwardMarkerTransform;
        gun.boltAnimationDuration = 0;

        gun.ChamberRound();
    }
    public void OnExit(Gun gun, IBoltState nextState) { }
}
