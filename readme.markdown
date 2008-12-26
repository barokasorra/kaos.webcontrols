KAOS.WebControls
===
* luis@planobe.com.br
* jean@planobe.com.br

Biblioteca de controles para asp.net feito em C# e JavaScript. Release inicial em 11/03/2005. 
Testado no framework 1.1. Desenvolvido no VS 2002, e VS 2003.
Compatibilidade com o ASP.NET 2.0 (n�o testado completamente).

Controles disponiveis e recomenda��es

* Todos os controles da s�rie Edit possuem uma propriedade chamada AutoTab, que quando true, pula automaticamente para o pr�ximo campo, quando atingir o MaxLength do Edit.
* Todos os controles da s�rie Edit possuem uma propriedade chamada ReadWrite que quando setada para false 
"transforma" o textbox em um label. Todos possuem valida��o de RequiredFieldValidator e RangeValidator tbm, 
n�o necessitando mais a utiliza��o de validators em sua p�gina.
* (*noFirefox) N�o compativel com Firefox.

ContentBar - componente html que � uma barra horizontal 100 % no topo da p�gina com um menu a direita da tela que pode ser contraido ou expandido. Este menu na verdade � um Iframe, onde mostramos o conte�do de outras p�ginas. O compomente possui a propriedade Src que � a url que desejamos abrir em nosso menu, Description que � a descri��o que vai aparecer no centro da barra horizontal, outras propriedades referentes a caminho de icones que aparecer�o alinhados a esquerda da barra horizontal, ClassTable que � o nome do estilo que ser� aplicada a barra horizontal, Contracted que permite especificarmos se o menu do lado direito aparecer� contraido ou n�o e TextLinkNews que � o texto que aparecer� em cima do menu do lado direito. Quando as propriedades referentes a caminho estiverem vazia os icones n�o aparecer�o. A pasta ContentBar cont�m um estilo para a formata��o da barra horizontal, e imagens recomendadas para sua utiliza��o. Alguns estilos contidos na folha de estilo encontrada nesta pasta s�o integrados com o componente e s�o obrigat�rios para sua correta vizualiza��o.

MaskedEdit - editbox que tem as mesmas fun��es de valida��o dos outros Edit* , e permite especificar uma m�scara de entrada de dados. Ex.: Mascara = @@-##. O usu�rio s� poder� digitar letras e n�meros contando que esteja de acordo com a m�scara. Qualquer caracteres que forem diferentes de @ e # na especificac�o da m�scara aparecer�o automaticamente conforme o usu�rio digitar. 

DataGridGrouped - grid, que permite especificarmos que colunas ser�o a quebra de nivel. Permite especificarmos quantos niveis forem necess�rios. Devemos utilizar a propriedade IndexesColumn para isso, onde colocaremos os valores dos indexes separados por virgula. Ex: 1,2,3. Respectivamente setamos a propriedade CssClassNiveis onde devemos obrigatoriamente especificar o nome do estilo que queremos utilizar na linha de quebra. N�o devemos utilizar 0 como index, pois a identa��o n�o funcionar� corretamente.

SmartNavigation - controle quer permite manter a posicao da p�gina mesmo depois do postback. Funciona tanto em IE como Firefox. Para utilizarmos basta arrastarmos para a p�gina.

ComboPopUp - combo quer permite especificarmos seu �ltimo item. Quando o usu�rio clicar neste item abrir� uma janela no modal. Ao fecharmos esta janela o usu�rio pode voltar um valor que aparecer� no primeiro item do como. Possui a fun��o ListaMoficada() que permite pegarmos o conte�do modificado do combo, depois que o valor � retornado. Deve ser utilizado em conjunto com o ModalLink. (*noFirefox)

ImageHighLighting - image que possui um efeito de HighLighting. Permite escolhermos a dura��o do efeito de 0 a 100. (*noFirefox)

ImagePopUp - possui a propriedade HighLighting tamb�m, e ao clicarmos abrir� uma janela model com o endere�o que especificarmos e permite especificarmos o campo que ser� atualizado, quando fecharmos a janela modal. (*noFirefox)

ModalLink - link que possui uma propriedade chamada valor de retorno. Ao clicarmos nesse link a janela fechar� e retornar� um valor para a janela atr�s. Deve ser usado em conjunto com um dos controles *PopUp. (*noFirefox) 

Edit - textbox normal que permite valida��o de requerido e de range.

EditAutoComplete - editbox que ao usu�rio digitar dados aparecer� uma tabela embaixo do controle que filtra automaticamente os valores especificados na propriedade Dados. Permite especificarmos quantos items queremos na tabela filtrada e tamb�m se queremos que o controle procure por qualquer parte da string dos items, ou s� pelo come�o da palavra. Para utilizarmos este controle devemos colocar a pasta autocomplete no diret�rio de nossa aplica��o. Devemos setar corretamente a propriedade CaminhoJs do controle. Inclui valida��o de campo requerido.

