using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Gun : NetworkBehaviour
{

    public Transform muzzle;
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0)) {
            CMD_Fire(muzzle.position, muzzle.rotation);
        }
    }


    [Command]
    public void CMD_Fire(Vector3 muzzlePosition, Quaternion rotation) {
        GameObject bullet = Instantiate(bulletPrefab, muzzlePosition, rotation);
        NetworkServer.Spawn(bullet);
    }
}
