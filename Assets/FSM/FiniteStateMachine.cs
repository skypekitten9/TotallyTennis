using Assets.FSM.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.FSM
{
    public class FiniteStateMachine : MonoBehaviour
    {
        [SerializeField] AbstractFSMScript _startingState;

        AbstractFSMScript _currentState;

        [SerializeField] List<AbstractFSMScript> _validStates;

        Dictionary<FSMStateType, AbstractFSMScript> _fsmStates;

        public void Awake()
        {
            _currentState = null;

            _fsmStates = new Dictionary<FSMStateType, AbstractFSMScript>();

            NPC npc = this.GetComponent<NPC>();

            foreach(AbstractFSMScript state in _validStates)
            {
                state.SetExecutingFSM(this);
                state.SetExecutingNPC(npc);
                _fsmStates.Add(state.StateType, state);
            }
        }

        public void Start()
        {
            EnterState(FSMStateType.IDLE);
        }

        public void Update()
        {
            if (_currentState != null)
            {
                _currentState.UpdateState();
            }
        }

        #region STATE MANAGEMENT

        public void EnterState(AbstractFSMScript nextState)
        {
            if (nextState == null)
            {
                return;
            }

            if(_currentState != null)
            {
                _currentState.ExitState();
            }

            _currentState = nextState;
            _currentState.EnterState();
        }

        public void EnterState(FSMStateType stateType)
        {
            if (_fsmStates.ContainsKey(stateType))
            {
                AbstractFSMScript nextstate = _fsmStates[stateType];

                EnterState(nextstate);
            }
        }

        #endregion
    }
}
