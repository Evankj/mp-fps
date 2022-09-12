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


    public float muzzleVelocity = 400;
    public float gravityCoefficient = 1;

    public static float GRAVITY = -9.8f;

    Vector3 previousPosition;

    Vector3 velocity = Vector3.zero;

    Rigidbody rb;

    public LayerMask hitMask;

    Vector3 dir;

    public float suppressionAmount = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        previousPosition = transform.position;
    }

    void Setup()
    {
        rb.useGravity = false;
    }

    void UpdatePosition()
    {
        velocity = new Vector3(0, GRAVITY * gravityCoefficient, muzzleVelocity * velocityFalloffCurve.Evaluate(timeSinceInstantiation));
        Vector3 forward = transform.forward;
        var localVel = transform.InverseTransformDirection(rb.velocity);
        localVel = velocity;
        rb.velocity = transform.TransformDirection(localVel);
    }

    void CheckCollisions()
    {
        Vector3 dir = transform.position - previousPosition;
        float dist = Vector3.Distance(previousPosition, transform.position);
        RaycastHit[] hits = Physics.RaycastAll(previousPosition, dir, dist, hitMask);
        if (hits.Length > 0)
        {
            DamageHandler damageHandler = GetDamageHandler(hits[0].transform.gameObject);
            if (damageHandler)
            {
                float damage = maxHitDamage * damageFalloffCurve.Evaluate(timeSinceInstantiation);
                switch (hits[0].collider.tag)
                {
                    case "ARM":
                        damage *= damageHandler.armShotDamageCoefficient;
                        break;
                    case "LEG":
                        damage *= damageHandler.legShotDamageCoefficient;
                        break;
                    case "TORSO":
                        damage *= damageHandler.torsoShotDamageCoefficient;
                        break;
                    case "HEAD":
                        damage *= damageHandler.headShotDamageCoefficient;
                        break;
                    default:
                        break;
                }
                damageHandler.CMD_DealDamage(damage);
            }


            NetworkServer.Destroy(this.gameObject);
        }
    }

    DamageHandler GetDamageHandler(GameObject hitObject)
    {
        DamageHandler damageHandler = hitObject.GetComponent<DamageHandler>();
        Transform parentObject = null;
        while (parentObject != null)
        {
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

    void OnGUI()
    {
    }
}
