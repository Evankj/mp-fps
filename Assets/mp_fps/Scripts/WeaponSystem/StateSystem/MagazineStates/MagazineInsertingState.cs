using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineInsertingState : IMagazineState
{
    public IMagazineState DoState(Gun gun)
    {
        if (gun.magazineStateTimer <= 0)
        {
            // Animation over, mag is now in
            return gun.magazineInState;
        }
        return this;
    }
    public void OnEnter(Gun gun, IMagazineState previousState)
    {
        gun.PlayIKAnimation(gun.magazineInsertIKAnim);
        gun.magazineStateTimer = gun.magazineInsertDuration;
    }
    public void OnExit(Gun gun, IMagazineState nextState) { }
}
