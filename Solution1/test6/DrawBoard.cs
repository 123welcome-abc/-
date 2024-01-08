using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace test6
{
    internal class DrawBoard
    {
        public delegate double Func(double x);
        public DrawBoard(int h, int w)
        {
            _W = w;
            _H = h;
            _board = new bool[ _H,_W ];

        }
        public void Draw(Func f, double x0, double y0, double x1, double y1)
        {
            
            //计算点阵
            //计算图形的比例
            double scaleX = _W/(x1 - x0);
            double scaleY = _H/(y1 - y0);
            //double scale = _W / (xl - x0);
            //计算图形的原点

            double originX = -x0 * scaleX;
            double originY = y1 * scaleY;
            //遍历x轴的范围
            for (double x = x0; x <= x1; x += 0.05)
            {
                //计算函数的值
                double y = f(x);
                //将函数的值转换为点阵的索引
                int px = (int)(originX + x * scaleX);
                int py = (int)(originY + y * scaleY);
                //将对应的点阵元素设为true
                if (px >= 0 && px < _W && py >= 0 && py < _H )
                {
                    _board[py, px] = true;
                }
                else
                {
                    _board[py, px] = false;
                }
            }
            //输出点阵
            for (int i = 0;i<_H;i++)
            {
                for(int j = 0; j < _W; j++)
                {
                    //if(j== originX && i== originY)
                        //Console.Write('-');
                    Console.Write(_board[i,j] ? '*' :' ');
                }
            }
        }
        private int _W, _H;
        private bool [,] _board;
    }
}
