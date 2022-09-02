using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class DelegateTest : MonoBehaviour
{
    public delegate void Delegate(); // Tanimlama
    public Delegate delegateTest; // Obje olusturma

    private void Start()
    {
        delegateTest += Debug1;

        AddMethodToDelegate(Debug2);
        RemoveMethodFromDelegate(Debug1);
        
        if (delegateTest != null)
            delegateTest();
    }

    private void Debug1()
    {
        Debug.Log("Debug 1 Worked!");
    }

    private void Debug2()
    {
        Debug.Log("Debug 2 Worked!");
    }

    public void AddMethodToDelegate(Delegate method)
    {
        delegateTest += method;
    }

    public void RemoveMethodFromDelegate(Delegate method)
    {
        delegateTest -= method;
    }
}
