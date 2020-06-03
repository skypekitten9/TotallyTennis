using Assets.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FiniteStateMachine))]

public class NPC : MonoBehaviour
{
    FiniteStateMachine _finiteStateMachine;

    public void Awake()
    {
        _finiteStateMachine = this.GetComponent<FiniteStateMachine>();
    }

    public void Start()
    {
        
    }

    public void Update()
    {
        
    }
}
