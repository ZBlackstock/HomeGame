using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_MoveState : MoveState
{

    private Enemy1 enemy;
    public E1_MoveState(FiniteStateMachine statemachine, Entity entity, string animBoolName, D_MoveState stateData, Enemy1 enemy) : base(statemachine, entity, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isDetectingWall || !isDetectingLedge)
        {
            enemy.idleState.setFlipAfterIdle(true);
            statemachine.ChangeState(enemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
