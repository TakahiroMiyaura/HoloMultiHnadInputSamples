using System.Collections;
using System.Collections.Generic;
using HUX.Utility;
using UnityEngine;

[RequireComponent(typeof(LocalHandInput))]
public class ManupilateCube : MonoBehaviour
{
    /// <summary>
    /// Hand Gesture Component.
    /// </summary>
    private LocalHandInput input;

    /// <summary>
    /// Initial world position of GameObject field.
    /// </summary>
    private Vector3 _initializePos;
    
    /// <summary>
    /// material of GameObject field.
    /// </summary>
    private Material material;

    // Use this for initialization
    void Start ()
	{
	    input = gameObject.GetComponent<LocalHandInput>();
        _initializePos = gameObject.transform.localPosition;
        material = new Material(Shader.Find("Diffuse"));
	    gameObject.GetComponent<Renderer>().material = material;
	}
	
	// Update is called once per frame
	void Update ()
	{

        //if Hand is lost,this gameobject's color is become Red.
        material.color = InputSources.Instance.hands.GetHandState(input.Handedness, input.MinConfidence) == null ? Color.red : new Color(.4f,.4f,1f);

        gameObject.transform.position = _initializePos + input.LocalPosition;
	}
}
