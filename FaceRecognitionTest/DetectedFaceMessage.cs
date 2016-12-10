using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDetect
{
    class DetectedFaceMessage
    {
        public String request_id{get;set;}
        //人脸详细信息
        public BasicFaces[] faces{ get; set; }
        public String image_id{get;set;}
        public int time_used{get;set;}
        public String error_messge { get; set; }
    }
    class BasicFaces
    {
        public String face_token { get; set; }
        public Object face_rectangle { get; set; }//里面的字段没加，如果有需要，请参考官方文档加上
    } 
}
