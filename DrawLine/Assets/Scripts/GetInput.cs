using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;
*/
public class GetInput : MonoBehaviour
{
    /*
    private DrawLine line;
    InputStateHistory history;

    void Awake()
    {
        line = GetComponent<DrawLine>();
        history = new InputStateHistory<Vector2>(Mouse.current.position);
    }

    void OnDestroy()
    {
        history.Dispose();
    }

    void OnEnable() => history.StartRecording();

    void OnDisable() => history.StopRecording();


    void Update()
    {
        foreach( var record in history)
        {
            var pos = record.ReadValue<Vector2>();
            line.AddPosition(pos);
        }
    }
    */
}