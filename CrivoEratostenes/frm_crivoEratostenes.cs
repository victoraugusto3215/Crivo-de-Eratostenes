using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

namespace CrivoEratostenes
{
    public partial class frm_crivoEratostenes : Form
    {
        public frm_crivoEratostenes()
        {
            InitializeComponent();
        }

        private void btn_calcular_Click(object sender, EventArgs e)
        {
            ltx_resultado.Items.Clear(); //limpa a exibição do passo a passo
            dtg_listaNum.Rows.Clear(); //apaga todas as linhas da tabela

            int numero = int.Parse(txt_num.Text); //valor informado pelo usuário
            string resultado = ""; //variável para armazenar o resultado final exibido no passo a passo
            string numRemoveidos; //armazenará os números eliminados
            List<int> lista = new List<int>(); //lista contendo todos os números inteiros de 2 até n-1

            int colunaAtual = 0; //posição atual da coluna na tabela
            int linhaAtual = 0; //posição atual da linha na tabela
            int linhasNecessarias = (int)Math.Ceiling((decimal)(numero - 1) / 10); //calcula quantas linhas são necessárias para exibir os números

            if (numero > 2)
            {
                for (int l = 0; l < linhasNecessarias; l++)
                    dtg_listaNum.Rows.Add(); //insere as linhas na tabela

                for (int i = 2; i < numero; i++) //popula a lista com os números entre 2 e n-1
                {
                    lista.Add(i); //insere o número na lista

                    dtg_listaNum.Rows[linhaAtual].Cells[colunaAtual].Value = i.ToString(); //insere o número correspondente na célula da tabela
                    colunaAtual++; //avança para a próxima coluna

                    if (colunaAtual == 10) //ao chegar ao fim da linha (coluna 10), reinicia na primeira coluna da linha seguinte
                    {
                        colunaAtual = 0;
                        linhaAtual++;
                    }
                }

                int maiorNumVer = (int)Math.Sqrt(numero); //define o maior número a ser verificado (raiz quadrada de n, arredondada para baixo)
                ltx_resultado.Items.Add($"Removendo da lista os múltiplos de cada primo menor que {maiorNumVer}."); //exibe no passo a passo qual o limite das verificações

                for (int i = 2; i <= maiorNumVer; i++) //para cada primo até a raiz de n, remove seus múltiplos da lista (exceto ele mesmo)
                {
                    ltx_resultado.Items.Add($"Removendo os múltiplos de {i}: "); //exibe no passo a passo qual número está sendo usado como base para remoção
                    numRemoveidos = ""; //reinicia a string de números removidos para exibição
                    for (int j = i + i; j < numero; j += i) //percorre os múltiplos de i, começando por 2*i
                    {
                        if (lista.Contains(j)) //verifica se o múltiplo está na lista e o remove se estiver
                        {
                            if (numRemoveidos.Length == 0) //se for o primeiro da lista, apenas adiciona o número
                                numRemoveidos += $"{j}";
                            else //caso contrário, adiciona vírgula antes do número
                                numRemoveidos += $", {j}";

                            lista.Remove(j); //remove o número da lista
                        }
                    }
                    if (numRemoveidos.Length == 0) //se nenhum número foi eliminado, remove a linha anterior do passo a passo
                        ltx_resultado.Items.RemoveAt(ltx_resultado.Items.Count - 1);
                    else
                        ltx_resultado.Items.Add(numRemoveidos); //se houverem exclusões, exibe os números eliminados
                }

                ltx_resultado.Items.Add($"Os números restantes da lista são os primos menores que {numero}."); //mensagem final antes do resultado
                ltx_resultado.Items.Add("Resultado:"); //marca o início da exibição do resultado

                foreach (int i in lista)
                {
                    resultado += $"{i}, "; //concatena os números restantes na string resultado
                    foreach (DataGridViewRow row in dtg_listaNum.Rows) //varre as células da tabela para realçar os números restantes
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (row.Cells[j].Value != null && row.Cells[j].Value.ToString() == i.ToString())
                                row.Cells[j].Style.BackColor = Color.Purple; //destaca os números primos na tabela
                        }
                    }
                }

                resultado = resultado.TrimEnd(',', ' '); //remove a vírgula e o espaço final da string resultado
                ltx_resultado.Items.Add(resultado); //exibe o resultado na lista de passos
                //txt_resultado.Text = resultado; //exibe o resultado na caixa de texto
            }
            else
            {
                ltx_resultado.Items.Add("Não há números primos menores que 2."); //mensagem caso o valor informado seja menor ou igual a 2
            }
        }

        private void dtg_listaNum_SelectionChanged(object sender, EventArgs e)
        {
            dtg_listaNum.ClearSelection(); //remove qualquer seleção feita na tabela
        }

        private void txt_num_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lbl_num_Click(object sender, EventArgs e)
        {

        }
    }
}
