using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAssetsMVC1.Models
{
    public class Office
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public string Rate { get; set; }
        public List<Asset> Assets { get; set; }
    }
}
