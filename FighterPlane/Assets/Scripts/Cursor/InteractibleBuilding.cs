﻿using System.Linq;
using UnityEngine;

public class InteractibleBuilding : MonoBehaviour {

    private Renderer buildingRenderer;
    private bool previousSelection = false;
    public GameObject TextHolder;
    private bool InfoVisibility = false;

    public bool IsSelected = false;
    public BuildingManager buildingManager;

    private void Start()
    {
        buildingRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (IsSelected != previousSelection)
        {
            UpdateSelection();
        }
        previousSelection = IsSelected;
    }

    private void UpdateSelection()
    {
        buildingManager.SelectBuilding(gameObject);
    }

    private void SetColor(Color color)
    {
        foreach (var material in buildingRenderer.materials)
        {
            material.color = color;
        }
    }

    public void Select()
    {
        IsSelected = true;
        previousSelection = true;
        SetColor(Color.red);
    }

    public void Unselect()
    {
        IsSelected = false;
        previousSelection = false;
        SetColor(Color.white);
    }

    void OnSelect()
    {
        IsSelected = !IsSelected;
    }

    void SetText()
    {
        var buildingInfo = GetComponent<OnlineMapsBuildingBase>().metaInfo;
        if (buildingInfo.Any(p => p.title == "name:en"))
            TextHolder.GetComponent<TextMesh>().text = buildingInfo.Single(p => p.title == "name:en").info;
        else TextHolder.GetComponent<TextMesh>().text = "General Building";
    }

    public void ShowInfo()
    {
        if (TextHolder.GetComponent<TextMesh>().text == string.Empty)
        {
            SetText();
        }
        TextHolder.SetActive(true);
    }

    public void HideInfo()
    {
        TextHolder.SetActive(false);
    }
}