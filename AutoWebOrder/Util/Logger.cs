using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using log4net;
using log4net.Config;
using log4net.Appender;
using log4net.Layout;
using log4net.Repository;
using log4net.Repository.Hierarchy;

namespace AutoWebOrder.Util
{
    public class Logger
    {
        private ILoggerRepository m_repository = null;
        private RollingFileAppender m_rollingAppender = null;
        private ILog m_logger = null;

        public Logger()
        {
            // 로그 매니져 설정
            m_repository = LogManager.GetRepository();
            m_repository.Configured = true;

            // 로그가 위치할 폴더 설정
            string dirExe = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\\"));
            string dirLog = dirExe + "\\Log";
            if (!System.IO.Directory.Exists(dirLog)) {
                System.IO.Directory.CreateDirectory(dirLog);
            }
            

            // 파일 로그
            m_rollingAppender = new RollingFileAppender();
            m_rollingAppender.Name = "File";
            m_rollingAppender.AppendToFile = true;
            m_rollingAppender.DatePattern = "yyyy-MM-dd'.log'";
            m_rollingAppender.File = @dirLog+"\\";
            m_rollingAppender.StaticLogFileName = false;

            // 파일 단위는 날짜 단위인 것인가, 파일 사이즈인가?
            m_rollingAppender.RollingStyle = RollingFileAppender.RollingMode.Date;
            m_rollingAppender.Layout = new PatternLayout("%d [%t] %-5p %c - %m%n");

            var hierarchy = (Hierarchy)m_repository;
            hierarchy.Root.AddAppender(m_rollingAppender);
            m_rollingAppender.ActivateOptions();

            // 로그 출력 설정 All 이면 모든 설정이 되고 Info 이면 최하 레벨 Info 위가 설정됩니다.
            hierarchy.Root.Level = log4net.Core.Level.All;
            m_logger = LogManager.GetLogger(this.GetType());
        }
        

        public void OutputDebug(string msg)
        {            
            m_logger.Debug(msg);
        }

        public void OutputInfo(string msg)
        {            
            m_logger.Info(msg);
        }

        public void OutputError(string code, string msg)
        {            
            m_logger.Error("\r\n" + code + "\r\n   " + msg);
        }

    }
}
