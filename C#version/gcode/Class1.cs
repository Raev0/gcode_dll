using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;

namespace threeDPrinter
{
    public class gcode
    {
        public class movetype
        {
            public Single xdest = 0;
            public Single ydest = 0;
            public Single zdest = 0;
            public Single edest = 0;
            public UInt16 feedrate = 0;
        }
        public class linetype
        {
            public UInt16 x = 0;
            public UInt16 y = 0;
        }
        private List<movetype> _moves = new List<movetype>();

        private List<String> _codeList = new List<string>();

        public gcode(String fileFullPath = "D://demo//demo.gcode")
        {
            StreamReader mySr = new StreamReader(fileFullPath, Encoding.Default);
            String _line;
            while ((_line = mySr.ReadLine()) != null)
            {
                _codeList.Add(_line);
            }
        }
        private static Single _curZ = 0;
        private void _parseGcode(List<string> gCodeLines)
        {
            Regex g1reg = new Regex("G1.*");
            movetype _curmove = new movetype();
            foreach (string line in gCodeLines)
            {
                if (line.StartsWith("G1") || line.StartsWith("G0"))
                {
                    string line_s = line + " ";
                    //movetype move = new movetype();
                    //move = _curmove;
                    if (line_s.Contains("X"))
                    {
                        _curmove.xdest = Convert.ToSingle(line_s.Substring(line.IndexOf("X") + 1, line_s.Remove(0, line.IndexOf("X")).IndexOf(" ")));
                    }
                    if (line_s.Contains("Y"))
                    {
                        _curmove.ydest = Convert.ToSingle(line_s.Substring(line.IndexOf("Y") + 1, line_s.Remove(0, line.IndexOf("Y")).IndexOf(" ")));
                    }
                    if (line_s.Contains("E"))
                    {
                        _curmove.edest = Convert.ToSingle(line_s.Substring(line.IndexOf("E") + 1, line_s.Remove(0, line.IndexOf("E")).IndexOf(" ")));
                    }
                    if (line_s.Contains("Z"))
                    {
                        _curmove.zdest = Convert.ToSingle(line_s.Substring(line.IndexOf("Z") + 1, line_s.Remove(0, line.IndexOf("Z")).IndexOf(" ")));
                    }
                    if (line_s.Contains("F"))
                    {
                        _curmove.feedrate = Convert.ToUInt16(line_s.Substring(line.IndexOf("F") + 1, line_s.Remove(0, line.IndexOf("F")).IndexOf(" ")));
                    }
                    _moves.Add(new movetype
                    {
                        xdest = _curmove.xdest,
                        ydest = _curmove.ydest,
                        zdest = _curmove.zdest,
                        feedrate = _curmove.feedrate,
                        edest = _curmove.edest,
                    });
                }
            }
            //Raevo: I belease re should be a selection;
            //Regex g1reg=new Regex("[G1]/s+X(?<XPOS>/d).+Y(?<YPOS>/d).+(Z(?<ZPOS>/d))*.+E(?<ZPOS>/d)");
            //Regex g0reg=new Regex("dfdfd");
            //List<movetype> moves=
            //var move = from line in File.ReadLines(filename)
            //           where g1reg.IsMatch(line)
            //           select 
            //           {
            //               x = g1reg.Match(line).Groups["XPOS"].Value,
            //               y = g1reg.Match(line).Groups["YPOS"].Value,
            //               z = g1reg.Match(line).Groups["ZPOS"].Value,
            //               // anonymous variable
            //           };
            //foreach (var f in lines)
            //{
            //    //re here
            //}
        }
        private List<linetype> drawView(int linenum)
        {
            return new List<linetype>();
        }
        public Image updateView(int linenum)
        {
            Image foo = null;
            return foo;
        }
        public void layerConvert(string destFilePath)
        {
            string[] aGcodeSnippet = null;
            StreamWriter mySr = new StreamWriter(destFilePath);
            mySr.Write("txt", aGcodeSnippet);
            mySr.Close();
        }
        public string[] layerConvert()
        {
            string[] aGcodeSnippet = null;
            return aGcodeSnippet;
        }
        public List<String> gcodeExport()
        {
            return _codeList;
        }
        public List<String> debugging()
        {
            List<String> xyzCoordinate = new List<string>();
            _parseGcode(_codeList);
            foreach (movetype m in _moves)
            {
                xyzCoordinate.Add(
                    "X:" + m.xdest.ToString() +
                    "    Y:" + m.ydest.ToString() +
                    "    Z:" + m.zdest.ToString() +
                    "    E:" + m.edest.ToString()
                );
            }
            return xyzCoordinate;
        }
    }
}
