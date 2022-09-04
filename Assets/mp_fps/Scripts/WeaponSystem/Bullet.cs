using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Bullet : NetworkBehaviour
{

    public float maxHitDamage;
    public AnimationCurve damageFalloffCurve;
    public AnimationCurve velocityFalloffCurve;
    float timeSinceInstantiation;

    public float muzzleVelocity;
    public float gravityCoefficient = 1;

    public static float GRAVITY = -9.8f;

    Vector3 previousPosition;

    Vector3 velocity = Vector3.zero;

    Rigidbody rb;

    public LayerMask hitMask;

    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        previousPosition = transform.position;
    }

    void Setup() {
        rb.useGravity = false;
    }

    void UpdatePosition() {
        velocity = new Vector3(0, GRAVITY * gravityCoefficient, muzzleVelocity * velocityFalloffCurve.Evaluate(timeSinceInstantiation));
        Vector3 forward = transform.forward;
        var localVel = transform.InverseTransformDirection(rb.velocity);
        localVel = velocity;
        rb.velocity = transform.TransformDirection(localVel);
    }

    void CheckCollisions() {
        Vector3 dir = transform.position - previousPosition;
        float dist = Vector3.Distance(previousPosition, transform.position);
        RaycastHit[] hits = Physics.RaycastAll(previousPosition, dir, dist, hitMask);
        if (hits.Length > 0) {
            DamageHandler damageHandler = GetDamageHandler(hits[0].transform.gameObject);
            damageHandler.CMD_DealDamage(
                maxHitDamage * damageFalloffCurve.Evaluate(timeSinceInstantiation)
            );
        }
    }

    DamageHandler GetDamageHandler(GameObject hitObject) {
        DamageHandler damageHandler = null;
        Transform parentObject = null;
        while(parentObject != null) {
            parentObject = transform.parent;
            damageHandler = parentObject.GetComponent<DamageHandler>();
        }
        return damageHandler;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();

        if (isServer)
            CheckCollisions();

        previousPosition = transform.position;
        timeSinceInstantiation += Time.deltaTime;
    }
}
