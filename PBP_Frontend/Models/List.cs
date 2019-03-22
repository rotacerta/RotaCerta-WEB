using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pfcWeb.Models
{
    public class List
    {

        [Key] public int Id { get; set; }
        public string Name;
        public string Requester;

        public bool setName(string name) {
            if (name != null) {
                bool resultSizeVarString = verifySizeVarString(name);
                if (resultSizeVarString)
                {
                    this.Name = name;
                    return true;
                }
            }
            return false;
        }

        public string getName()
        {
            return this.Name;
        }

        public bool setRequester(string requester)
        {
            if(requester != null) {
                bool resultSizeVarString = verifySizeVarString(requester);
                if (resultSizeVarString)
                {
                    this.Requester = requester;
                    return true;
                }
            }
            return false;
        }

        public string getRequest()
        {
            return this.Requester;
        }

        private static bool verifySizeVarString(string varString)
        {
            if (varString.Length > 0 && varString.Length <= 50) {
                return true;
            }
            return false;
        }
    }
}