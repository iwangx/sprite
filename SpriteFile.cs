using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CssSprite
{
    [XmlRootAttribute("SpriteFile", Namespace = "CssSprite", IsNullable = false)]
    public class SpriteFile
    {
        /// <summary>
        /// css文件路径
        /// </summary>
        private string _cssFileName;

        /// <summary>
        /// 生成的雪碧图名称
        /// </summary>
        private string _imageName;

        /// <summary>
        /// 是否是手机端
        /// </summary>
        private bool _isPhone;

        /// <summary>
        /// 图片列表（路径，X,Y）
        /// </summary>
        private List<Sprite> _spriteList;

        [XmlAttribute("CssFileName")]
        public string CssFileName
        {
            get { return _cssFileName; }
            set { _cssFileName = value; }
        }

        [XmlAttribute("ImageName")]
        public string ImageName
        {
            get { return _imageName; }
            set { _imageName = value; }
        }

        [XmlAttribute("IsPhone")]
        public bool IsPhone
        {
            get { return _isPhone; }
            set { _isPhone = value; }
        }

        [XmlArray("SpriteList")]
        public List<Sprite> SpriteList
        {
            get { return _spriteList; }
            set { _spriteList = value; }
        }
    }
}
