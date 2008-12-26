KAOS.WebControls
===
* luis@planobe.com.br
* jean@planobe.com.br

Biblioteca de controles para asp.net feito em C# e JavaScript. Release inicial em 11/03/2005. 
Testado no framework 1.1. Desenvolvido no VS 2002, e VS 2003.
Compatibilidade com o ASP.NET 2.0 (não testado completamente).

Controles disponiveis e recomendações

* Todos os controles da série Edit possuem uma propriedade chamada AutoTab, que quando true, pula automaticamente para o próximo campo, quando atingir o MaxLength do Edit.
* Todos os controles da série Edit possuem uma propriedade chamada ReadWrite que quando setada para false 
"transforma" o textbox em um label. Todos possuem validação de RequiredFieldValidator e RangeValidator tbm, 
não necessitando mais a utilização de validators em sua página.
* (*noFirefox) Não compativel com Firefox.

ContentBar - componente html que é uma barra horizontal 100 % no topo da página com um menu a direita da tela que pode ser contraido ou expandido. Este menu na verdade é um Iframe, onde mostramos o conteúdo de outras páginas. O compomente possui a propriedade Src que é a url que desejamos abrir em nosso menu, Description que é a descrição que vai aparecer no centro da barra horizontal, outras propriedades referentes a caminho de icones que aparecerão alinhados a esquerda da barra horizontal, ClassTable que é o nome do estilo que será aplicada a barra horizontal, Contracted que permite especificarmos se o menu do lado direito aparecerá contraido ou não e TextLinkNews que é o texto que aparecerá em cima do menu do lado direito. Quando as propriedades referentes a caminho estiverem vazia os icones não aparecerão. A pasta ContentBar contém um estilo para a formatação da barra horizontal, e imagens recomendadas para sua utilização. Alguns estilos contidos na folha de estilo encontrada nesta pasta são integrados com o componente e são obrigatórios para sua correta vizualização.

MaskedEdit - editbox que tem as mesmas funções de validação dos outros Edit* , e permite especificar uma máscara de entrada de dados. Ex.: Mascara = @@-##. O usuário só poderá digitar letras e números contando que esteja de acordo com a máscara. Qualquer caracteres que forem diferentes de @ e # na especificacão da máscara aparecerão automaticamente conforme o usuário digitar. 

DataGridGrouped - grid, que permite especificarmos que colunas serão a quebra de nivel. Permite especificarmos quantos niveis forem necessários. Devemos utilizar a propriedade IndexesColumn para isso, onde colocaremos os valores dos indexes separados por virgula. Ex: 1,2,3. Respectivamente setamos a propriedade CssClassNiveis onde devemos obrigatoriamente especificar o nome do estilo que queremos utilizar na linha de quebra. Não devemos utilizar 0 como index, pois a identação não funcionará corretamente.

SmartNavigation - controle quer permite manter a posicao da página mesmo depois do postback. Funciona tanto em IE como Firefox. Para utilizarmos basta arrastarmos para a página.

ComboPopUp - combo quer permite especificarmos seu último item. Quando o usuário clicar neste item abrirá uma janela no modal. Ao fecharmos esta janela o usuário pode voltar um valor que aparecerá no primeiro item do como. Possui a função ListaMoficada() que permite pegarmos o conteúdo modificado do combo, depois que o valor é retornado. Deve ser utilizado em conjunto com o ModalLink. (*noFirefox)

ImageHighLighting - image que possui um efeito de HighLighting. Permite escolhermos a duração do efeito de 0 a 100. (*noFirefox)

ImagePopUp - possui a propriedade HighLighting também, e ao clicarmos abrirá uma janela model com o endereço que especificarmos e permite especificarmos o campo que será atualizado, quando fecharmos a janela modal. (*noFirefox)

ModalLink - link que possui uma propriedade chamada valor de retorno. Ao clicarmos nesse link a janela fechará e retornará um valor para a janela atrás. Deve ser usado em conjunto com um dos controles *PopUp. (*noFirefox) 

Edit - textbox normal que permite validação de requerido e de range.

EditAutoComplete - editbox que ao usuário digitar dados aparecerá uma tabela embaixo do controle que filtra automaticamente os valores especificados na propriedade Dados. Permite especificarmos quantos items queremos na tabela filtrada e também se queremos que o controle procure por qualquer parte da string dos items, ou só pelo começo da palavra. Para utilizarmos este controle devemos colocar a pasta autocomplete no diretório de nossa aplicação. Devemos setar corretamente a propriedade CaminhoJs do controle. Inclui validação de campo requerido.

