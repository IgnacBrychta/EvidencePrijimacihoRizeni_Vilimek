namespace EvidencePrijimacihoRizeni_Vilimek
{
	partial class OknoPrijatePrihlasky
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
			groupBox1 = new GroupBox();
			groupBox2 = new GroupBox();
			groupBox3 = new GroupBox();
			listBoxPrijati = new ListBox();
			radioButtonStredni = new RadioButton();
			radioButtonVyssi = new RadioButton();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox3.SuspendLayout();
			SuspendLayout();
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(groupBox3);
			groupBox1.Controls.Add(groupBox2);
			groupBox1.Location = new Point(12, 12);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(308, 471);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "Přijatí uchazeči";
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(radioButtonVyssi);
			groupBox2.Controls.Add(radioButtonStredni);
			groupBox2.Location = new Point(6, 22);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(294, 55);
			groupBox2.TabIndex = 0;
			groupBox2.TabStop = false;
			groupBox2.Text = "Okruh";
			// 
			// groupBox3
			// 
			groupBox3.Controls.Add(listBoxPrijati);
			groupBox3.Location = new Point(6, 83);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new Size(294, 382);
			groupBox3.TabIndex = 1;
			groupBox3.TabStop = false;
			groupBox3.Text = "Seznam";
			// 
			// listBoxPrijati
			// 
			listBoxPrijati.FormattingEnabled = true;
			listBoxPrijati.ItemHeight = 15;
			listBoxPrijati.Location = new Point(6, 22);
			listBoxPrijati.Name = "listBoxPrijati";
			listBoxPrijati.Size = new Size(282, 349);
			listBoxPrijati.TabIndex = 0;
			// 
			// radioButtonStredni
			// 
			radioButtonStredni.AutoSize = true;
			radioButtonStredni.Location = new Point(11, 26);
			radioButtonStredni.Name = "radioButtonStredni";
			radioButtonStredni.Size = new Size(92, 19);
			radioButtonStredni.TabIndex = 0;
			radioButtonStredni.TabStop = true;
			radioButtonStredni.Text = "Střední škola";
			radioButtonStredni.UseVisualStyleBackColor = true;
			// 
			// radioButtonVyssi
			// 
			radioButtonVyssi.AutoSize = true;
			radioButtonVyssi.Location = new Point(152, 26);
			radioButtonVyssi.Name = "radioButtonVyssi";
			radioButtonVyssi.Size = new Size(129, 19);
			radioButtonVyssi.TabIndex = 1;
			radioButtonVyssi.TabStop = true;
			radioButtonVyssi.Text = "Vyšší odborná škola";
			radioButtonVyssi.UseVisualStyleBackColor = true;
			// 
			// OknoPrijatePrihlasky
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(329, 495);
			Controls.Add(groupBox1);
			Name = "OknoPrijatePrihlasky";
			Text = "OknoPrijatePrihlasky";
			groupBox1.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			groupBox3.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private GroupBox groupBox1;
		private GroupBox groupBox3;
		private ListBox listBoxPrijati;
		private GroupBox groupBox2;
		private RadioButton radioButtonVyssi;
		private RadioButton radioButtonStredni;
	}
}