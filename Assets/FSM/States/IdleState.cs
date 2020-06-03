using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.FSM.FSMStates
{
    [CreateAssetMenu(fileName = "IdleState", menuName = "Unity-FSM/States/Idle", order = 1)]
    public class IdleState : AbstractFSMScript
    {
        Rigidbody ball;

        public override void OnEnable()
        {
            base.OnEnable();
            StateType = FSMStateType.IDLE;

            ball = GameObject.Find("TennisBall").GetComponent<Rigidbody>();
        }

        public override bool EnterState()
        {
            EnteredState = base.EnterState();

            if (EnteredState)
            {
                UnityEngine.Debug.Log("ENTERED IDLE STATE");
            }

            EnteredState = true;

            return EnteredState;
        }

        public override void UpdateState()
        {
            if (EnteredState)
            {
                UnityEngine.Debug.Log("UPDATING IDLE STATE");

                if (ball.velocity.z > 0)
                {
                    _fsm.EnterState(FSMStateType.CHASE);
                }
            }
        }

        public override bool ExitState()
        {
            base.ExitState();
            UnityEngine.Debug.Log("EXITING IDLE STATE");
            UnityEngine.Debug.Log("ENTERING CHASE STATE");

            return true;
        }
    }
}
