using Flagging.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flagging
{
    internal class FlaggedItemRow
    {
        public string ItemType { get; set; }
        public string ItemDescription { get; set; }
        public int ItemId { get; set; }
        public int FlagCounts { get; set; }
        public DateTime DateLastFlagged { get; set; }
    }
}
