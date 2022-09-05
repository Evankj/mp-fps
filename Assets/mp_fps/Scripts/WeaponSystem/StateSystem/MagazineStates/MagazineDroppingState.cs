using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineDroppingState : IMagazineState
{
    public IMagazineState DoState(Gun gun) {
        if (gun.magazineStateTimer <= 0) {
            // animation finished, go to mag out state
            return gun.magazineOutState;
        }
        return this;
    }
    public void OnEnter(Gun gun, IMagazineState previousState) {
        gun.magazineStateTimer = gun.magazineDroppingDuration;
    }
    public void OnExit(Gun gun, IMagazineState nextState) {
        // We dropped the mag, tell the gun to spawn a mag object 
    }
}
