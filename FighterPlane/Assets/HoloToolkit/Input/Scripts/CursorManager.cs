﻿using HoloToolkit;
using HoloToolkit.Unity;
using UnityEngine;

/// <summary>
/// CursorManager class takes Cursor GameObjects.
/// One that is on Holograms and another off Holograms.
/// Shows the appropriate Cursor when a Hologram is hit.
/// Places the appropriate Cursor at the hit position.
/// Matches the Cursor normal to the hit surface.
/// </summary>
public class CursorManager : Singleton<CursorManager>
{
    [Tooltip("Drag the Cursor object to show when it hits a hologram.")]
    public GameObject CursorOnHolograms;

    [Tooltip("Drag the Cursor object to show when it does not hit a hologram.")]
    public GameObject CursorOffHolograms;

    void Awake()
    {
        if (CursorOnHolograms == null || CursorOffHolograms == null)
        {
            return;
        }

        // Hide the Cursors to begin with.
        CursorOnHolograms.SetActive(false);
        CursorOffHolograms.SetActive(false);
    }

    void Update()
    {
        /* TODO: DEVELOPER CODING EXERCISE 2.b */

        if (GazeManager.Instance == null || CursorOnHolograms == null || CursorOffHolograms == null)
        {
            return;
        }

        if (GazeManager.Instance.Hit)
        {
            // 2.b: SetActive true the CursorOnHolograms to show cursor.
            
            // 2.b: SetActive false the CursorOffHolograms hide cursor.
            
        }
        else
        {
            // 2.b: SetActive true CursorOffHolograms to show cursor.
            
            // 2.b: SetActive false CursorOnHolograms to hide cursor.
            
        }

        // 2.b: Assign gameObject's transform position equals GazeManager's instance Position.
        

        // 2.b: Assign gameObject's transform up vector equals GazeManager's instance Normal.
        
    }
}