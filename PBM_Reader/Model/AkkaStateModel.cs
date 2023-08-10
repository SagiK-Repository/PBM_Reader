using DevExpress.Mvvm.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBM_Reader.Model
{
    public class AkkaStateModel
    {
        public string ID { get; set; }
        public string IP
        {
            get
            {
                if (ID.IsEmptyOrSingle())
                    return "";

                return ID.Substring(ID.IndexOf("@") + 1);
            }
        }
        public string Name { get; set; }
        public string Status { get; set; }
        public string DeStatus { get; set; }
        public string Version { get; set; }

        public AkkaStateModel(List<string> input)
        {
            if (input == null || input.Count() < 5)
                return;
            
            ID = input[0];
            Name = input[1];
            Status = input[2];
            DeStatus = input[3];
            Version = input[4];
        }
    }
}
