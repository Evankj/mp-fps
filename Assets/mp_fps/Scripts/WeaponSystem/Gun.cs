using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Mirror;

public class Gun : MonoBehaviour
{

    public GunNetworkingInterface gunNetworkingInterface;
    public IBoltState currentBoltState;
    public IBoltState previousBoltState;
    public IMagazineState currentMagazineState;
    public IMagazineState previousMagazineState;

    public Magazine currentMagazine;
    public Bullet currentBullet;
    //public AnimationClip ;

    public Transform boltTransform;
    public Transform boltBackMarkerTransform;
    public Transform boltForwardMarkerTransform;
    public Transform boltCheckMarkerTransform;
    public Transform boltJammedMarkerTransform;

    public Transform boltStartMarkerTransform;
    public Transform boltEndMarkerTransform;
    public float boltAnimationDuration;


    public Transform magazineTransform;
    public Transform magazineStartMarkerTransform;
    public Transform magazineEndMarkerTransform;
    public float magazineAnimationDuration;

    // -----------------------------------------------------------------
    // BOLT STATES
    public BoltPullingState boltPullingState;
    public BoltCheckingState boltCheckingState;
    public BoltClosedState boltClosedState;
    public BoltHeldOpenState boltHeldOpenState;
    public BoltLockedOpenState boltLockedOpenState;
    public BoltJammedState boltJammedState;
    public BoltMovingToPullState boltMovingToPullState;
    public BoltMovingToReleaseState boltMovingToReleaseState;
    public BoltCyclingBackState boltCyclingBackState;
    public BoltCyclingForwardState boltCyclingForwardState;


    // -----------------------------------------------------------------
    // MAGAZINE STATES
    public MagazineInState magazineInState;
    public MagazineOutState magazineOutState;
    public MagazineInsertingState magazineInsertingState;
    public MagazineRetrievingState magazineRetrievingState;
    public MagazineDroppingState magazineDroppingState;
    public MagazineStoringState magazineStoringState;
    public MagazineRemovingToCheckState magazineRemovingToCheckState;
    public MagazineRemovingToStoreState magazineRemovingToStoreState;
    public MagazineCheckingState magazineCheckingState;


    public Dictionary<string, IBoltState> boltStateDict = new Dictionary<string, IBoltState>();
    public Dictionary<string, IMagazineState> magazineStateDict = new Dictionary<string, IMagazineState>();


    public float boltStateTimer;
    public float boltCycleBackDuration = 1;
    public float boltMoveToCheckPosDuration = 1;
    public float boltCycleForwardDuration = 1;
    public float boltPullDuration = 1;

    public float magazineStateTimer = 1;
    public float magazineInsertDuration = 1;
    public float magazineRetrieveDuration = 1;
    public float magazineDroppingDuration = 1;
    public float magazineStoringDuration = 1;
    public float magazineRemoveToCheckDuration = 1;
    public float magazineRemoveToStoreDuration = 1;


    public GunAnimator gunAnimator;

    public AnimationClip magazineRemoveToStoreIKAnim;
    public AnimationClip magazineRemoveToDropIKAnim;
    public AnimationClip magazineRemoveToCheckIKAnim;
    public AnimationClip magazineInsertIKAnim;


    public float leftHandIKFadeInDuration;
    public float leftHandIKFadeInTimer;
    public float rightHandIKFadeInDuration;
    public float rightHandIKFadeInTimer;

    public Transform defaultLeftHandIKTarget;
    public Transform defaultRightHandIKTarget;

    public Transform muzzle;
    public GameObject bulletPrefab;

    public InputHandler inputHandler;
    public InputClass input;

    public Animation gunIKAnimator;

    void Start()
    {
        SetupFSM();
    }

