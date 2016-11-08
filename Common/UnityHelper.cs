using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class UnityHelper
    {
        public static IUnityContainer Instance
        {
            get
            {
                IUnityContainer container = new UnityContainer();
                string configFile = AppDomain.CurrentDomain.BaseDirectory + "unity.config";
                var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = configFile };
                //从config文件中读取配置信息
                Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                //获取指定名称的配置节
                UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection("unity");
                //载入名称为FirstClass 的container节点
                container.LoadConfiguration(section, "MyContainer");
                return container;

            }
        }
    }
}
