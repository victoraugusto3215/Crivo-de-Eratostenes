# 🧮 Crivo de Eratóstenes

Projeto acadêmico em **C#** utilizando **Windows Forms**, desenvolvido na disciplina de **Matemática Discreta**, do **6º período** do curso de **Sistemas de Informação** da **Faculdade Cotemig**, sob orientação do professor **Vângelis Oliveira Sagnori Bernardes**.

## 📌 Descrição

Este programa implementa o **Crivo de Eratóstenes**, um algoritmo clássico e eficiente para encontrar todos os **números primos** até um determinado número `n` informado pelo usuário.

O algoritmo elimina múltiplos de cada número primo, preservando apenas os primos reais na sequência.

## ✅ Funcionalidades

- Entrada do número limite `n`;
- Exibição de todos os **números primos ≤ n**;
- Visualização clara e interativa do **passo a passo da eliminação dos múltiplos**;
- Tratamento de entradas inválidas com mensagens de erro amigáveis.

## 🧾 Exemplo de uso

Entrada:
n = 30

Saída (passo a passo):
Iniciando com: 

2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30

Eliminando múltiplos de 2: 2 3 X 5 X 7 X 9 X 11 X 13 X 15 X 17 X 19 X 21 X 23 X 25 X 27 X 29 X

Eliminando múltiplos de 3: 2 3 X 5 X 7 X X X 11 X 13 X X X 17 X 19 X X X 23 X 25 X X X 29 X

Eliminando múltiplos de 5: (nenhuma mudança, múltiplos já eliminados)
...
Resultado final:
Números primos até 30:
2, 3, 5, 7, 11, 13, 17, 19, 23, 29


## ⚙️ Tecnologias Utilizadas

- **C#**
- **.NET Windows Forms**

## 🎯 Objetivo

Compreender e aplicar o algoritmo do **Crivo de Eratóstenes** na prática, reforçando o entendimento de conceitos fundamentais de **números primos**, **eficiência algorítmica**, e **visualização de processos matemáticos**, no contexto da disciplina de Matemática Discreta.
