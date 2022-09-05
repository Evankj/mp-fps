using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltHeldOpenState : IBoltState
{
    public IBoltState DoState(Gun gun) {
        if (gun.input.reloadUp) {
            // We're releasing the bolt!
            return gun.boltCyclingForwardState;
        }
        if (gun.input.boltReleaseTapped) {
            return gun.boltLockedOpenState;
        }
        return this;
    }
    public void OnEnter(Gun gun, IBoltState previousState) {
        // Eject a round!
    }
    public void OnExit(Gun gun, IBoltState nextState) {}
}
