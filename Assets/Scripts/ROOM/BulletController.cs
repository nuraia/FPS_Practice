using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.InputSystem;
public class BulletController : MonoBehaviour
{
    public float range = 50f;
    public float damage = 10f;
    public float force = 150f;
    public float fireRate = 15f;
    public float nextTimeToFire = 0f;
    private int currAmmo;
    public int maxAmmo = 10;
    public int magazineSize = 30;
    public float reloadTime = 2f;
    public bool isReloading;
    public Camera fpsCam;
    public ParticleSystem gunParticleSystem;
    public GameObject impactEffect;
    public TextMeshProUGUI ammotext;
    private Vector3 position;
    private void Awake()
    {
        
        currAmmo = maxAmmo;
        position = transform.position;
        AmmoIncreasePickable.OnAmmoIncreaseCollected += ReloadMagazineSize;
       
    }
    void OnDisable()
    {
        AmmoIncreasePickable.OnAmmoIncreaseCollected -= ReloadMagazineSize;
    }
    void Update()
    {
        if(currAmmo == 0 && magazineSize == 0)
        {
            return;
        }
        if (isReloading) return;
        
        if (currAmmo == 0 && magazineSize >0 && !isReloading)
        {
            StartCoroutine(Reload());
        }
        ammotext.text = currAmmo + " / " + magazineSize;
    }
    public void GunShooting(bool isShoot)
    {
        if (isShoot && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        AudioManager.Instance.PlayShotSound();
        currAmmo--;
       
        Debug.Log(ammotext.text);
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            gunParticleSystem.Play();
           // Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }
            if(hit.rigidbody != null) hit.rigidbody.AddForce(-hit.normal * force);

            var instantiatedGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(instantiatedGO, 2f);
        }
    }
    IEnumerator Reload()
    {
        AudioManager.Instance.PlayReloadSound();
        isReloading = true;
        gameObject.transform.DOLocalRotate(new Vector3(90, -6, 0), 0.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(reloadTime);
        //transform.position = position;
        gameObject.transform.DOLocalRotate(new Vector3(0, -6, 0), 0.5f).SetEase(Ease.Linear);
        if (magazineSize >= maxAmmo)
        {
            currAmmo = maxAmmo;
            magazineSize -= maxAmmo;
        }
        else
        {
            currAmmo = magazineSize;
            magazineSize = 0;

        }
        isReloading = false;
    }

    public void ReloadMagazineSize()
    {
        currAmmo = maxAmmo;
        magazineSize = 30;
    }
}
