using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.FSM.States
{
    [CreateAssetMenu(fileName = "ChaseState", menuName = "Unity-FSM/States/Chase", order = 3)]
    public class ChaseState : AbstractFSMScript
    {
        Transform objectTransform;
        Vector3 objectStartPos;
        Transform ballPos;
        Rigidbody ball;

        public override void OnEnable()
        {
            base.OnEnable();
            StateType = FSMStateType.CHASE;
            objectTransform = GameObject.Find("EnemyPackage").GetComponent<Transform>();
            ball = GameObject.Find("TennisBall").GetComponent<Rigidbody>();
            ballPos = GameObject.Find("TennisBall").GetComponent<Transform>();
            objectStartPos = objectTransform.position;
        }

        public override bool EnterState()
        {
            EnteredState = false;

            if (base.EnterState())
            {
                UnityEngine.Debug.Log("ENTERING CHASE STATE");
            }

            EnteredState = true;

            return EnteredState;
        }
        public override void UpdateState()
        {
            float speed = 5;

            if (objectTransform.position.x < ballPos.position.x)
            {
                objectTransform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            else
            {
                objectTransform.Translate(-Vector3.right * speed * Time.deltaTime);
            }

            if (ball.velocity.z < 0)
            {
                _fsm.EnterState(FSMStateType.PATROL);
                UnityEngine.Debug.Log("ENTERING PATROL STATE");
            }
        }
    }
}
