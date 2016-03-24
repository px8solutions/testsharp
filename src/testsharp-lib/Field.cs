using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testsharp.lib
{
    class Field
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int W { get; set; }
        public int H { get; set; }
        public int ResponseId { get; set; }
        public int LayoutId { get; set; }
        public enum FieldTypes
        {
            Boxes,
            Dropdown
        }
    }
}
