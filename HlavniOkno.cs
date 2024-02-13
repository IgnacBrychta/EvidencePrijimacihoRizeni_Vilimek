namespace EvidencePrijimacihoRizeni_Vilimek;

public partial class HlavniOkno : Form
{
	public HlavniOkno()
	{
		InitializeComponent();

		listBoxStredniSkola.Items.AddRange(Enumerable.Range(1, 100).Select(x => (object)x).ToArray());
		listBoxStredniSkola.SelectedIndexChanged += ListBoxStredniSkola_SelectedIndexChanged;
	}

	private void ListBoxStredniSkola_SelectedIndexChanged(object? sender, EventArgs e)
	{
		Db.test();
	}
}
