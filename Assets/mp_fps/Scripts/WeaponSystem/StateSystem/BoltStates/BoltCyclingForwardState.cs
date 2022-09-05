using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltCyclingForwardState : IBoltState
{
    public IBoltState DoState(Gun gun) {
        if (gun.boltStateTimer <= 0) {
            // Gun has cycled, load a round if we can 
            if (gun.currentMagazine != null) {
                Bullet bullet = gun.currentMagazine.bullets[0];
                if (bullet) {
                    gun.ChamberBullet(bullet);
                    gun.currentMagazine.bullets.RemoveAt(0);
                }
            }
            return gun.boltClosedState;
        }
        return this;
    }
    public void OnEnter(Gun gun, IBoltState previousState) {
        gun.boltStateTimer = gun.boltCycleForwardDuration;
    }
    public void OnExit(Gun gun, IBoltState nextState) {}
}
