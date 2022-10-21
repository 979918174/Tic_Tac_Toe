using System.Collections.Generic;
using Common;
using TTTDemo.Common;
using UnityEngine;
namespace TTTDemo.GamePlay
{
    /// <summary>
    /// AI类
    /// </summary>
    public class TTTAI
    {
        //随机落子
        public void RandomStep(NormalTTT normalTtt)
        {
            List<Grid> checklist = new List<Grid>();
            //类型A：随机在空位落子
            foreach (var VARIABLE in normalTtt.grids)
            {
                if (VARIABLE.campType == CampType.Zero)
                {
                    checklist.Add(VARIABLE);
                } 
            }
            if (checklist.Count>0)
            {
                Grid grid = checklist[Random.Range(0, checklist.Count)];
                normalTtt.ChangeGrid(grid,CampType.AI);
            }
        }
        
        //AI类型1：只随机落子
        public void AITypeEasy(NormalTTT normalTtt)
        {
            RandomStep(normalTtt);
        }

        //AI类型2：权重落子
        public void AITypeSpecial(NormalTTT normalTtt)
        {
            //RandomStep(normalTtt);
            CalWeight(normalTtt);
        }

        //判断选择：根据棋盘难度决定AI类型
        public void ExecuteStep(NormalTTT normalTtt)
        {
            if (normalTtt.aiType == AIType.Easy)
            {
                AITypeEasy(normalTtt);
            }

            if (normalTtt.aiType == AIType.Special)
            {
                AITypeSpecial(normalTtt);
            }
        }
        
        //9个位置的权重算法
        //使用AI势力落子后，3连线该位置权重+100分，中间位置+1分，其他位置统统+0分
        //使用玩家势力落子后，3连线该位置权重+10分
        public bool IsLine(Grid grid,NormalTTT normalTtt)
        {
            Grid[,] grids = normalTtt.grids;
            if (grid.rowValue == 0&&grid.colValue==0)
            {
                if ((grids[0,0].campType==grids[0,1].campType&&grids[0,0].campType==grids[0,2].campType)||
                    (grids[0,0].campType==grids[1,0].campType&&grids[0,0].campType==grids[2,0].campType)||
                    (grids[0,0].campType==grids[1,1].campType&&grids[0,0].campType==grids[2,2].campType))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else

            if (grid.rowValue == 0&&grid.colValue==1)
            {
                if ((grids[0,1].campType==grids[0,0].campType&&grids[0,1].campType==grids[0,2].campType)||
                    (grids[0,1].campType==grids[1,1].campType&&grids[0,1].campType==grids[1,2].campType)) 
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            
            if (grid.rowValue == 0&&grid.colValue==2)
            {
                if ((grids[0,2].campType==grids[0,0].campType&&grids[0,2].campType==grids[0,1].campType)||
                    (grids[0,2].campType==grids[1,2].campType&&grids[0,2].campType==grids[2,2].campType)||
                    (grids[0,2].campType==grids[1,1].campType&&grids[0,2].campType==grids[2,0].campType)) 
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            
            if (grid.rowValue == 1&&grid.colValue==0)
            {
                if ((grids[1,0].campType==grids[1,1].campType&&grids[1,0].campType==grids[1,2].campType)||
                    (grids[1,0].campType==grids[0,0].campType&&grids[1,0].campType==grids[2,0].campType)) 
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            
            if (grid.rowValue == 1&&grid.colValue==1)
            {
                if ((grids[1,1].campType==grids[1,0].campType&&grids[1,1].campType==grids[1,2].campType)||
                    (grids[1,1].campType==grids[0,1].campType&&grids[1,1].campType==grids[2,1].campType)||
                    (grids[1,1].campType==grids[0,0].campType&&grids[1,1].campType==grids[2,2].campType)||
                    (grids[1,1].campType==grids[0,2].campType&&grids[1,1].campType==grids[2,0].campType)) 
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            
            if (grid.rowValue == 1&&grid.colValue==2)
            {
                if ((grids[1,2].campType==grids[1,0].campType&&grids[1,2].campType==grids[1,1].campType)||
                    (grids[1,2].campType==grids[0,2].campType&&grids[1,2].campType==grids[2,2].campType)) 
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            
            if (grid.rowValue == 2&&grid.colValue==0)
            {
                if ((grids[2,0].campType==grids[2,1].campType&&grids[2,0].campType==grids[2,2].campType)||
                    (grids[2,0].campType==grids[0,0].campType&&grids[2,0].campType==grids[1,0].campType)||
                    (grids[2,0].campType==grids[1,1].campType&&grids[2,0].campType==grids[0,2].campType)) 
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            
            if (grid.rowValue == 2&&grid.colValue==1)
            {
                if ((grids[2,1].campType==grids[2,0].campType&&grids[2,1].campType==grids[2,2].campType)||
                    (grids[2,1].campType==grids[0,1].campType&&grids[2,1].campType==grids[1,1].campType)) 
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            else
            if (grid.rowValue == 2&&grid.colValue==2)
            {
                if ((grids[2,2].campType==grids[2,0].campType&&grids[2,2].campType==grids[2,1].campType)||
                    (grids[2,2].campType==grids[0,2].campType&&grids[2,2].campType==grids[1,2].campType)||
                    (grids[2,2].campType==grids[1,1].campType&&grids[2,2].campType==grids[0,0].campType)) 
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        
        //假设空位为AI与Player分别计算每个空位的权重
        //转数组使用辅助类
        //对空位按照权重排序取第一个
        public void CalWeight(NormalTTT normalTtt)
        {
            Grid calGrid;
            
            List<Grid> checklist = new List<Grid>();
            foreach (var VARIABLE in normalTtt.grids)
            {
                if (VARIABLE.campType == CampType.Zero)
                {
                    VARIABLE.campType = CampType.AI;
                    if (IsLine(VARIABLE,normalTtt))
                    {
                        VARIABLE.prop += 100;
                    }

                    VARIABLE.campType = CampType.Player;
                    if (IsLine(VARIABLE,normalTtt))
                    {
                        VARIABLE.prop += 10;
                    }
                    VARIABLE.campType = CampType.Zero;

                    if (VARIABLE.rowValue == 1&& VARIABLE.colValue==1)
                    {
                        VARIABLE.prop += 1;
                    }
                    
                    checklist.Add(VARIABLE);
                } 
                
            }
            
            Grid[] checkArray = checklist.ToArray();
            checkArray = ArrayHelper.OrderAscending(checkArray, t => t.prop);
            //对空位按照权重排序取第一个
            calGrid =  normalTtt.grids[checkArray[0].rowValue, checkArray[0].colValue];
            normalTtt.ChangeGrid(calGrid,CampType.AI);
        }

    }
}