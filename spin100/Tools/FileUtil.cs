using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace spin100_Keaimao_SDK
{
    class FileUtil
    {
        /// <summary>
        /// 从资源文件Application中抽取资源文件
        /// </summary>
        /// <param name="resFileName">资源文件名称（资源文件名称必须包含目录，目录间用“.”隔开,最外层是项目默认命名空间）</param>
        /// <param name="outputFile">输出文件</param>
        public static void ExtractResFile(string resFileName, string outputFile)
        {
            BufferedStream inStream = null;
            FileStream outStream = null;
            try
            {
                Assembly asm = Assembly.GetExecutingAssembly(); //读取嵌入式资源
                inStream = new BufferedStream(asm.GetManifestResourceStream(resFileName));
                outStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write);

                byte[] buffer = new byte[1024];
                int length;

                while ((length = inStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    outStream.Write(buffer, 0, length);
                }
                outStream.Flush();
            }
            finally
            {
                if (outStream != null)
                {
                    outStream.Close();
                }
                if (inStream != null)
                {
                    inStream.Close();
                }
            }
        }
        /// <summary>
        /// 检测根目录下是否有需要引用的资源文件，没有就释放到根目录
        /// </summary>
        public static void Filexists()
        {
            if (File.Exists(@".\Newtonsoft.Json.dll"))//判断数据库是否存在
            {
               

            }
            else
            {
                //从资源文件夹Application中抽取需要释放的dll等资源文件
                ExtractResFile("spin100_IR_SDK.Application.Newtonsoft.Json.dll", @".\Newtonsoft.Json.dll");
            }

        }
    }
}
