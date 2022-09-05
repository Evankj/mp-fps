using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltCheckingState : IBoltState
{
    public IBoltState DoState(Gun gun) {
        if (gun.input.reloadUp) {
            // We want to release the slide
            return gun.boltCyclingForwardState;
        }
        return this;
    }
    public void OnEnter(Gun gun, IBoltState previousState) {}
    public void OnExit(Gun gun, IBoltState nextState) {}
}
