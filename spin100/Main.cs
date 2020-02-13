using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rm.json;

namespace spin100_Keaimao_SDK
{
    // <summary>
    // 可爱猫c#SDK  由spin100 编写   QQ83329963，QQ群778221666   欢迎大佬一起讨论完善
    // </summary>
    public class Main 
    {
        #region Main Info
        public static Student one = new Student();
        //插件信息配置     
        [DllExport(ExportName = "LoadingInfo", CallingConvention = CallingConvention.StdCall)]
        //加载插件信息
        public static int LoadingInfo(int session)
        {
            one.name = "疫情";//插件名,这里插件名字要和生成的插件名一致
            one.desc = "描述简介";//描述简介
            one.author = "RichardMiku";//作者
            one.version = "1.0.0";//插件版本
            one.api_version = "4.1";//插件SDK版本号，默认不可修改
            one.menu_title = "设置"; //打开插件按钮标题
            one.cover_base64 = API.Imgbase64;//插件logo,图片经过转码后的base64数据
            one.developer_key = "818198829";// 开发者key，默认不可修改
            string jsonData = JsonConvert.SerializeObject(one);
            API.Auth_code = API.Initialize(session, jsonData);
            return API.Auth_code;
        }
      
        [DllExport(ExportName = "EventInit", CallingConvention = CallingConvention.StdCall)]
        public static int EventInit() //EventInit事件 ——在可爱猫启动时触发此事件
        {
           
            //框架为插件所创建的一个目录，希望作者们把当前插件的所有数据都写入到此目录下面，以免跟其他插件混淆
            return 0;
        }
        [DllExport(ExportName = "EventEnable", CallingConvention = CallingConvention.StdCall)]
        public static int EventEnable() //插件被启用事件， 插件启用时，运行一次这里（在可爱猫启动的时候也会触发一次）
        {
            /*
            插件启用时，运行一次这里（在可爱猫启动的时候也会触发一次）
            */

            return 0;
        }
        [DllExport(ExportName = "EventStop", CallingConvention = CallingConvention.StdCall)]

        public static int EventStop() //插件被点击停止按钮时/插件重载/插件卸载/软件退出，触发此事件
        {


            return 0;
        }