EditDate - textbox que permite apenas digitar datas, fornece uma máscara automática ao digitarmos no campo. Permite 
validação de campo requerido e permite a também validação entre duas datas estipuladas.

EditDatePopUp - Igual ao EditDate com um calendário que vem ao lado do campo , para facilitar a inclusão de datas. O 
calendário escrito em js, pode ser totalmente customizado, e as imagens e o script do mesmo, estão nesta pasta, no 
diretório chamado calendar. Para utilizarmos o calendário devemos colocar a pasta calendar no diretório de nossa 
aplicação. Devemos setar corretamente a propriedade CaminhoJs do controle.

EditMoney - textbox que permite apenas digitação de valores no formato moeda e que inclui tbm umas máscara automática 
conformes digitamos. Validação de campo requerido e de valores de comparação tbm.

EditNumber - igual ao EditMoney, com a diferença que é permitido apenas a digitação de valores inteiros. Validação de 
campo requerido e de valores de comparação tbm.

EditEmail - textbox com validação de email e campo requerido.

EditTime - textbox com validação de hora no formato hh:mm:ss (os segundos são opcionais). Validação de campo requerido tbm.

Label - Label quer permite especificarmos um valor de comparação. Se o valor de comparação for diferente do valor da 
label ela mudará de cor. Valor de comparação é decimal.

ExpandingButton,ExpandingCheckBox,ExpandingImagemButton,ExpandingLinkButton - Série de controles que permite 
esconder/mostrar panels, componentes, etc ... Todos possuem um propriedade chamada boolean Expanded, que controla a 
visibilidade do controle que definirmos em ControlToToggle. Cada um tem particularidades diferentes, mas todos tem 
o mesmo objetivo. Destaque para o ExpandingImagemButton.
Obs: utilize ExpandigControls.Expanded = true ou false para controlar a visibilidade do panel ou qualquer coisa que vc 
irá controlar.

ExpandingRadio e ExpandingCombo - Controles que permitem esconder e mostrar divs, dependendo da opção selecionada, no ComboBox ou no grupo de radios. Possuem uma propriedade chamada TextoItemDiv onde especificamos o controle das divs e qual condição.A estrutura é a seguinte: SELECTEDTEXT=DIVQUECONTROLAREMOS,SELECTEDTEXT=DIVQUECONTROLAREMOS e assim por diante,separando por virgula. Exemplo: item1=divdoitem1,item2=divdoitem2. Quando no caso do combo o selecteditemtext for igual a item1, a divdoitem1 aparecerá, e a divdoitem2 se esconderá e assim vice-versa. No caso do radio, a propriedade TextoItemDiv tem que estar igual em todos os radios do grupo. 

Histórico Pré Era do Versionamento
===
17/11/2006 - Release 2.4
+ Incluido propriedade enabled (true/false) no componente smartnavigation. Isto permite habilitar ou desabilitar o smartnavigation na página em tempo de execução. 
+ Relatado problemas na utilização de RichTextBox , no controle de abas da Microsoft + smartnavigation Microsoft. Recomenda-se utilizar RichTextBox com 
smartnavigation do framework KAOS.

13/07/2006 - Release 2.3
+ ValidarClientSide e RequeridoClientSide do controle EditDatePopUp estavam como ReadOnly nao permitindo mudar em tempo de edicao. Ref: 28/12/2005

27/4/2006 - Release 2.0
+ Corrigido pequeno problema em EditMask.js , que estava engolindo o caractere digitado , e trocando pelo simbolo especificado na mascara. Agora coloca-se o simbolo da mascara, e o caractere digitado tbm.

28/12/2005
+ Modificado a propriedade ReadOnly da propriedade ValidarClientSide para false, do controle Edit.cs(linha 173). Parece que todos os controles que estao herdando desta classe, mesmo sobreescrevendo esta propriedade para ReadOnly false, nao está permitindo a alteracao em design Time no Visual Studio.

13/12/2005
+ Havia me esquecido de colocar a tag ReadWrite = true na assinatura do componente EditDatePopUp causando erro de cast na hora de incluir o componente na ide. Isto ocorria pq o componente EditDate q estava dentro do webcontrol EditDatePopUp teve a assinatura modificada , adicionando ReadWrite

7/12/2005
+ A propriedade Alinhar do Edit estava como readonly. Alterada para property normal. Nao lembro pq estava assim ?
+ O controle Edit, estava perdendo a propriedade ReadWrite entre os postbacks. Sobreescrita a funcao LoadPostData para recuperar o valor do ReadWrite do Edit, pois o TextBox ja implementa a interface IPostBackHandler.

