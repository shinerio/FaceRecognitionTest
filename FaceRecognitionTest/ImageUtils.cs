using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDetect
{
    class ImageUtils
    {
        //返回选择图片，取消返回null
        public static String SelectImagePath()
        {
            System.Windows.Forms.OpenFileDialog openFile = new System.Windows.Forms.OpenFileDialog();
            openFile.Title = "选择游戏";
            openFile.Filter = "图片|*.jpg||*.png";
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;
            System.Windows.Forms.DialogResult result = openFile.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                return null;
            }
           return openFile.FileName;
        }

    }
}
