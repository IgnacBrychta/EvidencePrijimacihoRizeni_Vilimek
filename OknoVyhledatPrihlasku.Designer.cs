namespace EvidencePrijimacihoRizeni_Vilimek
{
	partial class OknoVyhledatPrihlasku
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
			groupBox2 = new GroupBox();
			groupBox3 = new GroupBox();
			textBox_hledaneId = new TextBox();
			button_vyhledat = new Button();
			groupBox1 = new GroupBox();
			button_zrusit = new Button();
			button_zvolit = new Button();
			groupBox11.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox3.SuspendLayout();
			groupBox1.SuspendLayout();
			SuspendLayout();
			// 
			// groupBox11
			// 
			groupBox11.Controls.Add(groupBox2);
			groupBox11.Controls.Add(groupBox1);
			groupBox11.Location = new Point(7, 374);
			groupBox11.Margin = new Padding(2, 1, 2, 1);
			groupBox11.Name = "groupBox11";
			groupBox11.Padding = new Padding(2, 1, 2, 1);
			groupBox11.Size = new Size(618, 199);
			groupBox11.TabIndex = 5;
			groupBox11.TabStop = false;
			groupBox11.Text = "Vyhledávání";
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(groupBox3);
			groupBox2.Controls.Add(button_vyhledat);
			groupBox2.Location = new Point(11, 20);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(590, 75);
			groupBox2.TabIndex = 7;
			groupBox2.TabStop = false;
			// 
			// groupBox3
			// 
			groupBox3.Controls.Add(textBox_hledaneId);
			groupBox3.Location = new Point(6, 13);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new Size(271, 56);
			groupBox3.TabIndex = 2;
			groupBox3.TabStop = false;
			groupBox3.Text = "ID";
			// 
			// textBox_hledaneId
			// 
			textBox_hledaneId.Location = new Point(6, 22);
			textBox_hledaneId.Name = "textBox_hledaneId";
			textBox_hledaneId.Size = new Size(252, 23);
			textBox_hledaneId.TabIndex = 6;
			// 
			// button_vyhledat
			// 
			button_vyhledat.Location = new Point(309, 13);
			button_vyhledat.Margin = new Padding(2, 1, 2, 1);
			button_vyhledat.Name = "button_vyhledat";
			button_vyhledat.Size = new Size(266, 58);
			button_vyhledat.TabIndex = 1;
			button_vyhledat.Text = "Hledat";
			button_vyhledat.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(button_zrusit);
			groupBox1.Controls.Add(button_zvolit);
			groupBox1.Location = new Point(11, 99);
			groupBox1.Margin = new Padding(2, 1, 2, 1);
			groupBox1.Name = "groupBox1";
			groupBox1.Padding = new Padding(2, 1, 2, 1);
			groupBox1.Size = new Size(590, 89);
			groupBox1.TabIndex = 6;
			groupBox1.TabStop = false;
			groupBox1.Text = "Možnosti";
			// 
			// button_zrusit
			// 
			button_zrusit.Location = new Point(309, 18);
			button_zrusit.Margin = new Padding(2, 1, 2, 1);
			button_zrusit.Name = "button_zrusit";
			button_zrusit.Size = new Size(266, 62);
			button_zrusit.TabIndex = 1;
			button_zrusit.Text = "Zrušit";
			button_zrusit.UseVisualStyleBackColor = true;
			// 
			// button_zvolit
			// 
			button_zvolit.Location = new Point(11, 18);
			button_zvolit.Margin = new Padding(2, 1, 2, 1);
			button_zvolit.Name = "button_zvolit";
			button_zvolit.Size = new Size(266, 62);
			button_zvolit.TabIndex = 0;
			button_zvolit.Text = "Zvolit";
			button_zvolit.UseVisualStyleBackColor = true;
			// 
			// OknoVyhledatPrihlasku
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(632, 586);
			Controls.Add(groupBox11);
			Name = "OknoVyhledatPrihlasku";
			Text = "OknoVyhledatPrihlasku";
			groupBox11.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			groupBox1.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private GroupBox groupBox11;
		private GroupBox groupBox2;
		private GroupBox groupBox3;
		private TextBox textBox_hledaneId;
		private Button button_vyhledat;
		private GroupBox groupBox1;
		private Button button_zrusit;
		private Button button_zvolit;
	}
}