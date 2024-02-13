namespace EvidencePrijimacihoRizeni_Vilimek
{
	partial class HlavniOkno
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			listBoxStredniSkola = new ListBox();
			SuspendLayout();
			// 
			// listBoxStredniSkola
			// 
			listBoxStredniSkola.FormattingEnabled = true;
			listBoxStredniSkola.ItemHeight = 15;
			listBoxStredniSkola.Location = new Point(12, 12);
			listBoxStredniSkola.Name = "listBoxStredniSkola";
			listBoxStredniSkola.Size = new Size(179, 244);
			listBoxStredniSkola.TabIndex = 0;
			// 
			// HlavniOkno
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(listBoxStredniSkola);
			Name = "HlavniOkno";
			Text = "Form1";
			ResumeLayout(false);
		}

		#endregion

		private ListBox listBoxStredniSkola;
	}
}
