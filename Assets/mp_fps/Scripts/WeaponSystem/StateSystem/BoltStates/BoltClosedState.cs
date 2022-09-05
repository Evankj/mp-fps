using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltClosedState : IBoltState
{
    public IBoltState DoState(Gun gun) {
        if (gun.input.reloadHeld) {
            // We want to pull the slide
            return gun.boltMovingToPullState;
        }

        return this;
    }
    public void OnEnter(Gun gun, IBoltState previousState) {
        // Chamber a round if we can!
        // Play bolt closing sound!
    }
    public void OnExit(Gun gun, IBoltState nextState) {}
}
