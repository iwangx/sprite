using System;
using System.Collections.Generic;
using System.Text;

namespace CssSprite
{
    /// <summary>
    /// 边缘尺寸
    /// </summary>
    public class EdgeSize
    {
        private int _minHeight;
        private int _minWidth;
        private int _maxHeight;
        private int _maxWidth;

        public int MinHeight
        {
            get { return _minHeight; }
            set { _minHeight = value; }
        }

        public int MinWidth
        {
            get { return _minWidth; }
            set { _minWidth = value; }
        }

        public int MaxHeight
        {
            get { return _maxHeight; }
            set { _maxHeight = value; }
        }

        public int MaxWidth
        {
            get { return _maxWidth; }
            set { _maxWidth = value; }
        }
    }
}
