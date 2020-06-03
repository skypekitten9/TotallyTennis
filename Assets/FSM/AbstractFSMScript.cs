using Assets.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ExecutionState
{
    NONE,
    ACTIVE,
    COMPLETED,
    TERMINATED,
};

public enum FSMStateType
{
    IDLE,
    PATROL,
    CHASE,
};

public abstract class AbstractFSMScript : ScriptableObject
{
    protected NPC _npc;
    protected FiniteStateMachine _fsm;

    public ExecutionState ExecutionState { get; protected set; }
    public FSMStateType StateType { get; protected set; }
    public bool EnteredState { get; protected set; }

    public virtual void OnEnable()
    {
        ExecutionState = ExecutionState.NONE;
    }

    public virtual bool EnterState()
    {
        ExecutionState = ExecutionState.ACTIVE;

        return true;
    }

    public abstract void UpdateState();
    
    public virtual bool ExitState()
    {
        ExecutionState = ExecutionState.COMPLETED;

        return true;
    }

    public virtual void SetExecutingNPC(NPC npc)
    {
        if (_npc != null)
        {
            _npc = npc;
        }
    }

    public virtual void SetExecutingFSM(FiniteStateMachine fsm)
    {
        if (fsm != null)
        {
            _fsm = fsm;
        }
    }
}
