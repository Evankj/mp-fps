using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineStoringState : IMagazineState
{
    public IMagazineState DoState(Gun gun) {
        if (gun.magazineStateTimer <= 0) {
            // Animation over, go to mag out state
            return gun.magazineOutState;
        }
        return this;
    }
    public void OnEnter(Gun gun, IMagazineState previousState) {
        gun.magazineStateTimer = gun.magazineStoringDuration;
    }
    public void OnExit(Gun gun, IMagazineState nextState) {
        // We've finished storing the mag, tell inventory we need to store a mag
    }
}
