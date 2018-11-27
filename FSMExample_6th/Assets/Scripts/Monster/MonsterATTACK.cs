using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterATTACK : MonsterFSMState {

    public override void BeginState()
    {
        base.BeginState();
        if (_manager.Target.GetComponent<FSMManager>().CurrentState == PlayerState.DEAD)
        {
            _manager.SetState(MonsterState.IDLE);
        }
    }

    public override void EndState()
    {
        base.EndState();
    }

    private void Update()
    {
        if (Vector3.Distance(_manager.PlayerTransform.position, transform.position) >= _manager.Stat.AttackRange)
        {
            _manager.SetState(MonsterState.CHASE);
            return;
        }

    }

    public void AttackCheck()
    {
        CharacterStat targetStat =
            _manager.Target.GetComponent<CharacterStat>();

        CharacterStat.ProcessDamage(_manager.Stat, targetStat);
    }
}
