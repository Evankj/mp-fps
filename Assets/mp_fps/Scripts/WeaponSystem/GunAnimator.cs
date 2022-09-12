using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GunAnimator : NetworkBehaviour
{

    [SyncVar]
    public string boltStateKey;
    IBoltState boltState;

    [SyncVar]
    public string magazineStateKey = "TEST";
    IMagazineState magazineState;

    public Gun currentGun;
    bool initialisedKeys = false;

    AimHandler aimHandler;


    // Start is called before the first frame update
    void Start()
    {
        aimHandler = GetComponent<AimHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!initialisedKeys)
        {
            boltStateKey = currentGun.currentBoltState.GetType().Name;
            magazineStateKey = currentGun.currentMagazineState.GetType().Name;
            Debug.Log(magazineStateKey);
            initialisedKeys = true;
        }
        // Debug.Log(netId + " " + boltState);
        AnimateBolt();
        AnimateMagazine();
        AnimateWeaponTransform();
        if (!isLocalPlayer)
        {
            currentGun.currentBoltState = currentGun.boltStateDict[boltStateKey];
            currentGun.currentMagazineState = currentGun.magazineStateDict[magazineStateKey];
        }
        // AnimateMagazine();
    }

    public void UpdateBoltState(IBoltState newState)
    {
        CMD_SetBoltState(newState.GetType().Name);
        // SetBoltState(newState);
    }
    public void UpdateMagazineState(IMagazineState newState)
    {
        CMD_SetMagazineState(newState.GetType().Name);
        // SetMagazineState(newState);
    }

    void AnimateBolt()
    {
        if (currentGun.boltAnimationDuration != 0)
        {
            Vector3 pos = Vector3.Lerp(currentGun.boltStartMarkerTransform.localPosition, currentGun.boltEndMarkerTransform.localPosition, (currentGun.boltAnimationDuration - currentGun.boltStateTimer) / currentGun.boltAnimationDuration);
            currentGun.boltTransform.localPosition = pos;
        }
        else
        {
            currentGun.boltTransform.localPosition = currentGun.boltEndMarkerTransform.localPosition;
        }
    }

    void AnimateMagazine()
    {
        if (!currentGun.gunIKAnimator.isPlaying)
        {
            if (currentGun.magazineAnimationDuration != 0)
            {
                Vector3 pos = Vector3.Lerp(currentGun.magazineStartMarkerTransform.localPosition, currentGun.magazineEndMarkerTransform.localPosition, (currentGun.magazineAnimationDuration - currentGun.magazineStateTimer) / currentGun.magazineAnimationDuration);
                currentGun.magazineTransform.localPosition = pos;
            }
            else
            {
                currentGun.magazineTransform.localPosition = currentGun.magazineEndMarkerTransform.localPosition;
            }
        }
        else
        {
            Debug.Log("Playing");
        }
    }

    void AnimateWeaponTransform()
    {
        if (aimHandler.isAiming)
        {
            currentGun.weaponStartMarkerTransform = currentGun.transform;
            currentGun.weaponEndMarkerTransform = currentGun.weaponAimTransform;
            currentGun.weaponAnimationTimer = currentGun.weaponADSDuration;
        }
        else
        {
            // if (currentGun.boltStateTimer != 0 || currentGun.magazineStateTimer != 0)
            // {
            currentGun.weaponEndMarkerTransform = currentGun.weaponDefaultTransform;
            currentGun.weaponAnimationTimer = currentGun.weaponReturnToDefaultDuration;
            // }
        }

        if (currentGun.weaponAnimationDuration != 0)
        {

            Vector3 pos = Vector3.Lerp(currentGun.weaponStartMarkerTransform.localPosition, currentGun.weaponEndMarkerTransform.localPosition, (currentGun.weaponAnimationDuration - currentGun.weaponAnimationTimer) / currentGun.weaponAnimationDuration);
            Quaternion rot = Quaternion.Lerp(currentGun.weaponStartMarkerTransform.localRotation, currentGun.weaponEndMarkerTransform.localRotation, (currentGun.weaponAnimationDuration - currentGun.weaponAnimationTimer) / currentGun.weaponAnimationDuration);
            currentGun.weaponTransform.localPosition = pos;
            currentGun.weaponTransform.localRotation = rot;
        }
        else
        {
            currentGun.weaponTransform.localPosition = currentGun.weaponEndMarkerTransform.localPosition;
            currentGun.weaponTransform.localRotation = currentGun.weaponEndMarkerTransform.localRotation;
        }
    }


    [Command]
    public void CMD_SetBoltState(string boltState)
    {
        // IBoltState state = currentGun.boltStateDict[boltState];
        boltStateKey = boltState;
        // boltState = boltStateKey;
        // this.boltState = state;
    }

    void SetMagazineState(IMagazineState magazineState)
    {
        this.magazineState = magazineState;
        CMD_SetMagazineState(magazineState.GetType().Name);
    }

    [Command]
    public void CMD_SetMagazineState(string magazineState)
    {
        // IMagazineState state = currentGun.magazineStateDict[magazineState];
        // this.magazineState = state;
        magazineStateKey = magazineState;
    }
}
