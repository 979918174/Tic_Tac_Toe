
using TTTDemo.Common;
using TTTDemo.RunTime;

namespace TTTDemo.FSM
{
    /// <summary>
    /// 当前执棋人为玩家条件
    /// </summary>
    public class GameOverTrigger : FSMTrigger
    {
        public override void Init()
        {
            TriggerID = FSMTriggerID.GameOver;
        }

        public override bool HandleTrigger(FSMBase fsm)
        {
            return fsm.GetComponent<GameManager>().normalTtt.CheckWhoIsWin() != CampType.Zero||fsm.GetComponent<GameManager>().normalTtt.CheckWhoIsWin()==CampType.Zero&&!fsm.GetComponent<GameManager>().normalTtt.IsRemainGrid();
        }
    }
}