6/12/2005
+ Corrigido bug no EditAutoComplete que ao deixarmos a opcao ReadWrite como false ou seja nao editavel o mesmo se clicassemos em cima do campo e digitassemos alguma coisa a caixa de autocomplete aparecia. (linha 89, EditAutoComplete.cs)
+ Mudado o style do Edit quando a opcao ReadWrite esta como false ou seja o componente está no modo label. O conteúdo do Edit fica em negrito. (linha 265,267, Edit.cs)

17/11/2005
+ Modificao da Lib para compilacao. Liberado release KAOS.WebControls

07/6/2005
+ Alterado o nome da propriedade CaminhoIconeNews para CaminhoExpandedIconeNews.
+ Adicionado a propriedade CaminhoContractedIconeNews que é usada para mostrar um outro Icone quando a barra está contraída.

03/6/2005
+ Retirado as alterações do dia 25/5/2005.
+ Adicionado a propriedade ShowIconeLinkNews no ContentBar para ser usando nas configurações de segurança dos sistemas.

25/5/2005
+ Adicionado a propriedade position:absolute ao style do ContentBar para corrigir problemas com relação ao posicionamento de outros componentes na página.

6/5/2005
+ Incluido os componentes ExpandingRadio e ExpandingCombo.

3/5/2005 - Release 1.0
+ Release 1.0 liberado.
+ Incluido o controle ContentBar.
+ Corrigido bug na estrutura do ContentBar que carregava o iframe com a barra a direita toda vez que o usuario entrasse na pagina mesmo com a barra contraida. O usuario não veria a barra, por causa do display:none mas o conteúdo estaria lá, atrasando em muito o carregamento das páginas. Modificado para renderizar o frame inteiro e não só a propriedade display:block, quando a opção contracted = false. O jeito antigo com display:none é util ao utilizarmos js para controlar a barra do lado do cliente, mas muito demorado visto que devemos ir ao servidor para buscar noticias. 

2/5/2005
+ Corrigido bug no no javascript do RichEdit referente a design. Do lado direito o componente aparecia uma área em branco que ao deixarmos o width em 100% aparecia uma barra de rolagem horizontal.

21/4/2005
+ Corrigido bug quando utilizamos o RichEdit em UserControls ocorria um erro de javascript devido a diferença do nome do RichEdit no lado do cliente quando o mesmo está dentro de UserControls.
+ Adicionado um script do RichEdit especifico para o CRM. Foram removidas várias opções de customização do texto. Basta adicionar a pasta richedit_crm no lugar da richedit se quiser o componente com menos opções. Não há problema nenhum em utilizar os dois componentes ao mesmo tempo, contando que na propriedade caminhoJs cada um esteja apontado para uma pasta.

19/04/2005
+ Modificada a font default do RichEdit para Verdana. A primeira vez que o componente carrega sua fonte é Verdana. Se darmos um postback com o componente vazio, o componente apaga a tag da font e retorna a fonte original.
+ Corrigido bug referente quando existiam 2 ou mais controles RichEdit na mesma página. Novamente alterado a estrutura de como disparamos a function em js que pega os valores do RichEdit do lado do cliente.

18/04/2005
+ Verificado o problema de ViewState referente ao componente RichEdit. O tamanho do ViewState da página não se deve ao componente e sim as informações complementares, que carregam junto com a página.
+ Corrigido bug no RichEdit, que não conseguia chamar o javascript para pegar o texto do lado do cliente em outros componentes além do botão. O problema era que outros componentes utilizam o javascript __doPostBack para passar valores pro servidor e no fim do __doPostBack encontramos um theform.submit(). Como o script do RichEdit estava registrado no onSubmit do form, de algum modo, a chamada do theform.submit() do __doPostBack não enchergava o javascript do RichEdit no OnSubmit do form, não atualizando o RichEdit e deixando o mesmo vazio na volta do servidor. O problema foi resolvido mudando a estrutura de como disparamos o evento que pega os valores do RichEdit do lado do cliente.

15/04/2005
+ Incluido o controle MaskedEdit que permite especificar uma máscara para entrada de dados.

12/04/2005
+- Modificado a estrutura do RichEdit que não estava funcionando em UserControls, mas agora está correto. (idéia do wagner ...)
+- Incluido instrucoes de como utilizar o ComboPopUp com relacao ao bug do primeiro item da lista no Page Load. Na verdade não é um bug e sim um problema estrutural.

