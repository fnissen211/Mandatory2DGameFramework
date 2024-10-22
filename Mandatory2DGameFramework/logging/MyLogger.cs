using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.logging
{
    public class MyLogger
    {
        private MyLogger()
        {
            
        }

        private static MyLogger _instance;
        public static MyLogger Instance { 
            get 
            { 
                if (_instance == null)
                {
                    _instance = new MyLogger();
                }
                return _instance;
            } 
        }

        
    }
}