    void SetupFSM()
    {

        boltPullingState = new BoltPullingState();
        boltCheckingState = new BoltCheckingState();
        boltClosedState = new BoltClosedState();
        boltHeldOpenState = new BoltHeldOpenState();
        boltLockedOpenState = new BoltLockedOpenState();
        boltJammedState = new BoltJammedState();
        boltMovingToPullState = new BoltMovingToPullState();
        boltMovingToReleaseState = new BoltMovingToReleaseState();
        boltCyclingBackState = new BoltCyclingBackState();
        boltCyclingForwardState = new BoltCyclingForwardState();



        boltStateDict.Add(boltPullingState.GetType().Name, boltPullingState);
        boltStateDict.Add(boltCheckingState.GetType().Name, boltCheckingState);
        boltStateDict.Add(boltHeldOpenState.GetType().Name, boltHeldOpenState);
        boltStateDict.Add(boltClosedState.GetType().Name, boltClosedState);
        boltStateDict.Add(boltLockedOpenState.GetType().Name, boltLockedOpenState);
        boltStateDict.Add(boltJammedState.GetType().Name, boltJammedState);
        boltStateDict.Add(boltMovingToPullState.GetType().Name, boltMovingToPullState);
        boltStateDict.Add(boltMovingToReleaseState.GetType().Name, boltMovingToReleaseState);
        boltStateDict.Add(boltCyclingBackState.GetType().Name, boltCyclingBackState);
        boltStateDict.Add(boltCyclingForwardState.GetType().Name, boltCyclingForwardState);


        magazineInState = new MagazineInState();
        magazineOutState = new MagazineOutState();
        magazineInsertingState = new MagazineInsertingState();
        magazineRetrievingState = new MagazineRetrievingState();
        magazineDroppingState = new MagazineDroppingState();
        magazineStoringState = new MagazineStoringState();
        magazineRemovingToCheckState = new MagazineRemovingToCheckState();
        magazineRemovingToStoreState = new MagazineRemovingToStoreState();
        magazineCheckingState = new MagazineCheckingState();

        magazineStateDict.Add(magazineInState.GetType().Name, magazineInState);
        magazineStateDict.Add(magazineOutState.GetType().Name, magazineOutState);
        magazineStateDict.Add(magazineInsertingState.GetType().Name, magazineInsertingState);
        magazineStateDict.Add(magazineRetrievingState.GetType().Name, magazineRetrievingState);
        magazineStateDict.Add(magazineDroppingState.GetType().Name, magazineDroppingState);
        magazineStateDict.Add(magazineStoringState.GetType().Name, magazineStoringState);
        magazineStateDict.Add(magazineRemovingToCheckState.GetType().Name, magazineRemovingToCheckState);
        magazineStateDict.Add(magazineRemovingToStoreState.GetType().Name, magazineRemovingToStoreState);
        magazineStateDict.Add(magazineCheckingState.GetType().Name, magazineCheckingState);

        currentBoltState = boltClosedState;
        previousBoltState = boltClosedState;
        currentMagazineState = magazineInState;
        previousMagazineState = magazineInState;
    }

    // Update is called once per frame
    void Update()
    {
        // Owner of this gun component needs to update state, observers (replicated) only need to know what state is
        if (gunNetworkingInterface.hasAuthority)
        {
            input = inputHandler.input;
            HandleStates();
        }
        HandleStateChanged();

        if (Input.GetMouseButtonUp(0))
        {
            gunNetworkingInterface.CMD_Fire(muzzle.position, muzzle.rotation);
        }
    }


    void HandleIK()
    {
        leftHandIKFadeInTimer -= Time.deltaTime;
        rightHandIKFadeInTimer -= Time.deltaTime;

    }

    void HandleStates()
    {
        currentBoltState = currentBoltState.DoState(this);
    }

    void HandleStateChanged()
    {
        if (previousBoltState.GetType() != currentBoltState.GetType())
        {
            // Debug.Log(gunAnimator.netId + "Bolt state changed!");
            BoltStateChanged(currentBoltState, previousBoltState);
            // boltStateTimer = boltAnimationDuration;
        }
        previousBoltState = currentBoltState;

        currentMagazineState = currentMagazineState.DoState(this);
        if (previousMagazineState.GetType() != currentMagazineState.GetType())
        {
            MagazineStateChanged(currentMagazineState, previousMagazineState);
            // gunAnimator.CMD_SetMagazineState(currentMagazineState.GetType().Name);
        }
        previousMagazineState = currentMagazineState;

        boltStateTimer -= Time.deltaTime;
        if (boltStateTimer <= 0)
        {
            boltStateTimer = 0;
        }

        magazineStateTimer -= Time.deltaTime;
        if (magazineStateTimer <= 0)
        {
            magazineStateTimer = 0;
        }
    }

    void BoltStateChanged(IBoltState newState, IBoltState previousState)
    {
        // Debug.Log(gunAnimator.netId + " Changed from " + previousState + " to " + newState);
        previousBoltState.OnExit(this, newState);
        currentBoltState.OnEnter(this, previousState);
        // gunAnimator.UpdateBoltState(newState);
        if (gunAnimator.hasAuthority)
            gunAnimator.CMD_SetBoltState(newState.GetType().Name);
    }

    void MagazineStateChanged(IMagazineState newState, IMagazineState previousState)
    {
        previousMagazineState.OnExit(this, newState);
        currentMagazineState.OnEnter(this, previousState);
        if (gunAnimator.hasAuthority)
            gunAnimator.CMD_SetMagazineState(newState.GetType().Name);
    }

    public void ChamberBullet(Bullet bullet)
    {
        currentBullet = bullet;
    }



}
