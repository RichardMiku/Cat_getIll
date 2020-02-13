using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace spin100_Keaimao_SDK
{
    public class Fileini
    {
        //插件所需要的配置文件路径名字
        public static string path = @".\config\spin100.ini";
        [DllImport("kernel32")] // 写入配置文件的接口 
        private static extern long WritePrivateProfileString(
       string section, string key, string val, string filePath);

        [DllImport("kernel32")] // 读取配置文件的接口 
        private static extern int GetPrivateProfileString(
        string section, string key, string def,
        StringBuilder retVal, int size, string filePath);


        /// <summary>
        /// 向配置文件写入值 
        /// </summary>
        /// <param name="section">配置节点名称</param>
        /// <param name="key">节点名</param>
        /// <param name="value">节点值</param>
      
        public void WriteValue(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, path);
        }

        /// <summary>
        /// 读取配置值
        /// </summary>
        /// <param name="section">读取配置点名称</param>
        /// <param name="key">读取指定节点名</param>
        /// <returns></returns>
        public string ReadValue(string section, string key)
        {
            StringBuilder sb = new StringBuilder(1024);
            GetPrivateProfileString(section, key, "", sb, 1024, path);
            return sb.ToString().Trim();
        }
        /// <summary>
        /// 向配置文件写入值 这个动态指定路径名称
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="path">配置文件路径</param>
        public void WriteValuepath(string section, string key, string value,string path)
        {
            WritePrivateProfileString(section, key, value, path);
        }
        /// <summary>
        /// 读取配置值 这个动态指定路径名称
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="path">配置文件路径</param>
        /// <returns></returns>
        public string ReadValuepath(string section, string key,string path)
        {
            StringBuilder sb = new StringBuilder(1024);
            GetPrivateProfileString(section, key, "", sb, 1024, path);
            return sb.ToString().Trim();
        }
    }
}
