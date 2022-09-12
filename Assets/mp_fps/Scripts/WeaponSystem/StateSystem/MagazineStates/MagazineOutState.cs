using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineOutState : IMagazineState
{
    public IMagazineState DoState(Gun gun)
    {
        if (gun.input.reloadTapped)
        {
            // CHECK IF WE HAVE A MAGAZINE BEFORE LOADING IN THE FUTURE
            return gun.magazineRetrievingState;
        }
        return this;
    }
    public void OnEnter(Gun gun, IMagazineState previousState)
    {
        // gun.currentMagazine = null;
        gun.currentBullets = 0;
    }
    public void OnExit(Gun gun, IMagazineState nextState) { }
}
