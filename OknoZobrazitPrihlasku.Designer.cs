namespace EvidencePrijimacihoRizeni_Vilimek
{
	partial class OknoZobrazitPrihlasku
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
			button_ok = new Button();
			groupBox_typPrihlasky.SuspendLayout();
			groupBox_bodyMatZkouska.SuspendLayout();
			groupBox11.SuspendLayout();
			SuspendLayout();
			// 
			// groupBox11
			// 
			groupBox11.Controls.Add(button_ok);
			groupBox11.Location = new Point(6, 374);
			groupBox11.Margin = new Padding(2, 1, 2, 1);
			groupBox11.Name = "groupBox11";
			groupBox11.Padding = new Padding(2, 1, 2, 1);
			groupBox11.Size = new Size(618, 89);
			groupBox11.TabIndex = 5;
			groupBox11.TabStop = false;
			groupBox11.Text = "Možnosti";
			// 
			// button_ok
			// 
			button_ok.Location = new Point(11, 18);
			button_ok.Margin = new Padding(2, 1, 2, 1);
			button_ok.Name = "button_ok";
			button_ok.Size = new Size(603, 62);
			button_ok.TabIndex = 0;
			button_ok.Text = "OK";
			button_ok.UseVisualStyleBackColor = true;
			// 
			// OknoZobrazitPrihlasku
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(631, 471);
			Controls.Add(groupBox11);
			Name = "OknoZobrazitPrihlasku";
			Text = "OknoZobrazitPrihlasku";
			Controls.SetChildIndex(groupBox11, 0);
			groupBox_typPrihlasky.ResumeLayout(false);
			groupBox_typPrihlasky.PerformLayout();
			groupBox_bodyMatZkouska.ResumeLayout(false);
			groupBox_bodyMatZkouska.PerformLayout();
			groupBox11.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private GroupBox groupBox11;
		private Button button_ok;
	}
}