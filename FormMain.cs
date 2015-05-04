using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Drawing.Drawing2D;
using System.Collections;

namespace CssSprite
{
    public partial class FormMain : Form
    {
        private List<ImageInfo> _imgList;
        private string dialogFile = string.Empty;
        private string basePath;
        internal class ImageInfo
        {
            internal ImageInfo(Image img, string name, string fileName)
            {
                Image = img;
                Name = name;
                FileName = fileName;
            }

            internal readonly Image Image;
            internal readonly string Name;
            internal readonly string FileName;
        }

        public FormMain()
        {
            InitializeComponent();
            this.Resize += FormMain_Resize;
            resize();
            panelImages.MouseWheel += panelImages_MouseWheel;
            panelImages.MouseHover += panelImages_MouseHover;
        }

        void panelImages_MouseHover(object sender, EventArgs e)
        {
            panelImages.Focus();
        }

        void panelImages_MouseWheel(object sender, MouseEventArgs e)
        {
            panelImages.ResumeLayout(false);
            panelImages.Refresh();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            comboBoxBgColor.DataSource = Enum.GetNames(typeof(KnownColor));
            comboBoxBgColor.Text = "Transparent";
        }

        void FormMain_Resize(object sender, EventArgs e)
        {
            resize();
        }

        private void resize()
        {
            txtCss.Width = txtSass.Width = this.Width-20;
        }


        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (!OpenFile(false)) {
                return;
            }
            DialogResult dr = openFileDialog.ShowDialog();
            if (DialogResult.OK == dr && openFileDialog.FileNames.Length > 0)
            {
                if (!AssertFiles())
                {
                    return;
                }
                basePath = Path.GetDirectoryName(openFileDialog.FileName);
                folderBrowserDialog.SelectedPath = basePath;
                LoadImages(openFileDialog.FileNames);
                ButtonVRange_Click(null, EventArgs.Empty);
            }
        }

