using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseManagerUI.Models
{
    internal class GeneralResponse
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }

        public GeneralResponse(bool isSuccessful, string msg)
        {
            IsSuccessful = isSuccessful;
            Message = msg;
        }

        public GeneralResponse(bool isSuccessful)
        {
            IsSuccessful = isSuccessful;
        }


    }
}
