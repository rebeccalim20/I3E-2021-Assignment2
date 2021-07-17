using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Epickuptype
{

    ept_health,
    ept_ammo,
    ept_key,
    ept_coin,
    ept_gun,
    ept_teleport
     
    
}
public class interactable : MonoBehaviour
{
    public Epickuptype pickuptype = Epickuptype.ept_health;

    public float amount = 40;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
