using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CssSprite
{
     [XmlRootAttribute("VersionInfo")]
    public class VersionInfo
    {
         private string _version;

         private string _downloadUrl;

         private string _introductionUrl;

         /// <summary>
         /// 版本名称
         /// </summary>
         [XmlElement("Version")]
         public string Version
         {
             get { return _version; }
             set { _version = value; }
         }

         /// <summary>
         /// 下载地址
         /// </summary>
         [XmlElement("DownloadUrl")]
         public string DownloadUrl
         {
             get { return _downloadUrl; }
             set { _downloadUrl = value; }
         }

         /// <summary>
         /// 介绍地址
         /// </summary>
         [XmlElement("IntroductionUrl")]
         public string IntroductionUrl
         {
             get { return _introductionUrl; }
             set { _introductionUrl = value; }
         }
    }

}
