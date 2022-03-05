﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducaoCosmeticos
{
    internal class Producao
    {
        #region Propriedades da Produção

        public int id { get; set; }
        public DateTime dproducao { get; set; }
        public string produto { get; set; }
        public float qtd { get; set; }

        #endregion

        #region Construtor

        public Producao(int id, DateTime dproducao, string produto, float qtd)
        {
            this.id = id;
            this.dproducao = dproducao;
            this.produto = produto;
            this.qtd = qtd;
        }

        #endregion

        #region Métodos



        #endregion

    }
}
