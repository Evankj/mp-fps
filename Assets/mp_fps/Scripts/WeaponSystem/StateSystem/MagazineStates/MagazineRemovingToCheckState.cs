using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineRemovingToCheckState : IMagazineState
{
    public IMagazineState DoState(Gun gun) {
        if (gun.magazineStateTimer <= 0) {
            // Animation over, move to checking state
            return gun.magazineCheckingState;
        }
        return this;
    }
    public void OnEnter(Gun gun, IMagazineState previousState) {
        gun.magazineStateTimer = gun.magazineRemoveToCheckDuration;
    }
    public void OnExit(Gun gun, IMagazineState nextState) {
        // Tell UI to show us how many bullets?
    }
}