        private void btnSprite_Click(object sender, EventArgs e)
        {
            if (!OpenFile(true))
            {
                return;
            }
            DialogResult dr = openFileDialog.ShowDialog();
            if (DialogResult.OK == dr && openFileDialog.FileNames.Length > 0)
            {
                basePath = Path.GetDirectoryName(openFileDialog.FileName);
                folderBrowserDialog.SelectedPath = basePath;
                var spriteFile=new SpriteFile();
                try
                {
                    spriteFile = (SpriteFile)XmlSerializer.LoadFromXml(openFileDialog.FileNames[0], spriteFile.GetType());
                    if (_imgList == null)
                    {
                        _imgList = new List<ImageInfo>();
                    }
                    var noFile = "这些文件不存在：" + Environment.NewLine;
                    var hasFile=false;
                    foreach (Sprite s in spriteFile.SpriteList)
                    {
                        var path=folderBrowserDialog.SelectedPath+"\\"+ s.Path;
                        if (File.Exists(path))
                        {
                            Image img = Image.FromFile(path);
                            string imgName = Path.GetFileNameWithoutExtension(s.Path);
                            ImageInfo imgInfo = new ImageInfo(img, imgName, s.Path);
                            img.Tag = imgInfo;
                            _imgList.Add(imgInfo);
                            AddPictureBox(img, s.LocationX, s.LocationY);
                        }
                        else 
                        {
                            hasFile=true;
                            noFile += path + Environment.NewLine;
                        }
                    }
                    if (hasFile) 
                    {
                        MessageBox.Show(noFile, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    txtDir.Text = spriteFile.CssFileName;
                    txtName.Text = spriteFile.ImageName;
                    chkBoxPhone.Checked = spriteFile.IsPhone;
                    panelImages.ResumeLayout(false);
                    SetCssText();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + Environment.NewLine + ".sprite文件被损坏，无法打开！");
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Png文件|*.png|Jpeg文件|*.jpeg|Jpg文件|*.jpg";
            openFileDialog.Multiselect = false;
            DialogResult dr = openFileDialog.ShowDialog();
            if (DialogResult.OK == dr && openFileDialog.FileNames.Length > 0)
            {
                if (_imgList == null)
                {
                    _imgList = new List<ImageInfo>();
                }
                var fileName = openFileDialog.FileName;
                
                if (!IsImgExists(fileName))
                {
                    Image img = Image.FromFile(fileName);
                    string imgName = Path.GetFileNameWithoutExtension(fileName);
                    ImageInfo imgInfo = new ImageInfo(img, imgName, fileName);
                    img.Tag = imgInfo;
                    _imgList.Add(imgInfo);
                    AddPictureBox(img, 0, 0);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedPicture != null)
            { 
                var dr =  MessageBox.Show("确定删除图片：" + ((ImageInfo)_selectedPicture.Image.Tag).Name + " ？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes) {
                    foreach (ImageInfo info in _imgList)
                    {
                        if (info.Image == _selectedPicture.Image)
                        {
                            _imgList.Remove(info);
                            break;
                        }
                    }
                    panelImages.Controls.Remove(_selectedPicture);
                    _selectedPicture = null;
                }
            }
            else
            {
                MessageBox.Show("请选中你需要移除的图片！");
            }
        }

        /// <summary>
        /// 画布以及对话框初始化
        /// </summary>
        /// <param name="spriteFile"></param>
        private bool OpenFile(bool spriteFile) 
        {
            if (_imgList != null && _imgList.Count > 0)
            {
                DialogResult queryDr = MessageBox.Show("确实要重新选择图片吗？重新选择图片，当前的图片布局将丢失。", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (queryDr == DialogResult.Yes)
                {
                    _imgList.Clear();
                    panelImages.Controls.Clear();
                }
                else
                {
                    return false ;
                }
            }
            if (spriteFile)
            {
                openFileDialog.Filter = "css sprite文件|*.sprite";
                openFileDialog.Multiselect = false;
            }
            else {
                openFileDialog.Filter = "Png文件|*.png|Jpeg文件|*.jpeg|Jpg文件|*.jpg";
                openFileDialog.Multiselect = true;
            }
            return true;
        }

        /// <summary>
        /// 加载图片进画布
        /// </summary>
        /// <param name="imageFileNames"></param>
        private void LoadImages(string[] imageFileNames)
        {
            if (_imgList == null)
            {
                _imgList = new List<ImageInfo>();
            }
            foreach (string fileName in imageFileNames)
            {
                if (IsImgExists(fileName))
                {
                    continue;
                }
                Image img = Image.FromFile(fileName);
                string imgName = Path.GetFileNameWithoutExtension(fileName);
                ImageInfo imgInfo = new ImageInfo(img, imgName, fileName);
                img.Tag = imgInfo;
                _imgList.Add(imgInfo);
            }
            _imgList.Sort(ImageComparison);
        }

        int ImageComparison(ImageInfo i1, ImageInfo i2)
        {
            return i1.Image.Width > i2.Image.Width ? 1 : (i1.Image.Width == i2.Image.Width ? 0 : -1);
        }

        /// <summary>
        /// 验证是否是多个文件
        /// </summary>
        /// <returns></returns>
        private bool AssertFiles()
        {
            string[] files = openFileDialog.FileNames;
            if (files == null || (openFileDialog.Multiselect ? files.Length < 2 : files.Length <0))
            {
                MessageBox.Show("请选择多个图片文件。");
                return false;
            }
            return true;
        }

        private PictureBox _selectedPicture=null;
        private Size _bigSize;


        string GetImgExt()
        {
            string ext = comboBoxImgType.Text.ToLower();
            if (ext == "png" || ext == "gif" || ext == "jpg" || ext == "jpeg")
            {
                return ext;
            }
            return "png";
        }

        /// <summary>
        /// 得到sass代码
        /// </summary>
        /// <param name="img">图片</param>
        /// <param name="left">左边距离</param>
        /// <param name="top">右边距离</param>
        /// <returns></returns>
        string GetSassCss(Image img, int left, int top) 
        {
            ImageInfo imgInfo = (ImageInfo)img.Tag;
            var isPhone = chkBoxPhone.Checked;
            if (isPhone) {
                left = left / 2;
                top = top / 2;
            }
            var _left = left == 0 ? "0" : (0 - left).ToString() + "px";
            var _top = top == 0 ? "0" : (0 - top).ToString() + "px";
            var imgHeight = isPhone ? img.Height / 2 : img.Height;
            var imgWidth = isPhone ? img.Width / 2 : img.Width;
            return "@mixin " + GetCssName(imgInfo.Name) + "{height:" + imgHeight + "px;width:" + imgWidth + "px;" + "background-position: " + _left + " " + _top + ";}" + Environment.NewLine;
        }


        /// <summary>
        /// 获取css代码
        /// </summary>
        /// <param name="img">图片</param>
        /// <param name="left">左边距离</param>
        /// <param name="top">右边距离</param>
        /// <returns></returns>
        string GetCss(Image img, int left, int top)
        {
            ImageInfo imgInfo = (ImageInfo)img.Tag;
            var isPhone = chkBoxPhone.Checked;
            if (isPhone)
            {
                left = left / 2;
                top = top / 2;
            }
            var _left = left == 0 ? "0" : (0 - left).ToString() + "px";
            var _top = top == 0 ? "0" : (0 - top).ToString() + "px";
            var imgHeight = isPhone ? img.Height / 2 : img.Height;
            var imgWidth = isPhone ? img.Width / 2 : img.Width;
            return "." + GetCssName(imgInfo.Name) + "{height:" + imgHeight + "px;width:" + imgWidth + "px;background-position:" + _left + " " + _top + ";}" + Environment.NewLine;
        }

        string GetCssName(string imgName)
        {
            if (Char.IsNumber(imgName[0]))
            {
                return "_" + imgName;
            }
            return imgName;
        }

        
        //小图横排点击
        private void ButtonVRange_Click(object sender, EventArgs e)
        {
            if (!AssertFiles()) return;
            panelImages.Controls.Clear();
            int left = 0;
            int top = 0;
            int currentHeight = 0;
            foreach (ImageInfo ii in _imgList)
            {
                Image img = ii.Image;
                left = 0;
                top = currentHeight;

                AddPictureBox(img, left, top);
                currentHeight += img.Height;
            }
            panelImages.ResumeLayout(false);
            SetCssText();
        }

        /// <summary>
        /// 设置css的文本
        /// </summary>
        public void SetCssText() {
            
            int maxWidth, maxHeight;
            maxWidth = maxHeight = 0;
            foreach (PictureBox pb in panelImages.Controls)
            {
                maxWidth = Math.Max(maxWidth, pb.Location.X + pb.Image.Width);
                maxHeight = Math.Max(maxHeight, pb.Location.Y + pb.Image.Height);
            }
            _bigSize = new Size(maxWidth, maxHeight);
            var isPhone = chkBoxPhone.Checked;
            var sassStr = "@mixin " + txtName.Text + "{background:url(" + txtDir.Text + "/" + txtName.Text + "." + GetImgExt() + ") no-repeat;" + (isPhone ? "background-size:" + _bigSize.Width / 2 + "px " + _bigSize.Height / 2 + "px" : "") + " }" + Environment.NewLine;
            var cssStr = "." + txtName.Text + "{background:url(" + txtDir.Text + "/" + txtName.Text + "." + GetImgExt() + ")  no-repeat;" + (isPhone ? "background-size:" + _bigSize.Width / 2 + "px " + _bigSize.Height / 2 + "px" : "") + "}" + Environment.NewLine;
            foreach (PictureBox pb in panelImages.Controls)
            {
                sassStr += GetSassCss(pb.Image, pb.Left, pb.Top);
                cssStr += GetCss(pb.Image, pb.Left, pb.Top);
            }
            txtSass.Text = sassStr;
            txtCss.Text = cssStr;
        }

        public string GetImgName(Image img)
        {
            foreach (ImageInfo ii in _imgList)
            {
                if (ii.Image == img)
                {
                    return ii.Name;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 画出图片
        /// </summary>
        /// <param name="img">图片</param>
        /// <param name="left">左边</param>
        /// <param name="top">上边</param>
        private void AddPictureBox(Image img, int left, int top)
        {
            PictureBox pb = new PictureBox();
            pb.Image = img;
            pb.Location = new System.Drawing.Point(left, top);
            pb.Cursor = Cursors.SizeAll;
            pb.BorderStyle =BorderStyle.FixedSingle ;
            pb.Name = "pb_" + left + "_" + top;
            pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            //pb.Click += pb_Click;
            pb.MouseDown += pb_MouseDown;
            pb.MouseMove += pb_MouseMove;
            pb.MouseUp += pb_MouseUp;
            panelImages.Controls.Add(pb);
            pb.Show();
        }

        #region 拖动
        bool _isDragged = false;
        Point _dragStartLocation;
        void pb_MouseUp(object sender, MouseEventArgs e)
        {
            _isDragged = false;
        }

        void pb_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragged)
            {
                PictureBox pb = sender as PictureBox;
                Point p = e.Location;
                int x = Math.Max(0, pb.Location.X + p.X - _dragStartLocation.X);
                int y = Math.Max(0, pb.Location.Y + p.Y - _dragStartLocation.Y);
                pb.Location = new Point(x, y);
                panelImages.ResumeLayout(false);
                SetCssText();
            }
        }

        void pb_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _selectedPicture = (PictureBox)sender;
                _isDragged = true;
                _dragStartLocation = new Point(e.X, e.Y);
            }
            else
            {
                _isDragged = false;
            }
        }


        #endregion

        void pb_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            if (_selectedPicture != null)
            {
                _selectedPicture.BorderStyle = BorderStyle.None;
            }
            pb.BorderStyle = BorderStyle.FixedSingle;
        }

        private void ButtonMakeBigImageCss_Click(object sender, EventArgs e)
        {
            panelImages.VerticalScroll.Value=0 ;
            panelImages.HorizontalScroll.Value = 0;
            if (_imgList == null || _imgList.Count < 2)
            {
                MessageBox.Show("请选择多个背景图片。");
                return;
            }

            DialogResult dr = folderBrowserDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string imgDir = folderBrowserDialog.SelectedPath;
                if (!Directory.Exists(imgDir))
                {
                    Directory.CreateDirectory(imgDir);
                }
                string imgPath = Path.Combine(imgDir, txtName.Text+"."+GetImgExt());
                if (File.Exists(imgPath))
                {
                    if (DialogResult.Yes !=
                        MessageBox.Show("选定文件夹中已存在" + txtName.Text + "." + GetImgExt() + "，继续执行将覆盖已存在文件，是否继续？", "询问"
                        , MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        return;
                    }
                }

                int maxWidth,maxHeight,minWidth,minHeight;
                maxWidth = maxHeight = minWidth = minHeight = 0;
                //循环获取距离左边和上边最小距离
                foreach (PictureBox pb in panelImages.Controls)
                {
                    if (panelImages.Controls.GetChildIndex(pb)==0) 
                    {
                        minWidth = pb.Location.X;
                        minHeight = pb.Location.Y;
                    } 
                    minWidth = Math.Min(minWidth, pb.Location.X);
                    minHeight = Math.Min(minHeight, pb.Location.Y);
                }
                Color bgColor = GetBgColor();
                //把所有元素按照0，0点为标准，通过最小向上距离和向左距离平移，获取最大距离
                foreach (PictureBox pb in panelImages.Controls)
                {
                    var point = new Point(pb.Location.X, pb.Location.Y);
                    if (minHeight != 0)
                    {
                        point.Y = pb.Location.Y - minHeight;
                    }
                    if (minWidth != 0)
                    {
                        point.X = pb.Location.X - minWidth;
                    }
                    pb.Location = point;
                    maxWidth = Math.Max(maxWidth, pb.Location.X + pb.Image.Width);
                    maxHeight = Math.Max(maxHeight, pb.Location.Y + pb.Image.Height);
                }
                Size imgSize = new Size(maxWidth, maxHeight);
                var codeMime = string.Empty;
                using (Bitmap bigImg = new Bitmap(imgSize.Width, imgSize.Height, PixelFormat.Format32bppArgb))
                {
                    string imgType = GetImgExt();
                    ImageFormat format = ImageFormat.Png;
                    switch (imgType)
                    {
                        case "jpeg":
                            format = ImageFormat.Jpeg;
                            codeMime = "image/jpeg";
                            break;
                        case "jpg":
                            format = ImageFormat.Jpeg;
                            codeMime = "image/jpeg";
                            break;
                        case "png":
                            format = ImageFormat.Png;
                            codeMime = "image/png";
                            break;
                        case "gif":
                            format = ImageFormat.Gif;
                            codeMime = "image/gif";
                            break;
                        default:
                            break;
                    }
                    using (Graphics g = Graphics.FromImage(bigImg))
                    {
                        //设置高质量插值法 
                        g.InterpolationMode = InterpolationMode.High;
                        //设置高质量,低速度呈现平滑度 
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        //清空画布并以透明背景色填充 
                        g.CompositingQuality = CompositingQuality.HighQuality;
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                        if (bgColor == Color.Transparent && (format == ImageFormat.Jpeg|| format == ImageFormat.Gif)) g.Clear(Color.White);
                        else g.Clear(bgColor);
                        
                        SetCssText();
                        var sprite = new SpriteFile() { CssFileName = txtDir.Text, ImageName = txtName.Text, SpriteList = new List<Sprite>(), IsPhone = chkBoxPhone.Checked };                        
                        try
                        {
                            foreach (PictureBox pb in panelImages.Controls)
                            {
                                var img = (ImageInfo)pb.Image.Tag;
                                var path = img.FileName;
                                Sprite s = new Sprite() { LocationY = pb.Location.Y, LocationX = pb.Location.X, Path = Path.GetFileName(path) };
                                sprite.SpriteList.Add(s);
                                g.DrawImage(pb.Image, pb.Location.X, pb.Location.Y, pb.Image.Width, pb.Image.Height);
                                if (Path.GetDirectoryName(path) != folderBrowserDialog.SelectedPath)
                                {
                                    File.Copy(path, folderBrowserDialog.SelectedPath + "\\" + Path.GetFileName(path), false);
                                }
                            }
                            XmlSerializer.SaveToXml(folderBrowserDialog.SelectedPath + "\\" + txtName.Text + ".sprite", sprite);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message,"提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            return;
                        }
                    }
                    try
                    {
                        //保存图片
                        bigImg.Save(imgPath, format);
                        MessageBox.Show("图片生成成功！");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message+"图片生成失败，被覆盖文件可能被其他程序占用，请换个文件名！");
                    }
                }
            }
        }


        protected override bool IsInputChar(char charCode)
        {
            if (charCode == (char)Keys.Left || charCode == (char)Keys.Right || charCode == (char)Keys.Up || charCode == (char)Keys.Down)
            {
                return true;
            }

            return base.IsInputChar(charCode);
        }

        

        public bool IsImgExists(string fileName)
        {
            foreach (ImageInfo  ii in _imgList)
            {
                if (string.Compare(ii.FileName,fileName,true) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        


        /// <summary>
        /// 获取颜色
        /// </summary>
        /// <returns></returns>
        Color GetBgColor()
        {
            Color bgColor = Color.Transparent;
            string strBgColor = comboBoxBgColor.Text;
            if (!string.IsNullOrEmpty(strBgColor))
            {
                string[] knownColors = Enum.GetNames(typeof(KnownColor));
                bool isKnownColor = false;
                foreach (string kc in knownColors)
                {
                    if (kc == strBgColor)
                    {
                        isKnownColor = true;
                        break;
                    }
                }
                if (isKnownColor)
                    bgColor = Color.FromKnownColor((KnownColor)Enum.Parse(typeof(KnownColor), strBgColor));
                else
                {
                    Regex regex = new Regex("#[0-9abcdef]{6}", RegexOptions.IgnoreCase);
                    if (regex.IsMatch(strBgColor))
                    {
                        int red = int.Parse(strBgColor.Substring(1, 2),NumberStyles.AllowHexSpecifier);
                        int green = int.Parse(strBgColor.Substring(3, 2), NumberStyles.AllowHexSpecifier);
                        int blue = int.Parse(strBgColor.Substring(5, 2), NumberStyles.AllowHexSpecifier);
                        bgColor = Color.FromArgb(red,green,blue);
                    }
                    else {
                        bgColor = Color.Transparent;
                    }
                }
            }
            return bgColor;
        }

        private void comboBoxBgColor_Changed(object sender, EventArgs e)
        {
            Color bgColor = GetBgColor();
            if (bgColor == Color.Transparent)
            {
                bgColor = Color.White;
            }

            panelImages.BackColor = bgColor;
        }

        private void txtSass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control) { txtSass.SelectAll(); }   
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;
            if (radio.Checked) {
                txtCss.Visible = false;
                txtSass.Visible = true;
            }
        }

        private void radioBtnCss_CheckedChanged(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;
            if (radio.Checked)
            {
                txtCss.Visible = true;
                txtSass.Visible = false;
            }
        }

        private void txtDir_TextChanged(object sender, EventArgs e)
        {
            SetCssText();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            SetCssText();
        }

        //小图横排点击
        private void buttonHRange_Click(object sender, EventArgs e)
        {
            if (!AssertFiles()) return;
            panelImages.Controls.Clear();
            int left = 0;
            int top = 0;
            foreach (ImageInfo ii in _imgList)
            {
                Image img = ii.Image;
                AddPictureBox(img, left, top);
                left += img.Width;
            }

            panelImages.ResumeLayout(false);
            SetCssText();
        }

        private void chkBoxPhone_CheckedChanged(object sender, EventArgs e)
        {
            SetCssText();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            AboutUs a=new AboutUs();
            a.ShowDialog();
        }
    }
}