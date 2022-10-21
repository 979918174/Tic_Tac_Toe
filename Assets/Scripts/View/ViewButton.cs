
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
            //�жϰ�ť״̬
            if (GameManager.Instance.normalTtt.ChangeGrid(GameManager.Instance.normalTtt.grids[rowValue,colValue],GameManager.Instance.currentCamp))
            {
                GameManager.Instance.normalTtt.CheckGridsStatus();
                GameManager.Instance.RefreshView();
                //�رոð�ť
                //��һغϽ������¼�֪ͨ
                EventCenter.Broadcast(EventType.Event_TurnOver);
            }
        }
        private void Update()
        {
            //GetComponentInChildren<Text>().text = gameManager.normalTtt.grids[rowValue,colValue].campType.ToString();
            
        }
    }
}
