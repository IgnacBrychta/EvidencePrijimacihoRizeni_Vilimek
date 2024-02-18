namespace EvidencePrijimacihoRizeni_Vilimek
{
	partial class OknoUpravitPrihlasku
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
			button_potvrditZmeny = new Button();
			groupBox11.SuspendLayout();
			SuspendLayout();
			// 
			// groupBox11
			// 
			groupBox11.Controls.Add(button_zrusit);
			groupBox11.Controls.Add(button_potvrditZmeny);
			groupBox11.Location = new Point(7, 374);
			groupBox11.Margin = new Padding(2, 1, 2, 1);
			groupBox11.Name = "groupBox11";
			groupBox11.Padding = new Padding(2, 1, 2, 1);
			groupBox11.Size = new Size(618, 89);
			groupBox11.TabIndex = 4;
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
			// button_potvrditZmeny
			// 
			button_potvrditZmeny.Location = new Point(11, 18);
			button_potvrditZmeny.Margin = new Padding(2, 1, 2, 1);
			button_potvrditZmeny.Name = "button_potvrditZmeny";
			button_potvrditZmeny.Size = new Size(285, 62);
			button_potvrditZmeny.TabIndex = 0;
			button_potvrditZmeny.Text = "Potvrdit změny";
			button_potvrditZmeny.UseVisualStyleBackColor = true;
			// 
			// OknoUpravitPrihlasku
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(638, 486);
			Controls.Add(groupBox11);
			Margin = new Padding(2, 1, 2, 1);
			Name = "OknoUpravitPrihlasku";
			Text = "OknoUpravitPrihlasku";
			groupBox11.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion
		private GroupBox groupBox11;
		private Button button_zrusit;
		private Button button_potvrditZmeny;
	}
}