EditDate - textbox que permite apenas digitar datas, fornece uma m�scara autom�tica ao digitarmos no campo. Permite 
valida��o de campo requerido e permite a tamb�m valida��o entre duas datas estipuladas.

EditDatePopUp - Igual ao EditDate com um calend�rio que vem ao lado do campo , para facilitar a inclus�o de datas. O 
calend�rio escrito em js, pode ser totalmente customizado, e as imagens e o script do mesmo, est�o nesta pasta, no 
diret�rio chamado calendar. Para utilizarmos o calend�rio devemos colocar a pasta calendar no diret�rio de nossa 
aplica��o. Devemos setar corretamente a propriedade CaminhoJs do controle.

EditMoney - textbox que permite apenas digita��o de valores no formato moeda e que inclui tbm umas m�scara autom�tica 
conformes digitamos. Valida��o de campo requerido e de valores de compara��o tbm.

EditNumber - igual ao EditMoney, com a diferen�a que � permitido apenas a digita��o de valores inteiros. Valida��o de 
campo requerido e de valores de compara��o tbm.

EditEmail - textbox com valida��o de email e campo requerido.

EditTime - textbox com valida��o de hora no formato hh:mm:ss (os segundos s�o opcionais). Valida��o de campo requerido tbm.

Label - Label quer permite especificarmos um valor de compara��o. Se o valor de compara��o for diferente do valor da 
label ela mudar� de cor. Valor de compara��o � decimal.

ExpandingButton,ExpandingCheckBox,ExpandingImagemButton,ExpandingLinkButton - S�rie de controles que permite 
esconder/mostrar panels, componentes, etc ... Todos possuem um propriedade chamada boolean Expanded, que controla a 
visibilidade do controle que definirmos em ControlToToggle. Cada um tem particularidades diferentes, mas todos tem 
o mesmo objetivo. Destaque para o ExpandingImagemButton.
Obs: utilize ExpandigControls.Expanded = true ou false para controlar a visibilidade do panel ou qualquer coisa que vc 
ir� controlar.

ExpandingRadio e ExpandingCombo - Controles que permitem esconder e mostrar divs, dependendo da op��o selecionada, no ComboBox ou no grupo de radios. Possuem uma propriedade chamada TextoItemDiv onde especificamos o controle das divs e qual condi��o.A estrutura � a seguinte: SELECTEDTEXT=DIVQUECONTROLAREMOS,SELECTEDTEXT=DIVQUECONTROLAREMOS e assim por diante,separando por virgula. Exemplo: item1=divdoitem1,item2=divdoitem2. Quando no caso do combo o selecteditemtext for igual a item1, a divdoitem1 aparecer�, e a divdoitem2 se esconder� e assim vice-versa. No caso do radio, a propriedade TextoItemDiv tem que estar igual em todos os radios do grupo. 

Hist�rico Pr� Era do Versionamento
===
17/11/2006 - Release 2.4
+ Incluido propriedade enabled (true/false) no componente smartnavigation. Isto permite habilitar ou desabilitar o smartnavigation na p�gina em tempo de execu��o. 
+ Relatado problemas na utiliza��o de RichTextBox , no controle de abas da Microsoft + smartnavigation Microsoft. Recomenda-se utilizar RichTextBox com 
smartnavigation do framework KAOS.

13/07/2006 - Release 2.3
+ ValidarClientSide e RequeridoClientSide do controle EditDatePopUp estavam como ReadOnly nao permitindo mudar em tempo de edicao. Ref: 28/12/2005

27/4/2006 - Release 2.0
+ Corrigido pequeno problema em EditMask.js , que estava engolindo o caractere digitado , e trocando pelo simbolo especificado na mascara. Agora coloca-se o simbolo da mascara, e o caractere digitado tbm.

28/12/2005
+ Modificado a propriedade ReadOnly da propriedade ValidarClientSide para false, do controle Edit.cs(linha 173). Parece que todos os controles que estao herdando desta classe, mesmo sobreescrevendo esta propriedade para ReadOnly false, nao est� permitindo a alteracao em design Time no Visual Studio.

13/12/2005
+ Havia me esquecido de colocar a tag ReadWrite = true na assinatura do componente EditDatePopUp causando erro de cast na hora de incluir o componente na ide. Isto ocorria pq o componente EditDate q estava dentro do webcontrol EditDatePopUp teve a assinatura modificada , adicionando ReadWrite

7/12/2005
+ A propriedade Alinhar do Edit estava como readonly. Alterada para property normal. Nao lembro pq estava assim ?
+ O controle Edit, estava perdendo a propriedade ReadWrite entre os postbacks. Sobreescrita a funcao LoadPostData para recuperar o valor do ReadWrite do Edit, pois o TextBox ja implementa a interface IPostBackHandler.

