using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Log : ILog
    {
        readonly static string _filePath = "..\\..\\..\\log.txt";
        TextWriter _writer = new StreamWriter(_filePath, true);
        ArrayList _list = new ArrayList();
        DateTime _time;
        static IBallsManager _ballsManager;

        public Log(IBallsManager ballsManager)
        {
            _ballsManager = ballsManager;
        }

        public DateTime Time {
            get => _time; set => _time = value;
        }

        public string GetData()
        {
            string data;

            data = Time.ToString() + '\n';
            if (_ballsManager != null)
            {
                for (int i = 0; i < _ballsManager.GetBallsCount(); i++)
                {
                    data +=  i + ":   " + _ballsManager.GetBall(i).X + "    " + _ballsManager.GetBall(i).Y + '\n';
                }
                
            }

            data += "\n\n";

            return data;
        }


        public void ClearLog()
        {
            _writer.Close();
            lock(this)
            {
                File.WriteAllText(_filePath, String.Empty);
            }
            _writer = new StreamWriter(_filePath, true);
        }

        public void WriteLog(DateTime dateTime)
        {
            _time = dateTime;
            if (Monitor.TryEnter(this))
            {
                for (int i = 0; i < _list.Count; i++)
                {
                    _writer.Write(_list[i]);
                }
                _list.Clear();
                _writer.Write(this.GetData());
                _writer.Flush();
                Monitor.Exit(this);
            } else
            {
                _list.Add(GetData());
            }
        }

    }
}
