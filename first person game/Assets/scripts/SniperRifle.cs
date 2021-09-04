using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class SniperRifle : MonoBehaviour
{
    public Animator animator;
    public GameObject ScopeOverlay;
    public bool isScoped;
    public GameObject weaponCamera;
    public GameObject crossHair;
    public Camera mainCamera;

    public float scopedFov = 15f;
    private float normalFov;
    private void Start()
    {
        normalFov = mainCamera.fieldOfView;
    }
    private void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            isScoped = true;
            animator.SetBool("Scoped", true); 
            StartCoroutine(OnScoped());
        }
        else
        {
            isScoped = false;
            animator.SetBool("Scoped", false);            
            OnUnScoped();
        }
    }
    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(0.15f);
        ScopeOverlay.SetActive(true);
        weaponCamera.SetActive(false);
        crossHair.SetActive(false);

        mainCamera.fieldOfView = scopedFov;

    }
    void OnUnScoped()
    {
        ScopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);
        crossHair.SetActive(true);

        mainCamera.fieldOfView = normalFov;
    }
}