6/12/2005
+ Corrigido bug no EditAutoComplete que ao deixarmos a opcao ReadWrite como false ou seja nao editavel o mesmo se clicassemos em cima do campo e digitassemos alguma coisa a caixa de autocomplete aparecia. (linha 89, EditAutoComplete.cs)
+ Mudado o style do Edit quando a opcao ReadWrite esta como false ou seja o componente est� no modo label. O conte�do do Edit fica em negrito. (linha 265,267, Edit.cs)

17/11/2005
+ Modificao da Lib para compilacao. Liberado release KAOS.WebControls

07/6/2005
+ Alterado o nome da propriedade CaminhoIconeNews para CaminhoExpandedIconeNews.
+ Adicionado a propriedade CaminhoContractedIconeNews que � usada para mostrar um outro Icone quando a barra est� contra�da.

03/6/2005
+ Retirado as altera��es do dia 25/5/2005.
+ Adicionado a propriedade ShowIconeLinkNews no ContentBar para ser usando nas configura��es de seguran�a dos sistemas.

25/5/2005
+ Adicionado a propriedade position:absolute ao style do ContentBar para corrigir problemas com rela��o ao posicionamento de outros componentes na p�gina.

6/5/2005
+ Incluido os componentes ExpandingRadio e ExpandingCombo.

3/5/2005 - Release 1.0
+ Release 1.0 liberado.
+ Incluido o controle ContentBar.
+ Corrigido bug na estrutura do ContentBar que carregava o iframe com a barra a direita toda vez que o usuario entrasse na pagina mesmo com a barra contraida. O usuario n�o veria a barra, por causa do display:none mas o conte�do estaria l�, atrasando em muito o carregamento das p�ginas. Modificado para renderizar o frame inteiro e n�o s� a propriedade display:block, quando a op��o contracted = false. O jeito antigo com display:none � util ao utilizarmos js para controlar a barra do lado do cliente, mas muito demorado visto que devemos ir ao servidor para buscar noticias. 

2/5/2005
+ Corrigido bug no no javascript do RichEdit referente a design. Do lado direito o componente aparecia uma �rea em branco que ao deixarmos o width em 100% aparecia uma barra de rolagem horizontal.

21/4/2005
+ Corrigido bug quando utilizamos o RichEdit em UserControls ocorria um erro de javascript devido a diferen�a do nome do RichEdit no lado do cliente quando o mesmo est� dentro de UserControls.
+ Adicionado um script do RichEdit especifico para o CRM. Foram removidas v�rias op��es de customiza��o do texto. Basta adicionar a pasta richedit_crm no lugar da richedit se quiser o componente com menos op��es. N�o h� problema nenhum em utilizar os dois componentes ao mesmo tempo, contando que na propriedade caminhoJs cada um esteja apontado para uma pasta.

19/04/2005
+ Modificada a font default do RichEdit para Verdana. A primeira vez que o componente carrega sua fonte � Verdana. Se darmos um postback com o componente vazio, o componente apaga a tag da font e retorna a fonte original.
+ Corrigido bug referente quando existiam 2 ou mais controles RichEdit na mesma p�gina. Novamente alterado a estrutura de como disparamos a function em js que pega os valores do RichEdit do lado do cliente.

18/04/2005
+ Verificado o problema de ViewState referente ao componente RichEdit. O tamanho do ViewState da p�gina n�o se deve ao componente e sim as informa��es complementares, que carregam junto com a p�gina.
+ Corrigido bug no RichEdit, que n�o conseguia chamar o javascript para pegar o texto do lado do cliente em outros componentes al�m do bot�o. O problema era que outros componentes utilizam o javascript __doPostBack para passar valores pro servidor e no fim do __doPostBack encontramos um theform.submit(). Como o script do RichEdit estava registrado no onSubmit do form, de algum modo, a chamada do theform.submit() do __doPostBack n�o enchergava o javascript do RichEdit no OnSubmit do form, n�o atualizando o RichEdit e deixando o mesmo vazio na volta do servidor. O problema foi resolvido mudando a estrutura de como disparamos o evento que pega os valores do RichEdit do lado do cliente.

15/04/2005
+ Incluido o controle MaskedEdit que permite especificar uma m�scara para entrada de dados.

12/04/2005
+- Modificado a estrutura do RichEdit que n�o estava funcionando em UserControls, mas agora est� correto. (id�ia do wagner ...)
+- Incluido instrucoes de como utilizar o ComboPopUp com relacao ao bug do primeiro item da lista no Page Load. Na verdade n�o � um bug e sim um problema estrutural.

