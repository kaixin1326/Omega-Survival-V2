using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BlinkEffect : MonoBehaviour
{
    public float glowMaxSize;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        SerializedObject halo = new SerializedObject(GetComponent("Halo"));
        halo.FindProperty("m_Size").floatValue = Mathf.PingPong(Time.time, glowMaxSize);
        halo.ApplyModifiedProperties();
    }
}
