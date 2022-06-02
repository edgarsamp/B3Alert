# stock-quote-alert
O objetivo do sistema é avisar, via e-mail, caso a cotação de um ativo da B3 caia mais do que certo nível, ou suba acima de outro.

O programa é uma aplicação de console (sem interface gráfica).

Ele é chamado via linha de comando com 3 parâmetros.
```
  1. O ativo a ser monitorado
  2. O preço de referência para venda
  3. O preço de referência para compra
```

Ex.
```
> stock-quote-alert.exe PETR4 22.67 22.59 
```

Antes da chamada do programa o usuario deve configurar um arquivo de configuração com:

O e-mail de destino dos alertas
As configurações de acesso ao servidor de SMTP que irá enviar o e-mail
As configurações do relatório final caso deseje


A API de cotação utilizada foi a <a href="https://brapi.ga/">brapi</a>.

O programa fica continuamente monitorando a cotação do ativo enquanto estiver rodando.



Em outras palavras, dada a cotação de PETR4 abaixo.

<img src="cotacaoPETR4.JPG">

Toda vez que o preço for maior que linha-azul, um e-mail deve ser disparado aconselhando a venda.
Toda vez que o preço for menor que linha-vermelha, um e-mail deve ser disparado aconselhando a compra.

