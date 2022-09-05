using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineCheckingState : IMagazineState
{
    public IMagazineState DoState(Gun gun) {
        if (!gun.input.modifierHeld) {
            // Re insert the mag
            return gun.magazineInsertingState;
        } 
        if (gun.input.reloadDoubleTapped) {
            // Drop the mag and move to mag out state
            return gun.magazineOutState;
        }
        if (gun.input.reloadTapped) {
            // Move to magazine storing state
            return gun.magazineStoringState;
        }
        return this;
    }
    public void OnEnter(Gun gun, IMagazineState previousState) {}
    public void OnExit(Gun gun, IMagazineState nextState) {}
}
