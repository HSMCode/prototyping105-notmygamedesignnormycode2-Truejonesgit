using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehavior : MonoBehaviour
{
    public GameObject pickupEffect;

    void Update()
    {
        if (!gameObject.activeInHierarchy)
        {
            pickupEffect.SetActive(true);
        }
    }
}
