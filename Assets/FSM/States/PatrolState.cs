using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Assets.FSM.States
{
    [CreateAssetMenu(fileName = "PatrolState", menuName = "Unity-FSM/States/Patrol", order = 2)]
    public class PatrolState : AbstractFSMScript
    {
        EnemyPatrol patrolData;

        Transform objectTransform;
        Vector3 objectStartPos;
        Rigidbody ball;

        Vector3 rightPos;
        Vector3 leftPos;

        public override void OnEnable()
        {
            base.OnEnable();
            patrolData = GameObject.Find("EnemyPackage").GetComponent<EnemyPatrol>();
            StateType = FSMStateType.PATROL;
            objectTransform = GameObject.Find("EnemyPackage").GetComponent<Transform>();
            ball = GameObject.Find("TennisBall").GetComponent<Rigidbody>();
            objectStartPos = patrolData.startTransform.position;
        }

        public override bool EnterState()
        {
            EnteredState = false;

            if (base.EnterState())
            {
                UnityEngine.Debug.Log("ENTERING PATROL STATE");

                rightPos = new Vector3(objectStartPos.x + 4.0f, objectStartPos.y, objectStartPos.z + 15.85f);
                leftPos = new Vector3(objectStartPos.x - 4.0f, objectStartPos.y, objectStartPos.z + 15.85f);
            }

            EnteredState = true;

            return EnteredState;
        }

        public override void UpdateState()
        {
            float speed = 1f;

            if (EnteredState)
            {
                UnityEngine.Debug.Log("UPDATING PATROL STATE");
                if (ball.velocity.z > 0)
                {
                    _fsm.EnterState(FSMStateType.CHASE);
                    UnityEngine.Debug.Log("ENTERING CHASE STATE");
                }
            }

            objectTransform.position = Vector3.Lerp(rightPos, leftPos, Mathf.PingPong(Time.time * speed, 1.0f));
        }
    }
}
