using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineRetrievingState : IMagazineState
{
    public IMagazineState DoState(Gun gun) {
        if (gun.magazineStateTimer <= 0) {
            // Animation finished, move to inserting state
            return gun.magazineInsertingState;
        }
        return this;
    }
    public void OnEnter(Gun gun, IMagazineState previousState) {
        gun.magazineStateTimer = gun.magazineRetrieveDuration;
    }
    public void OnExit(Gun gun, IMagazineState nextState) {}
}
