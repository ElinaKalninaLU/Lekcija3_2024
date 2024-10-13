namespace Lekcija6;

using GeometryClasses;
using GeometryClasses.GeometryClasses;

public partial class SquarePage : ContentPage
{
	private IAddFigure dm;
	public Square _sq;
    public SquarePage()
	{
		InitializeComponent();
		dm = App.dm;
        AddSquareBtn.Text = "Add Square";
    }

    public SquarePage(Square sq)
    {
        InitializeComponent();
        dm = App.dm;
		_sq = sq;
        Edgetxt.Text = _sq.Edge.ToString();
        AddSquareBtn.Text = "Edit Square";
            }

    private void AddSquareBtn_Clicked(object sender, EventArgs e)
    {
		try {
            if (_sq is null)
            {
                int i = int.Parse(Edgetxt.Text);
			    var sq = new Square(i);
			    ResultLbl.Text = sq.ToString();

				dm.AddFigure(sq);
			} 
            else
                {
                _sq.Edge = int.Parse(Edgetxt.Text);
                ResultLbl.Text = _sq.ToString();
            }
        }
		catch { }
    }
}