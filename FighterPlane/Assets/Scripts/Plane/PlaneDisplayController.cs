﻿using UnityEngine;
using System.Collections;
using System;

public class PlaneDisplayController : MonoBehaviour
{

    public bool IsInfoShown
    {
        get;
        private set;
    }

    public bool IsGasAlertActive
    {
        get;
        private set;
    }

    public int planeNumber;

    // Gas variables
    public float gasAmount = 100;

    private Color selectedColor;
    public Color defaultColor;
    public GameObject planeInfo;
    public GameObject lackOfGasAlert;
    public GameObject planeCamera;
    public GameObject pilotCamera;

    private GameObject wings;
    private GameObject mainbody;

    private PhysicsParameters pParams;

    void Start()
    {
        // Assigning wings and plane body for color purposes
        wings = transform.Find("Wings").gameObject;
        mainbody = transform.Find("Main_Body").gameObject;

        pParams = new PhysicsParameters(transform);
        IsGasAlertActive = false;
        selectedColor = Color.blue;
        ConvertColors(defaultColor);
    }

    void Update()
    {
        // Update Gas Amount
        HandleGasAmount();

        // Calculate inforamtion only if text is shown
        if (IsInfoShown)
        {
            // Calculate physics information
            pParams.UpdatePhysics(transform);

            DisplayUpdatedInfo();
        }
    }

    #region Plane's Gas
    private void HandleGasAmount()
    {
        gasAmount = gasAmount > 0 ? gasAmount - Time.deltaTime : 0;

        // If there is a lack of gas display alert
        if (gasAmount <= GlobalManager.GasThreshold)
        {
            // todo will be changed if found a better way to avoid boolea parameter
            if (!IsGasAlertActive)
            {
                IsGasAlertActive = true;
                lackOfGasAlert.GetComponent<MeshRenderer>().enabled = true;
                lackOfGasAlert.GetComponent<AudioSource>().Play();
            }
        }
    }
    #endregion

    #region Selecting Plane
    public void SelectPlane()
    {
        ConvertColors(selectedColor);
    }

    public void DeselectPlane()
    {
        ConvertColors(defaultColor);
    }

    private void ConvertColors(Color color)
    {
        wings.GetComponent<Renderer>().material.color = color;
        mainbody.GetComponent<Renderer>().material.color = color;
    }
    #endregion

    #region Plane Details
    private void DisplayUpdatedInfo()
    {
        planeInfo.GetComponent<TextMesh>().text = this.name + "\n" + pParams.ToString()
                                                            + "\n" + "Gas Amount(Liters): " + this.gasAmount.ToString("000.0");
    }

    public void HidePlaneInfo()
    {
        planeInfo.SetActive(false);
        IsInfoShown = false;
    }

    public void ShowPlaneInfo()
    {
        planeInfo.SetActive(true);
        IsInfoShown = true;
    }
    #endregion
}
