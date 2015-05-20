using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CssSprite
{
    /// <summary>
    /// 选择区域
    /// </summary>
    public class Area
    {
        /// <summary>
        /// 零点位置
        /// </summary>
        private Point _zeroPoint;

        /// <summary>
        /// 高度
        /// </summary>
        private int _height;

        /// <summary>
        /// 宽度
        /// </summary>
        private int _width;


        public Point ZeroPoint
        {
            get { return _zeroPoint == null ? new Point() : _zeroPoint; }
            set { _zeroPoint = value; }
        }

        public int Height
        {
            get { return _height ; }
            set { _height = value; }
        }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }
    }
}
