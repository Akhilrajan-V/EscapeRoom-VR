using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    [SerializeField] private GameObject spawn_particles;
    [SerializeField] private GameObject hubKey;

    void Start()
    {
        spawn_particles.SetActive(false);
        hubKey.SetActive(false);
    }
    public void Spawn_crossbow()
    {
        spawn_particles.SetActive(true);
        hubKey.SetActive(true);
    }

}
