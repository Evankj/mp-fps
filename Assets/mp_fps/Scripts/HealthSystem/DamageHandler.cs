using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DamageHandler : NetworkBehaviour
{
    Dictionary<Collider, bool> legColliders;
    Dictionary<Collider, bool> armColliders;
    Dictionary<Collider, bool> torsoColliders;
    Dictionary<Collider, bool> headColliders;

    public float headShotDamageCoefficient = 2;
    public float torsoShotDamageCoefficient = 1;
    public float armShotDamageCoefficient = 0.5f;
    public float legShotDamageCoefficient = 0.5f;

    [SyncVar]
    public float health = 100;

    [Command(requiresAuthority = false)]
    public void CMD_DealDamage(float damageAmount)
    {
        health -= damageAmount;
    }
}
