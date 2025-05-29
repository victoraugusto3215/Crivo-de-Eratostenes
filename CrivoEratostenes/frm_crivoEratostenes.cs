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
            ltx_resultado.Items.Clear(); //limpa a exibi��o do passo a passo
            dtg_listaNum.Rows.Clear(); //apaga todas as linhas da tabela

            int numero = int.Parse(txt_num.Text); //valor informado pelo usu�rio
            string resultado = ""; //vari�vel para armazenar o resultado final exibido no passo a passo
            string numRemoveidos; //armazenar� os n�meros eliminados
            List<int> lista = new List<int>(); //lista contendo todos os n�meros inteiros de 2 at� n-1

            int colunaAtual = 0; //posi��o atual da coluna na tabela
            int linhaAtual = 0; //posi��o atual da linha na tabela
            int linhasNecessarias = (int)Math.Ceiling((decimal)(numero - 1) / 10); //calcula quantas linhas s�o necess�rias para exibir os n�meros

            if (numero > 2)
            {
                for (int l = 0; l < linhasNecessarias; l++)
                    dtg_listaNum.Rows.Add(); //insere as linhas na tabela

                for (int i = 2; i < numero; i++) //popula a lista com os n�meros entre 2 e n-1
                {
                    lista.Add(i); //insere o n�mero na lista

                    dtg_listaNum.Rows[linhaAtual].Cells[colunaAtual].Value = i.ToString(); //insere o n�mero correspondente na c�lula da tabela
                    colunaAtual++; //avan�a para a pr�xima coluna

                    if (colunaAtual == 10) //ao chegar ao fim da linha (coluna 10), reinicia na primeira coluna da linha seguinte
                    {
                        colunaAtual = 0;
                        linhaAtual++;
                    }
                }

                int maiorNumVer = (int)Math.Sqrt(numero); //define o maior n�mero a ser verificado (raiz quadrada de n, arredondada para baixo)
                ltx_resultado.Items.Add($"Removendo da lista os m�ltiplos de cada primo menor que {maiorNumVer}."); //exibe no passo a passo qual o limite das verifica��es

                for (int i = 2; i <= maiorNumVer; i++) //para cada primo at� a raiz de n, remove seus m�ltiplos da lista (exceto ele mesmo)
                {
                    ltx_resultado.Items.Add($"Removendo os m�ltiplos de {i}: "); //exibe no passo a passo qual n�mero est� sendo usado como base para remo��o
                    numRemoveidos = ""; //reinicia a string de n�meros removidos para exibi��o
                    for (int j = i + i; j < numero; j += i) //percorre os m�ltiplos de i, come�ando por 2*i
                    {
                        if (lista.Contains(j)) //verifica se o m�ltiplo est� na lista e o remove se estiver
                        {
                            if (numRemoveidos.Length == 0) //se for o primeiro da lista, apenas adiciona o n�mero
                                numRemoveidos += $"{j}";
                            else //caso contr�rio, adiciona v�rgula antes do n�mero
                                numRemoveidos += $", {j}";

                            lista.Remove(j); //remove o n�mero da lista
                        }
                    }
                    if (numRemoveidos.Length == 0) //se nenhum n�mero foi eliminado, remove a linha anterior do passo a passo
                        ltx_resultado.Items.RemoveAt(ltx_resultado.Items.Count - 1);
                    else
                        ltx_resultado.Items.Add(numRemoveidos); //se houverem exclus�es, exibe os n�meros eliminados
                }

                ltx_resultado.Items.Add($"Os n�meros restantes da lista s�o os primos menores que {numero}."); //mensagem final antes do resultado
                ltx_resultado.Items.Add("Resultado:"); //marca o in�cio da exibi��o do resultado

                foreach (int i in lista)
                {
                    resultado += $"{i}, "; //concatena os n�meros restantes na string resultado
                    foreach (DataGridViewRow row in dtg_listaNum.Rows) //varre as c�lulas da tabela para real�ar os n�meros restantes
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (row.Cells[j].Value != null && row.Cells[j].Value.ToString() == i.ToString())
                                row.Cells[j].Style.BackColor = Color.Purple; //destaca os n�meros primos na tabela
                        }
                    }
                }

                resultado = resultado.TrimEnd(',', ' '); //remove a v�rgula e o espa�o final da string resultado
                ltx_resultado.Items.Add(resultado); //exibe o resultado na lista de passos
                //txt_resultado.Text = resultado; //exibe o resultado na caixa de texto
            }
            else
            {
                ltx_resultado.Items.Add("N�o h� n�meros primos menores que 2."); //mensagem caso o valor informado seja menor ou igual a 2
            }
        }

        private void dtg_listaNum_SelectionChanged(object sender, EventArgs e)
        {
            dtg_listaNum.ClearSelection(); //remove qualquer sele��o feita na tabela
        }

        private void txt_num_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lbl_num_Click(object sender, EventArgs e)
        {

        }
    }
}