11/04/2005
- Implementar propriedade no ComboPopUp para pegar o primeiro item da lista.
+- Corrigir bug no RichEdit que n�o est� funcionando dentro de UserControls.
+ Corrigido bug no ComboPopUp que n�o est� pegando valores da modal com a url do CRM. (o problema era de autentica��o na p�gina)
+ Adicionado o controle DataGridGrouped. Bug na identa��o ao utilizarmos o index 0 das colunas. Outros indexes em qualquer ordem funcionam normalmente.

07/04/2005
+ Corrigido bug no ComboPopUp que impedia de utilizar o selecteditem no Page Load da p�gina.
+ Adicionado o RichEdit um editor de html que pode ser utilizado dentro de qualquer WebForm. Compativel com Firefox e IE. Para utiliza-lo coloque validationRequest=false na diretiva <%@ Page %> do aspx.
+ Adicionado uma propriedade no ComboPopUp que permite pegar o valor de retorno do hidden depois do postback.
 
05/04/2005
+ Adicionado o SmartNavigation que funciona tanto no Firefox quanto no IE.
+ Corrigido bug no EditAutoComplete que permitia aparecer a lista de autocomplete do windows e a lista de autocomplete do componente ao mesmo tempo.

04/04/2005
+ Adicionado o evento SelectIndexChanged no ComboPopUp permitindo programar um evento no controle do lado do servidor mantendo o evento do lado do client tbm.
+ Modificado o script de data do controle EditDate.
+ Modificado a propriedade Lista que agora permite passarmos al�m do TextField, o ValueField para o combo. A funcao listaModificada retorna agora o TextField e ValueField no formato especificado. Ex : "item1;01,item2;02,item3;03"

01/04/2005
+ Adi��o da propriedade AutoTab em todos os controles da s�rie edit. Permite pular automaticamente para o pr�ximo campo quando atinge o MaxLength.
+ Incluido uma valida��o do lado do cliente no controle EditAutoComplete que quando o usu�rio tenta digitar um item que n�o est� na tabela, dispara um alert, pedindo para ele escolher um item v�lido. 

31/03/2005 - Release 0.9
+ Release 0.9 liberado. O pulo no n�mero de vers�es � devido, as in�meras corre��es de bugs e inclus�es que este release teve.
+ Inclus�o dos controles: ComboPopUp, ImageHighLighting, ImagePopUp, ModalLink, EditAutoComplete. Destes o �nico compativel com Firefox � o EditAutoComplete. A funcionalidade dos outros se perde ao convertermos os demais para Firefox, devido a n�o exist�ncia de janelas modais no Firefox na vers�o atual 1.0.2
- Corrigir bug no ComboPopUp que quando n�o temos nenhum item no combo n�o � possivel abrir a janela outros devido ao index n�o mudar. O controle dispara o evento no change. (encontrar outra forma de disparar o evento?)
- Inclus�o de autovalida��o do lado cliente no controle EditAutoComplete permitindo ao usu�rio selecionar ou digitar apenas um item que esteja na tabela que aparece embaixo do mesmo.
- N�o mostrar a classe ModalWindow no ToolBox pois ela serve apenas para ser herdada

18/03/2005 - Release 0.2
+ Release 0.2 liberado
+ Inclus�o da maior funcionalidade at� agora, permitindo especificar entre lado cliente e lado servidor para cada valida��o.
+ Inclus�o dos controles EditTime e EditEmail e mudan�a na nomenclatura dos componentes acrescentando o prefixo  na frente do nome atual

17/03/2005
+ Corrigido bug no Edit ao selecionarmos a valida��o do lado do servidor, quando setamos readwrite para false, o controle virava "label" mesmo sem ser v�lido.
+ Adi��o do EditTime e EditEmail

16/03/2005
- Corrigir bug no ExpandCheckBox que ao inserirmos um panel e 1 botao dentro a primeira vez que clicamos no bot�o o panel se esconde automaticamente, aparentemente parece ser s� na primeira vez.
- Corrigir bug no Edit que ao selecionarmos a valida��o do lado do servidor, quando setamos readwrite para false, o controle vira "label" mesmo sem ser v�lido.

14/03/2005
+ Corrigido bug no javascript DataUtil que impedia de selecionarmos uma data no input e digitarmos outro valor sobre ela
+ Substituido javascript que fazia a m�scara do EdiNumber, agora quando digitamos 1, o java n�o altera para 1 centavo como estava antigamente.
- Corrigir bug no EditDatePopUp que quando outro campo ganhava foco com o calend�rio aberto, o mesmo n�o fechava.

11/03/2005 - Release 0.1
- Bug no ExpandedCheckBox que ao setarmos EnableClientScript para false n�o funciona corretamente. N�o afeta em nada 
o funcionamento correto do compomente quando setado para true.
+ Primeiro release liberado. 