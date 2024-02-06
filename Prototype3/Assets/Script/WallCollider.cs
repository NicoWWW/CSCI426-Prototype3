using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WallCollider : MonoBehaviour
{
    [SerializeField] GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision");
        player.GetComponent<playerK>().BounceBack();

    }





}
