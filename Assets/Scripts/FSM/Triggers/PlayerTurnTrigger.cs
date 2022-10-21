
using TTTDemo.Common;
using TTTDemo.RunTime;

namespace TTTDemo.FSM
{
    /// <summary>
    /// 当前执棋人为玩家条件
    /// </summary>
    public class PlayerTurnTrigger : FSMTrigger
    {
        public override void Init()
        {
            TriggerID = FSMTriggerID.PlayerTurn;
        }

        public override bool HandleTrigger(FSMBase fsm)
        {
            return fsm.GetComponent<GameManager>().currentCamp == CampType.Player;
        }
    }
}
