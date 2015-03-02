using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CodeGenerator.Common
{
    public class ConfigOut
    {
        public static string OutPutDirectory
        {
            get
            {
                return ConfigurationManager.AppSettings["OutputDir"];
            }
        }

        public static string Partial
        {
            get
            {
                return ConfigurationManager.AppSettings["Partial"];
            }
        }
        public static string PropertyEvents
        {
            get
            {
                return ConfigurationManager.AppSettings["PropertyEvents"];
            }
        }
        public static string Validation
        {
            get
            {
                return ConfigurationManager.AppSettings["Validation"];
            }
        }

        public static string ConfigBase
        {
            get
            {
                return ConfigurationManager.AppSettings["Database"];
            }
        }

        public static string NameSpace
        {

            get
            {
                return ConfigurationManager.AppSettings["NameSpace"];
            }
        }
        public static string ConnectString
        {
            get
            {
                return ConfigurationManager.AppSettings["ConnectionString"];
            }
        }
    }
}
