
using TTTDemo.Common;
using TTTDemo.RunTime;

namespace TTTDemo.FSM
{
    /// <summary>
    /// 当前执棋人为AI条件
    /// </summary>
    public class AITurnTrigger : FSMTrigger
    {
        public override void Init()
        {
            TriggerID = FSMTriggerID.AITurn;
        }

        public override bool HandleTrigger(FSMBase fsm)
        {
            return fsm.GetComponent<GameManager>().currentCamp == CampType.AI;
        }
    }
}
