using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace KAOS.WebControls
{
	/// <summary>
	/// Descricao do Label
	/// </summary>
	[
	DefaultProperty("Text"),
	ToolboxData("<{0}:Label runat=server></{0}:Label>"),
	]
	public class Label : System.Web.UI.WebControls.Label 
	{
		#region variables
		System.Drawing.Color _corverdadeira = System.Drawing.Color.Blue;
		System.Drawing.Color _corfalsa = System.Drawing.Color.Red;
		decimal _valordecomparacao = 0;
		#endregion

		#region properties
		/// <summary>
		/// Selecione ou digite uma cor em hex da fonte para valor maior que o valor de comparacao
		/// </summary>
		[
		Description("Selecione ou digite uma cor em hex da fonte para valor maior que:"),
		Bindable(true),
		Category("Edição"),
		DefaultValue(""),
		]
		public virtual System.Drawing.Color CorMaiorQue 
		{
			get 
			{
				return _corverdadeira;
			}
			set 
			{
				_corverdadeira = value;

			}
		}

		/// <summary>
		/// Selecione ou digite uma cor em hex da fonte para valor menor que o valor de comparacao
		/// </summary>
		[
		Description("Selecione ou digite uma cor em bbb da fonte para valor menor que:"),
		Bindable(true),
		Category("Edição"),
		DefaultValue(""),
		]
		public virtual System.Drawing.Color CorMenorQue
		{
			get 
			{
				return _corfalsa;
			}
			set 
			{
				_corfalsa = value;
			}
		}

		/// <summary>
		/// Digite o valor em decimal a ser comparado com o valor atual do textbox
		/// </summary>
		[
		Description("Digite o valor de comparacao"),
		Bindable(true),
		Category("Edição"),
		DefaultValue(""),
		]
		public virtual decimal ComparaCom 
		{
			get 
			{
				return _valordecomparacao;
			}
			set 
			{
				_valordecomparacao = value;
			}
		}
		#endregion

		#region functions
		/// <summary>
		/// Chama a funcao mudacorfonte() depois renderiza a base pai do controle
		/// </summary>
		/// <param name="output"> The HTML writer to write out to </param>
		protected override void Render(HtmlTextWriter output)
		{
			ForeColor = mudacorfonte();
			base.Render(output);
		}

		/// <summary>
		/// Funcao que compara o valor do texto com o valor de comparacao especificado
		/// </summary>
		/// <returns></returns>
		public System.Drawing.Color mudacorfonte(){
			try 
			{
				if ( Convert.ToDecimal(Text)  > _valordecomparacao)
				{
					return _corverdadeira;
				}
				else {
					return _corfalsa;
				}		
			}
			catch (System.FormatException){
				return System.Drawing.Color.Black;
			}
		}
		#endregion
	}
}
