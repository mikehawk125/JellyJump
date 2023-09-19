using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerVignetteController : MonoBehaviour
{
    Volume volume;
    GameObject player;
    public float maxDistance = 40f; // Maximum distance to the enemy for the effect to start.
    public float minIntensity = 0f; // Vignette minimum intensity.
    public float maxIntensity = 0.4f; // Vignette maximum intensity.

    private Vignette vignette;
    private Vector3 lastPosition; // Pozicija igrača u prethodnom okviru.

    void Start()
    {
        volume = FindAnyObjectByType<Volume>();
        player = GameObject.FindGameObjectWithTag("Player");
        if (volume.profile.TryGet<Vignette>(out var v))
        {
            vignette = v;
        }

        // Postavljanje početne pozicije igrača.
        lastPosition = player.transform.position;
    }

    void Update()
    {
        // Izračunaj razliku između trenutne i prethodne pozicije igrača.
        Vector3 playerVelocity = (player.transform.position - lastPosition) / Time.deltaTime;

        // Izračunaj brzinu igrača.
        float playerSpeed = playerVelocity.magnitude;

        // Mapiraj brzinu igrača na jačinu Vignette efekta.
        float intensity = Mathf.Lerp(minIntensity, maxIntensity, playerSpeed / maxDistance);

        // Postavi jačinu Vignette efekta.
        vignette.intensity.Override(intensity);

        // Spremi trenutnu poziciju igrača za sljedeći okvir.
        lastPosition = player.transform.position;
    }
}
