using Common;
using TTTDemo.Common;
using TTTDemo.Event;
using TTTDemo.GamePlay;
using UnityEngine;
using UnityEngine.UI;

namespace TTTDemo.RunTime
{
    /// <summary>
    /// 游戏流程管理
    /// </summary>
    public class GameManager : MonoSingleton<GameManager>
    {
        public ViewButton[,] viewButtons;
        //棋盘信息
        public NormalTTT normalTtt;
        //AI
        public TTTAI tttai;
        //当前执棋人
        public CampType currentCamp;
        //预制体引用
        public ViewButton viewButtonPre;
        public GameObject viewButtonGroup;
        public GameObject viewMask;
        public Sprite[] Icons;


        //设置相关
        public AIType AISetting;
        public CampType OrderSetting;
 
        public void Awake()
        {
            AISetting = AIType.Easy;
            OrderSetting = CampType.Player;
            currentCamp = OrderSetting;
            //注册事件当玩家回合结束时修改当前执棋人
            
           
            EventCenter.AddListener(EventType.Event_TurnOver, CheckTTTMessage) ;
        }
        //查看棋盘信息并处理
        public void CheckTTTMessage()
        {
            //如果还没结束，修改执棋人
            if (!normalTtt.isOver)
            {
                ChangeTurn();
            }
            //游戏结束
            else
            {
                viewMask.SetActive(true);
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (normalTtt.grids[i,j].tag==0)
                        {
                            viewButtons[i, j].GetComponent<Image>().color = new Color(0,0,0,255);
                        } 
                    }
                }
            }
        }

        //修改执棋人
        public void ChangeTurn()
        {
            if (currentCamp == CampType.Player)
            {
                currentCamp = CampType.AI;
            }else if (currentCamp == CampType.AI)
            {
                currentCamp = CampType.Player;
            }
        }
        //生成按钮
        public void GenerateViewButton()
        {
            viewButtons = new ViewButton[3,3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    viewButtons[i, j] = Instantiate(viewButtonPre, viewButtonGroup.transform);
                    viewButtons[i, j].name = "GridView_" + i + "_" + j;
                    viewButtons[i, j].rowValue = i;
                    viewButtons[i, j].colValue = j;
                }
            }
        }
        //开始游戏，初始化
        public void EnterGame()
        {
            
            Icons = Resources.LoadAll<Sprite>("Icon");

            normalTtt = new NormalTTT();
            normalTtt.aiType = AISetting;
            normalTtt.playerOrder = OrderSetting;
            normalTtt.InitTTTGame();
            
            tttai = new TTTAI();
            GenerateViewButton();
            currentCamp = OrderSetting;
        }
        //同步按钮与Grid的信息表示
        public void RefreshView()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    
                    if (normalTtt.grids[i,j].campType == CampType.AI)
                    {
                        if (normalTtt.aiType == AIType.Easy)
                        {
                            viewButtons[i, j].GetComponent<Image>().sprite = Icons[34];
                        }else if (normalTtt.aiType == AIType.Special)
                        {
                            viewButtons[i, j].GetComponent<Image>().sprite = Icons[33];
                        }
                        
                    }

                    if (normalTtt.grids[i,j].campType == CampType.Player)
                    {
                        viewButtons[i, j].GetComponent<Image>().sprite = Icons[39];;
                    }
                }
            }
        }
        //初始化配置
        //信息处理
        public void CheckStatus()
        {
            
        }
    }
}
