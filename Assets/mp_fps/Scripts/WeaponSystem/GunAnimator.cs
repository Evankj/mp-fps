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


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(netId + " " + boltState);
        AnimateBolt();
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
        currentGun.magazineTransform.position = Vector3.Lerp(currentGun.magazineStartMarkerTransform.position, currentGun.magazineEndMarkerTransform.position, currentGun.magazineAnimationDuration / Time.deltaTime);
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