11/04/2005
- Implementar propriedade no ComboPopUp para pegar o primeiro item da lista.
+- Corrigir bug no RichEdit que não está funcionando dentro de UserControls.
+ Corrigido bug no ComboPopUp que não está pegando valores da modal com a url do CRM. (o problema era de autenticação na página)
+ Adicionado o controle DataGridGrouped. Bug na identação ao utilizarmos o index 0 das colunas. Outros indexes em qualquer ordem funcionam normalmente.

07/04/2005
+ Corrigido bug no ComboPopUp que impedia de utilizar o selecteditem no Page Load da página.
+ Adicionado o RichEdit um editor de html que pode ser utilizado dentro de qualquer WebForm. Compativel com Firefox e IE. Para utiliza-lo coloque validationRequest=false na diretiva <%@ Page %> do aspx.
+ Adicionado uma propriedade no ComboPopUp que permite pegar o valor de retorno do hidden depois do postback.
 
05/04/2005
+ Adicionado o SmartNavigation que funciona tanto no Firefox quanto no IE.
+ Corrigido bug no EditAutoComplete que permitia aparecer a lista de autocomplete do windows e a lista de autocomplete do componente ao mesmo tempo.

04/04/2005
+ Adicionado o evento SelectIndexChanged no ComboPopUp permitindo programar um evento no controle do lado do servidor mantendo o evento do lado do client tbm.
+ Modificado o script de data do controle EditDate.
+ Modificado a propriedade Lista que agora permite passarmos além do TextField, o ValueField para o combo. A funcao listaModificada retorna agora o TextField e ValueField no formato especificado. Ex : "item1;01,item2;02,item3;03"

01/04/2005
+ Adição da propriedade AutoTab em todos os controles da série edit. Permite pular automaticamente para o próximo campo quando atinge o MaxLength.
+ Incluido uma validação do lado do cliente no controle EditAutoComplete que quando o usuário tenta digitar um item que não está na tabela, dispara um alert, pedindo para ele escolher um item válido. 

31/03/2005 - Release 0.9
+ Release 0.9 liberado. O pulo no número de versões é devido, as inúmeras correções de bugs e inclusões que este release teve.
+ Inclusão dos controles: ComboPopUp, ImageHighLighting, ImagePopUp, ModalLink, EditAutoComplete. Destes o único compativel com Firefox é o EditAutoComplete. A funcionalidade dos outros se perde ao convertermos os demais para Firefox, devido a não existência de janelas modais no Firefox na versão atual 1.0.2
- Corrigir bug no ComboPopUp que quando não temos nenhum item no combo não é possivel abrir a janela outros devido ao index não mudar. O controle dispara o evento no change. (encontrar outra forma de disparar o evento?)
- Inclusão de autovalidação do lado cliente no controle EditAutoComplete permitindo ao usuário selecionar ou digitar apenas um item que esteja na tabela que aparece embaixo do mesmo.
- Não mostrar a classe ModalWindow no ToolBox pois ela serve apenas para ser herdada

18/03/2005 - Release 0.2
+ Release 0.2 liberado
+ Inclusão da maior funcionalidade até agora, permitindo especificar entre lado cliente e lado servidor para cada validação.
+ Inclusão dos controles EditTime e EditEmail e mudança na nomenclatura dos componentes acrescentando o prefixo  na frente do nome atual

17/03/2005
+ Corrigido bug no Edit ao selecionarmos a validação do lado do servidor, quando setamos readwrite para false, o controle virava "label" mesmo sem ser válido.
+ Adição do EditTime e EditEmail

16/03/2005
- Corrigir bug no ExpandCheckBox que ao inserirmos um panel e 1 botao dentro a primeira vez que clicamos no botão o panel se esconde automaticamente, aparentemente parece ser só na primeira vez.
- Corrigir bug no Edit que ao selecionarmos a validação do lado do servidor, quando setamos readwrite para false, o controle vira "label" mesmo sem ser válido.

14/03/2005
+ Corrigido bug no javascript DataUtil que impedia de selecionarmos uma data no input e digitarmos outro valor sobre ela
+ Substituido javascript que fazia a máscara do EdiNumber, agora quando digitamos 1, o java não altera para 1 centavo como estava antigamente.
- Corrigir bug no EditDatePopUp que quando outro campo ganhava foco com o calendário aberto, o mesmo não fechava.

11/03/2005 - Release 0.1
- Bug no ExpandedCheckBox que ao setarmos EnableClientScript para false não funciona corretamente. Não afeta em nada 
o funcionamento correto do compomente quando setado para true.
+ Primeiro release liberado.