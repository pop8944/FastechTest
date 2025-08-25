using IntelligentFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastechTest
{
    public class Global
    {
        static readonly object padlock = new object();
        static Global m_Instance = null;
        public static Global Instance
        {
            get
            {
                lock (padlock)
                {
                    return m_Instance;
                }
            }
        }
        private IDevice m_iDevice = null;

        public IDevice Device
        {
            get => m_iDevice;
            set => m_iDevice = value;
        }

        private CSystem m_iSystem = null;

        public CSystem System
        {
            get { return m_iSystem; }
            set { m_iSystem = value; }
        }

        public Global()
        {
            m_Instance = this;
            m_iDevice = new IDevice();
            m_iSystem = new CSystem();
            SeqAuto = new CSeqAuto();
        }
        public CSeqAuto SeqAuto = null;

        public void Init()
        {
            m_iDevice.Init();
        }

    }
}
