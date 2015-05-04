using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CssSprite
{
    [XmlRootAttribute("Sprite", Namespace = "CssSprite", IsNullable = false)]
    public class Sprite
    {
        /// <summary>
        /// 图片路径
        /// </summary>
        private string _path;

        /// <summary>
        /// 距离x轴
        /// </summary>
        private int _locationX;

        /// <summary>
        /// 距离y轴
        /// </summary>
        private int _locationY;

        [XmlAttribute("Path")] 
        public string Path
        {
            get {return _path;}
            set { _path = value; }
        }

        [XmlAttribute("LocationX")] 
        public int LocationX
        {
            get { return _locationX; }
            set { _locationX = value; }
        }

        [XmlAttribute("LocationY")] 
        public int LocationY
        {
            get { return _locationY; }
            set { _locationY = value; }
        }
    }
}
