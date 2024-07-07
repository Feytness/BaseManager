using BaseManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseManagerUI.Models
{
    internal class Worker
    {
        public int Id { get; set; }
        public Building Assignment { get; set; }
    }
}
