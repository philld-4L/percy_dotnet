using System;
using System.Collections.Generic;
using System.Text;

namespace Percy.Webdriver
{
    public class SnapshotProperties
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int[] Widths { get; set; }
        public int MinHeight { get; set; }
        public bool EnableJavascript { get; set; } = false;
        public string PercyCSS { get; set; }
    }
}
