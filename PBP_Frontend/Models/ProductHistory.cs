using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pfcWeb.Models
{
    public class ProductHistory
    {
        public int Id { get; set; }
        public int ListId { get; set; }
        public int ProductId { get; set; }
        public int qtdGet;
        public int qtdSet;

        public bool setQtdSet(int qtdSet)
        {
            if (qtdSet > 0) {
                this.qtdSet = qtdSet;
                return true;
            }
            return false;
        }

        public int getQtdSet() {
            return this.qtdSet;
        }

        public bool setQtdGet(int qtdGet)
        {
            if (qtdGet > 0)
            {
                this.qtdGet = qtdGet;
                return true;
            }
            return false;
        }

        public int getQtdGet()
        {
            return this.qtdGet;
        }
    }
}