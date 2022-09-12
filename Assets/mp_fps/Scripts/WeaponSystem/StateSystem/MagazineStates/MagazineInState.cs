using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineInState : IMagazineState
{
    public IMagazineState DoState(Gun gun)
    {
        if (gun.input.reloadTapped)
        {
            if (gun.input.modifierHeld)
            {
                // eject mag for checking
                return gun.magazineRemovingToCheckState;
            }
            else
            {
                // eject mag for retaining
                return gun.magazineRemovingToStoreState;
            }
        }
        if (gun.input.reloadDoubleTapped)
        {
            return gun.magazineDroppingState;
        }

        return this;
    }

    public void OnEnter(Gun gun, IMagazineState previousState)
    {

        // Play sound of mag inserting
        // gun.currentMagazine = new Magazine();
        // for (int i = 0; i < 17; i++)
        // {
        //     gun.currentMagazine.bullets.Add(new Bullet());
        // }

        gun.currentBullets = 17;
    }
    public void OnExit(Gun gun, IMagazineState nextState)
    {
        // Play sound of mag removing
    }
}
