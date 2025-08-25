using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastechTest
{
    public class CSystem
    {
        public EventHandler<EventArgs> EventChangedMode;

        public enum MODE
        { NO_LICENSE, READY, AUTO, ALARM, SIMULATION };

        private MODE m_eModePrev = MODE.READY;
        private MODE m_eMode = MODE.READY;

        public MODE Mode
        {
            get { return m_eMode; }
            set
            {
                if (m_eModePrev != value)
                {
                    if (EventChangedMode != null)
                    {
                        EventChangedMode(this, new EventArgs());
                    }

                }
                m_eModePrev = m_eMode;
                m_eMode = value;
            }
        }
    }
}
