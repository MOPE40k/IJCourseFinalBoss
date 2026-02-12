using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.Reactive;

public class Test : MonoBehaviour
{
    private ReactiveVeriable<int> reactiveVeriable = null;
    private IDisposable disposable = null;

    private void Awake()
    {
        reactiveVeriable = new ReactiveVeriable<int>(5);

        disposable = reactiveVeriable.Subscribe(OnReactiveChanged);
    }

    private void OnReactiveChanged(int arg1, int arg2)
    {
        Debug.Log($"OLD: {arg1} NEW: {arg2}");
        disposable.Dispose();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            reactiveVeriable.Value++;
        }
    }
}
