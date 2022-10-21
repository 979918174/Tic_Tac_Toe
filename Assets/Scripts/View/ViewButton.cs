
using UnityEngine;
using TTTDemo.Event;
namespace TTTDemo.RunTime
{
    /// <summary>
    /// 
    /// </summary>
    public class ViewButton : MonoBehaviour
    {
        public GameManager gameManager;
        public int rowValue;
        public int colValue;
        
        public void ChangeValue()
        {
            //判断按钮状态
            if (GameManager.Instance.normalTtt.ChangeGrid(GameManager.Instance.normalTtt.grids[rowValue,colValue],GameManager.Instance.currentCamp))
            {
                GameManager.Instance.normalTtt.CheckGridsStatus();
                GameManager.Instance.RefreshView();
                //关闭该按钮
                //玩家回合结束，事件通知
                EventCenter.Broadcast(EventType.Event_TurnOver);
            }
        }
        private void Update()
        {
            //GetComponentInChildren<Text>().text = gameManager.normalTtt.grids[rowValue,colValue].campType.ToString();
            
        }
    }
}
