using Assets.Scripts.Game.Weapon;
using Assets.Scripts.Logs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    [SerializeField] private float WeaponDamage;

    [Tooltip("time in second for bullet spawn")]
    [SerializeField] private float fireRate;

    [SerializeField] private Transform WeaponMuzzlePoint;

    [SerializeField] private GameObject BullerPrefab;

    private bool preventShooting;

    private RaycastHit raycastHit;

    private void Start()
    {
        preventShooting = false;
    }


    public void Fire() {


        if (preventShooting)
        {
            return;
        }

        var bullet = Instantiate(BullerPrefab);

        bullet.GetComponent<Bullet>().Damage = WeaponDamage;

        bullet.transform.position = WeaponMuzzlePoint.position;

        preventShooting = true;

        StartCoroutine(StopCooldownAfterTime());

       /* 

        Ray ray = new Ray();
*/
        /*ray.origin = bulletPoint.position;
        ray.direction =bulletPoint.TransformDirection(Vector3.forward);

        Debug.DrawRay(ray.origin, ray.direction * fireDistance, Color.green);

        if (Physics.Raycast(ray, out raycastHit, fireDistance))
        {
            if (raycastHit.collider.CompareTag(enemyTag))
            {
                //var healthCtrl = raycastHit.collider.GetComponent<HealthController>();
                //healthCtrl.ApplyDamage(damage);
                LoggerFile.Instance.DEBUG_LINE("ApplyDamage..");

            }
        }*/

        /*        fireCouldDown = true;
                StartCoroutine(StopCooldownAfterTime());*/

    }
    private IEnumerator StopCooldownAfterTime()
    {
        yield return new WaitForSeconds(fireRate);
        preventShooting = false;
    }

    public bool UseTap()
    {
        return fireRate == 0;
    }

}
