using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private Weapon weaponHolder; 
    private Weapon weapon; 

    void Awake()
    {
        if (weaponHolder != null)
        {
            weapon = Instantiate(weaponHolder);
        }
    }

    void Start()
    {
        if (weapon != null)
        {
            TurnVisual(false); 
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Weapon currentWeapon = other.GetComponentInChildren<Weapon>();
            if (currentWeapon != null)
            {
                currentWeapon.transform.SetParent(currentWeapon.parentTransform);
                currentWeapon.transform.localPosition = Vector3.zero;
                TurnVisual(false, currentWeapon);
            }

            weapon.transform.SetParent(other.transform);
            weapon.transform.localPosition = new Vector3(0, -0.05f, 2); 
            TurnVisual(true);
        }
    }

    void TurnVisual(bool on)
    {
        if (weapon != null)
        {
            weapon.gameObject.SetActive(on);
        }
    }

    void TurnVisual(bool on, Weapon weapon)
    {
        weapon.gameObject.SetActive(on);
    }
}
