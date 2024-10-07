using GeometryClasses;

namespace TestLekcijai6;

public partial class FiguresMainPage : ContentPage
{
    public IDataManager dm;

    public FiguresMainPage()
	{
		InitializeComponent();
        dm = App.dm;
    }

    private void btnPrint_Clicked(object sender, EventArgs e)
    {
        lblText.Text = dm.Print();
    }

    private void btnLoad_Clicked(object sender, EventArgs e)
    {
        dm.Load();
    }

    private void btnSave_Clicked(object sender, EventArgs e)
    {
        dm.Save();
    }

    private void btnCreate_Clicked(object sender, EventArgs e)
    {
        dm.CreateTestData();
    }

    private void btnReset_Clicked(object sender, EventArgs e)
    {
        dm.Reset();
    }
}