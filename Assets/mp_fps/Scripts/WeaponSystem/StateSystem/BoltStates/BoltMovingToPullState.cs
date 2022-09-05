using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltMovingToPullState : IBoltState
{
    public IBoltState DoState(Gun gun) {
        if (gun.boltStateTimer <= 0) {
            // Animation finished
            if (gun.input.modifierHeld) {
                // We want to do a chamber check
                return gun.boltCheckingState;
            } else {
                // We want to pull the slide all the way back
                return gun.boltPullingState;
            }
        }
        return this;
    }
    public void OnEnter(Gun gun, IBoltState previousState) {
        // SET TIMER TO LENGTH OF IK ANIMATION?
    }
    public void OnExit(Gun gun, IBoltState nextState) {}
}
