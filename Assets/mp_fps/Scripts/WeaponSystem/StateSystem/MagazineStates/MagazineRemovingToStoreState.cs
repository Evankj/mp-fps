using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineRemovingToStoreState : IMagazineState
{
    public IMagazineState DoState(Gun gun) {
        if (gun.magazineStateTimer <= 0) {
            // Animation over, move to storing state
            return gun.magazineStoringState;
        }
        return this;
    }
    public void OnEnter(Gun gun, IMagazineState previousState) {
        gun.magazineStateTimer = gun.magazineRemoveToStoreDuration;
    }
    public void OnExit(Gun gun, IMagazineState nextState) {}
}
