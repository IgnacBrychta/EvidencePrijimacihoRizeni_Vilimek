namespace EvidencePrijimacihoRizeni_Vilimek
{
	partial class OknoNovaPrihlaska
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			groupBox11 = new GroupBox();
			button_zrusit = new Button();
			button_vytvorit = new Button();
			groupBox11.SuspendLayout();
			SuspendLayout();
			// 
			// groupBox11
			// 
			groupBox11.Controls.Add(button_zrusit);
			groupBox11.Controls.Add(button_vytvorit);
			groupBox11.Location = new Point(7, 384);
			groupBox11.Margin = new Padding(2, 1, 2, 1);
			groupBox11.Name = "groupBox11";
			groupBox11.Padding = new Padding(2, 1, 2, 1);
			groupBox11.Size = new Size(618, 89);
			groupBox11.TabIndex = 5;
			groupBox11.TabStop = false;
			groupBox11.Text = "Možnosti";
			// 
			// button_zrusit
			// 
			button_zrusit.Location = new Point(314, 18);
			button_zrusit.Margin = new Padding(2, 1, 2, 1);
			button_zrusit.Name = "button_zrusit";
			button_zrusit.Size = new Size(288, 62);
			button_zrusit.TabIndex = 1;
			button_zrusit.Text = "Zrušit";
			button_zrusit.UseVisualStyleBackColor = true;
			// 
			// button_vytvorit
			// 
			button_vytvorit.Location = new Point(11, 18);
			button_vytvorit.Margin = new Padding(2, 1, 2, 1);
			button_vytvorit.Name = "button_vytvorit";
			button_vytvorit.Size = new Size(285, 62);
			button_vytvorit.TabIndex = 0;
			button_vytvorit.Text = "Vytvořit";
			button_vytvorit.UseVisualStyleBackColor = true;
			// 
			// OknoNovaPrihlaska
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(630, 477);
			Controls.Add(groupBox11);
			Name = "OknoNovaPrihlaska";
			Text = "OknoNovaPrihlaska";
			groupBox11.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private GroupBox groupBox11;
		private Button button_zrusit;
		private Button button_vytvorit;
	}
}