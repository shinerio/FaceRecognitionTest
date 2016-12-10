using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestDetect
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private String api_key = "请改成自己的api_key";
        private String api_value = "请改成自己的api_Value";
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void addFace_Click(object sender, RoutedEventArgs e)
        {
            String fliePath = ImageUtils.SelectImagePath();
             String jsonText;
            if (fliePath != null)
            {
                NameValueCollection data = new NameValueCollection();
                data.Add("api_key", api_key);
                data.Add("api_secret", api_value);
                HttpWebResponse response = HttpHelper.HttpUploadFile("https://api-cn.faceplusplus.com/facepp/v3/detect", new string[] { "image_file" }, new String[] { fliePath }, data);
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                  jsonText = stream.ReadToEnd();
                   result.Text = jsonText;
                }
                result.Text += "\n-------------------\n";
                DetectedFaceMessage message = JsonConvert.DeserializeObject<DetectedFaceMessage>(jsonText);
                //这里第二个参数请改成自己创建face_set获得的faceset_token
                AddFace(message.faces[0].face_token, "3e73a3fcc56492c707898274dd7a9827");
            }
        }


        private void createFaceSet_Click(object sender, RoutedEventArgs e)
        {
            NameValueCollection data = new NameValueCollection();
            data.Add("api_key", api_key);
            data.Add("api_secret", api_value);
            data.Add("display_name", "medicalLogin");
            data.Add("outer_id", "shinerio");
            HttpWebResponse response = HttpHelper.HttpUploadFile("https://api-cn.faceplusplus.com/facepp/v3/faceset/create", null, null, data);
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                String jsonText = stream.ReadToEnd();
                result.Text = jsonText;
            }
        }

        private void AddFace(String face_toke, String faceset_token){
                NameValueCollection data = new NameValueCollection();
                data.Add("api_key", api_key);
                data.Add("api_secret", api_value);
            data.Add("faceset_token", faceset_token);
            data.Add("face_tokens", face_toke);
            HttpWebResponse response = HttpHelper.HttpUploadFile(" https://api-cn.faceplusplus.com/facepp/v3/faceset/addface", null, null, data);
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                String jsonText = stream.ReadToEnd();
                result.Text += jsonText;
            }
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            NameValueCollection data = new NameValueCollection();
            data.Add("api_key", api_key);
            data.Add("api_secret", api_value);
            data.Add("outer_id","shinerio");
            String fliePath = ImageUtils.SelectImagePath();
            String jsonText;
            if (fliePath != null)
            {
                HttpWebResponse response = HttpHelper.HttpUploadFile("https://api-cn.faceplusplus.com/facepp/v3/search", new string[] { "image_file" }, new String[] { fliePath }, data);
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    jsonText = stream.ReadToEnd();
                    result.Text = jsonText;
                }
            }
        }
    }
}
