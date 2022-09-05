using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GunNetworkingInterface : NetworkBehaviour
{

    public Gun currentGun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [Command]
    public void CMD_Fire(Vector3 muzzlePosition, Quaternion rotation)
    {
        GameObject bullet = Instantiate(currentGun.bulletPrefab, muzzlePosition, rotation);
        NetworkServer.Spawn(bullet);
    }
}
