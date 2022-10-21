using TTTDemo.Common;
using UnityEngine;

namespace TTTDemo.GamePlay
{
    /// <summary>
    /// 井字棋类
    /// </summary>
    public class NormalTTT
    {
        //当前格
        public Grid checkGrid;

        //棋盘，格子集合
        public Grid[,] grids;

        //谁先手
        public CampType playerOrder;
        
        //AI难度
        public AIType aiType;

        //是否结束
        public bool isOver = false;

        //初始化游戏
        public void InitTTTGame()
        {
            isOver = false;
            InitGrids();
        }
        //初始化棋盘
        public void InitGrids()
        {
            grids = new Grid[3,3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    grids[i,j] = new Grid();
                    grids[i,j].campType = CampType.Zero;
                    grids[i,j].tag = 0;
                    grids[i,j].prop = 0;
                    grids[i,j].rowValue = i;
                    grids[i,j].colValue = j;
                }
            }
        }

        //是否还有空位
        public bool IsRemainGrid()
        {
            bool isRemain = false;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grids[i,j].campType==CampType.Zero)
                    {
                        isRemain = true;
                        
                    }
                }
            }
            return isRemain;
        }
        //读取设置参数，用于改变AI和先后手

        //检查格子信息并处理信息
        public void CheckGridsStatus()
        {
            if (CheckWhoIsWin()!=CampType.Zero)
            {
                isOver = true;
            }

            if (CheckWhoIsWin()==CampType.Zero&&!IsRemainGrid())
            {
                isOver = true;
            }
        }

        //返回获胜方
        public CampType CheckWhoIsWin()
        {
            if (checkGrid == null)
                return CampType.Zero;
            int i = checkGrid.rowValue;
            int j = checkGrid.colValue;
            
            //判断当行
            if (grids[i,0].campType==grids[i,1].campType&&grids[i,0].campType==grids[i,2].campType&&grids[i,0].campType!=CampType.Zero)
            {
                //添加标记
                grids[i,0].tag = 1;
                grids[i,1].tag = 1;
                grids[i,2].tag = 1;
                return grids[i, j].campType;
            }
            //判断当列
            if (grids[0,j].campType==grids[1,j].campType&&grids[0,j].campType==grids[2,j].campType&&grids[0,j].campType!=CampType.Zero)
            {
                //添加标记
                grids[0,j].tag = 1;
                grids[1,j].tag = 1;
                grids[2,j].tag = 1;
                return grids[i, j].campType;
            }
            //判断对角
            if (grids[0,0].campType!=CampType.Zero&&grids[0,0].campType==grids[1,1].campType&&grids[0,0].campType==grids[2,2].campType)
            {
                //添加标记
                grids[0,0].tag = 1;
                grids[1,1].tag = 1;
                grids[2,2].tag = 1;
                return grids[0, 0].campType;
            }
            //判断逆对角
            if (grids[0,2].campType!=CampType.Zero&&grids[0,2].campType==grids[1,1].campType&&grids[0,2].campType==grids[2,0].campType)
            {
                //添加标记
                grids[0,2].tag = 1;
                grids[1,1].tag = 1;
                grids[2,0].tag = 1;
                return grids[0, 2].campType;
            }

            //还没有人获胜
            return CampType.Zero;
        }
        //检查是否胜利
        //检查是否即将胜利
        
        
        //更改格子信息，玩家用点击或者拖拽，AI直接返回对象进行修改，逻辑判断返回是否修改bool
        public bool ChangeGrid(Grid grid,CampType campType)
        {
            if (grid.campType == CampType.Zero)
            {
                grid.campType = campType;
                checkGrid = grid;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
