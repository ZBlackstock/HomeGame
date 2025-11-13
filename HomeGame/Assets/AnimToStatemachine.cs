using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimToStatemachine : MonoBehaviour
{
    public AttackState attackState;
    private void TriggerAtack()
    {
        attackState.TriggerAttack();
    }
    private void FinishAttack()
    {
        attackState.FinishAttack();
    }
}
