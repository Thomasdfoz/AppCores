using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCores_1._0
{
    public class cliente
    {
        private string nome, cor, tamanho, basetinta, tipo, qualidade, quantidade, preco, observacao, data;

        public cliente(string[] txtObrg,string quant, string p, string o)
        {
            nome = txtObrg[0];
            this.cor = txtObrg[1]; 
            tamanho = txtObrg[2];
            basetinta = txtObrg[3];
            this.tipo = txtObrg[4];
            qualidade = txtObrg[5];
            quantidade = quant;
            preco = p;
            observacao = o;
            this.data = txtObrg[6]+"-" + txtObrg[7] +"-"+ txtObrg[8];
        }
        public override string ToString()
        {
            return "'" + nome + "', '" + cor + "', '" + tamanho + "', '" + basetinta + "','" + tipo + "', '" + qualidade + "','" +quantidade+ "', '" + preco+ "', '" + observacao+ "','"+data+"'";
                
        }

    }
}
