using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : EnemyState
{

    protected D_MoveState stateData;

    protected bool isDetectingWall;
    protected bool isDetectingLedge;
    public MoveState(FiniteStateMachine statemachine, Entity entity, string animBoolName, D_MoveState stateData) : base(statemachine, entity, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(stateData.movementSpeed);

        isDetectingLedge = entity.CheckLedge();
        isDetectingWall = entity.CheckWall();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        isDetectingLedge = entity.CheckLedge();
        isDetectingWall = entity.CheckWall();
    }
}
