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
        /// 手机端单位
        /// </summary>
        private string _phoneUnit;

        /// <summary>
        /// 手机端缩小比例
        /// </summary>
        private string _phoneFigure;

        /// <summary>
        /// 雪碧图文件类型
        /// </summary>
        private string _spriteImgFileType;

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

        [XmlAttribute("PhoneFigure")]
        public string PhoneFigure
        {
            get { return _phoneFigure; }
            set { _phoneFigure = value; }
        }

        [XmlAttribute("PhoneUnit")]
        public string PhoneUnit
        {
            get { return _phoneUnit; }
            set { _phoneUnit = value; }
        }

        [XmlAttribute("SpriteImgFileType")]
        public string SpriteImgFileType
        {
            get { return _spriteImgFileType; }
            set { _spriteImgFileType = value; }
        }

        [XmlArray("SpriteList")]
        public List<Sprite> SpriteList
        {
            get { return _spriteList; }
            set { _spriteList = value; }
        }
    }
}
