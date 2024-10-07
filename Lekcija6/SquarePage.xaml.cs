namespace Lekcija6;

using GeometryClasses;
using GeometryClasses.GeometryClasses;

public partial class SquarePage : ContentPage
{
	private IAddFigure dm;
    public SquarePage()
	{
		InitializeComponent();
		dm = App.dm;
	}

    private void AddSquareBtn_Clicked(object sender, EventArgs e)
    {
		try { 
		int i = int.Parse(Edgetxt.Text);
			var sq = new Square(i);
			ResultLbl.Text = sq.ToString();
			dm.AddFigure(sq);
        }
		catch { }
    }
}