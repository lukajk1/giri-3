using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX : MonoBehaviour
{
    [SerializeField] ParticleSystem flashCloud;
    [SerializeField] ParticleSystem flashSparks;

    [SerializeField] ParticleSystem dashSparks;
    public void Flash(Vector3 pos) {
        //flashCloud.transform.position = pos;
        flashSparks.transform.position = pos;

        //flashCloud.Play();
        flashSparks.Play();
    }
    public void Dash(Vector3 pos) {
        dashSparks.transform.position = pos;

        dashSparks.Play();
    }
}
