using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DelegateMathTest : MonoBehaviour
{
    public delegate int CalculateDelegate(int number1, int number2); // Delegate Tanimlamak
    public CalculateDelegate calculateDelegate; // Delegate Objesini Olusturmak

    private void Start()
    {
        calculateDelegate += Addition; 
        calculateDelegate += Subtraction;
        calculateDelegate += Multiplication;
        // Bu sekilde += veya -= ile Delegate objemizin içerisine methodlarimizi ekleyebiliyoruz.
        // Default olarak DelegateObjemiz = null'dir.
        // Dolayisiyla cagirmadan once if(calculateDelegate != null) ifadesi altinda cagirilabilir. 

        calculateDelegate += (number1, number2) => number1 / number2;
        // Lambda Expression dedigimiz durum, bu sekilde tanimlanmamis methodu cagirmaktir. 
        // Sadece parametrelerini girerek ve geriye döndermesini istedigimiz ifadeyi,
        //     => sonrasinda belirterek calculateDelegate objemize ekledik.
        
        Delegate[] functions = calculateDelegate.GetInvocationList();
        // Birden fazla methodu tek seferde cagirmak istiyorsak methodlari öncesinde ekleyip, delegate dizisinde tutmaliyiz.

        for (int i = 0; i < functions.Length; i++)
        {
            int result = ((CalculateDelegate)functions[i]).Invoke(13, 3);
            // CalculateDelegate türünde functions dizimizin icerisindeki fonksiyonları Invoke ile cagiriyoruz.
            Debug.Log(result);
        }
    }

    private int Addition(int a, int b)
    {
        return a + b;
    }
    
    private int Subtraction(int a, int b)
    {
        return a - b;
    }
    
    private int Multiplication(int a, int b)
    {
        return a * b;
    }
}
