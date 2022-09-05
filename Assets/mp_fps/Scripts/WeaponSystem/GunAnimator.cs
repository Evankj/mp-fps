using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GunAnimator : NetworkBehaviour
{

    [SyncVar]
    string boltStateKey;
    IBoltState boltState;

    [SyncVar]
    string magazineStateKey;
    IMagazineState magazineState;

    public Gun currentGun;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AnimateBolt();
        AnimateMagazine();
    }

    public void UpdateBoltState(IBoltState newState)
    {
        SetBoltState(newState);
    }
    public void UpdateMagazineState(IMagazineState newState)
    {
        SetMagazineState(newState);
    }

    void AnimateBolt()
    {
        currentGun.boltTransform.position = Vector3.Lerp(currentGun.boltStartMarkerTransform.position, currentGun.boltEndMarkerTransform.position, currentGun.boltAnimationDuration / Time.deltaTime);
    }

    void AnimateMagazine()
    {
        currentGun.magazineTransform.position = Vector3.Lerp(currentGun.magazineStartMarkerTransform.position, currentGun.magazineEndMarkerTransform.position, currentGun.magazineAnimationDuration / Time.deltaTime);
    }

    void SetBoltState(IBoltState boltState)
    {
        this.boltState = boltState;
        CMD_SetBoltState(boltState.GetType().Name);
    }

    [Command]
    public void CMD_SetBoltState(string boltState)
    {
        this.boltState = currentGun.boltStateDict[boltState];
    }

    void SetMagazineState(IMagazineState magazineState)
    {
        this.magazineState = magazineState;
        CMD_SetMagazineState(magazineState.GetType().Name);
    }

    [Command]
    public void CMD_SetMagazineState(string magazineState)
    {
        this.magazineState = currentGun.magazineStateDict[magazineState];
    }
}