        [DllExport(ExportName = "EventLogin", CallingConvention = CallingConvention.StdCall)]
        public static int EventLogin(string rob_wxid,string rob_wxname,int type) //事件 ——新的账号登录成功/下线时，触发此事件
        {

            MessageBox.Show("登录成功：" + rob_wxname);

            return 0;
        }
        #endregion
        #region Main Event
        /// <summary>
        /// 群消息事件
        /// </summary>
        /// <param name="robot_wxid">机器人帐号ID</param>
        /// <param name="type">消息类型，1文本，3图片，34语音，42名片，43视频，47动态表情，48地理位置，49分享链接，2001红包，2002小程序，2003群邀请</param>
        /// <param name="from_wxid">来源群ID</param>
        /// <param name="from_name">来源群昵称</param>
        /// <param name="final_from_wxid">具体发群消息的成员ID</param>
        /// <param name="final_from_name">具体发群消息的成员昵称</param>
        /// <param name="to_wxid">接收信息的人的ID，（一般是机器人收到消息，所以是机器人的id,如果是机器人主动发消息给别人，那就是别人的id）</param>
        /// <param name="Msg">群消息内容</param>
        /// <returns></returns>
        [DllExport(ExportName = "EventGroupMsg", CallingConvention = CallingConvention.StdCall)]
        public static int EventGroupMsg(string robot_wxid,int type,string from_wxid,string from_name,string final_from_wxid,string final_from_name,string to_wxid,string Msg)//群消息事件
        {
            Get gt = new Get();
            string msg_s;
            int str;
            str = Msg.Length;
            string right;
            string left;
            if (str > 2)
            {
                right = Msg.Substring(Msg.Length - 2);
                left = Msg.Substring(0, 2);
                if (right == "疫情")
                {
                    msg_s = gt.Getjson(left);
                    API.SendTextMsg(robot_wxid, from_wxid, msg_s);
                }
            }
            /*
            if (type==1)
            {
             API.SendTextMsg(robot_wxid, from_wxid,"我是复读机："+ Msg);
            }
            */
            return 0;
        }
        /// <summary>
        /// 私聊消息事件
        /// </summary>
        /// <param name="robot_wxid">机器人帐号ID</param>
        /// <param name="type">消息类型，1文本，3图片，34语音，42名片，43视频，47动态表情，48地理位置，49分享链接，2001红包，2002小程序，2003群邀请</param>
        /// <param name="from_wxid">来源群ID</param>
        /// <param name="from_name">来源群昵称</param>
        /// <param name="to_wxid">接收信息的人的ID，（一般是机器人收到消息，所以是机器人的id,如果是机器人主动发消息给别人，那就是别人的id）</param>
        /// <param name="Msg">群消息内容</param>
        /// <returns></returns>
        [DllExport(ExportName = "EventFriendMsg", CallingConvention = CallingConvention.StdCall)]
        public static int EventFriendMsg(string robot_wxid,int type, string from_wxid, string from_name, string to_wxid, string Msg) //私聊消息事件
        {
            Get gt = new Get();
            API.AppendLogs("收到一条私聊信息："+Msg);
            API.AppendLogs("类型："+ type);
            API.AppendLogs("from_wxid：" + from_wxid);
            API.AppendLogs("from_name：" + from_name);
            /*
            if (type == 1)
            {
                API.SendTextMsg(robot_wxid, from_wxid, "我是复读机：" + Msg);
            }
            */
            string msg_s;
            int str;
            str = Msg.Length;
            string right;
            string left;
            if (str > 2)
            {
                right = Msg.Substring(Msg.Length - 2);
                left = Msg.Substring(0, 2);
                if (right =="疫情")
                {
                    msg_s = gt.Getjson(left);
                    API.SendTextMsg(robot_wxid, from_wxid, msg_s);
                }
            }
            return 0;
        }
        #endregion
        #region Other Event
        [DllExport(ExportName = "EventReceivedTransfer", CallingConvention = CallingConvention.StdCall)]
        public static int EventReceivedTransfer(string robot_wxid,string from_wxid, string from_name, string to_wxid,string money,string Msg_json) //收到转账事件
        {
            /*
             robot_wxid  机器人帐号ID
             from_wxid  来源用户ID
             from_name   来源用户昵称
             to_wxid
             money  金额
             Msg_json    json格式数据消息，请自行解析
             */
            if (API.JsonMsg(Msg_json)["is_arrived"].ToString() == "1")//判断是否为即时转账类型，因为有可能是延迟转账类型，1即时转账，0延迟转账
            {

                if (API.JsonMsg(Msg_json)["is_received"].ToString() == "0")//等于0 就是还没收钱
                {
                    API.AcceptTransfer(robot_wxid, from_wxid, Msg_json);//调用收钱API 接收好友转账
                }

                if (API.JsonMsg(Msg_json)["is_received"].ToString() == "1")//收款成功,收钱后第二次事件to_wxid才是原来转账的用户ID
                {
                    //这个时候给你转账的用户ID为=to_wxid
                    //根据ID查用户名，调用方法  API.nickname(robot_wxid, to_wxid)

                }
            }

            return 0;// 返回0 下个插件继续处理该事件，返回1 拦截此事件不让其他插件执行
        }
        [DllExport(ExportName = "EventScanCashMoney", CallingConvention = CallingConvention.StdCall)]
        public static int EventScanCashMoney(string robot_wxid, string pay_wxid, string pay_name,string money,string Msg_json) //面对面收款事件
        {
            /*
             robot_wxid  收钱的人帐号ID
             pay_wxid   来源用户ID
             pay_name  来源用户昵称
             money  金额
             Msg_json   更多数据：json数据格式数据消息，请自行解析
             */
            

            return 0; // 返回0 下个插件继续处理该事件，返回1 拦截此事件不让其他插件执行
        }
        [DllExport(ExportName = "EventFriendVerify", CallingConvention = CallingConvention.StdCall)]
        public static int EventFriendVerify(string robot_wxid, string from_wxid, string from_name, string to_wxid,string Msg_json) //好友请求事件
        {
            /*
             robot_wxid  机器人帐号ID
             from_wxid   陌生人用户ID
             from_name   陌生人用户昵称
             to_wxid           忽略
             Msg_json    (详细好友验证信息：1群内添加时候包含群ID，2名片推荐添加时，包含推荐人ID和名称，3w微信号，手机号搜索时候添加)
            */
            return 0;// 返回0 下个插件继续处理该事件，返回1 拦截此事件不让其他插件执行
        }
        [DllExport(ExportName = "EventGroupMemberAdd", CallingConvention = CallingConvention.StdCall)]
        public static int EventGroupMemberAdd(string robot_wxid, string from_wxid, string from_name,string Msg_json) //群成员增加事件
        {
            /*
           robot_wxid  机器人帐号ID
           from_wxid   来源群ID
           from_name   来源群昵称
           Msg_json    自行解析json格式数据
          */
           
            return 0;// 返回0 下个插件继续处理该事件，返回1 拦截此事件不让其他插件执行
        }
        [DllExport(ExportName = "EventGroupMemberDecrease", CallingConvention = CallingConvention.StdCall)]
        public static int EventGroupMemberDecrease(string robot_wxid, string from_wxid, string from_name, string Msg_json) //群成员减少事件
        {
            /*
           robot_wxid  机器人帐号ID
           from_wxid   来源群ID
           from_name   来源群昵称
           Msg    退出人id|退出人昵称
          */

            return 0;// 返回0 下个插件继续处理该事件，返回1 拦截此事件不让其他插件执行
        }
        [DllExport(ExportName = "EventSysMsg", CallingConvention = CallingConvention.StdCall)]
        public static int EventSysMsg(string robot_wxid, int type, string Msg_json) //系统消息事件
        {
            /*
          robot_wxid  机器人帐号ID
         
          Msg_json   {"type","1"} 1 已经不是好友，2已经被对方拉黑
           */
            return 0;// 返回0 下个插件继续处理该事件，返回1 拦截此事件不让其他插件执行
        }
        #endregion
        #region WinForm
        [DllExport(ExportName = "Menu", CallingConvention = CallingConvention.StdCall)]
        public static int Menu()//打开设置窗体触发
        {

            spin100 form = new spin100();
            DialogResult dr = form.ShowDialog();
           
            return 0;
        }
        #endregion 
        /*
         返回 0 继续执行下一个插件的事件
         返回 1 执行完当前插件，不再执行下一个插件了

         消息类型：
         1  文本
         3 图片
         34 语音
         37 好友验证
         42 名片
         43 视频
         47 动画表情
         48 位置
         49 链接
        2000 转账
        2001  红包
        2002 小程序
        2003 群邀请
        2004 文件
        10000 系统消息 
        10002 服务通知 
         */
    }

}
