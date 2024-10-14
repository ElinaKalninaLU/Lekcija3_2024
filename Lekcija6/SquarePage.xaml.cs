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
        ColourPicker.SelectedIndex = 0;
    }
    private Square _sq;
    public SquarePage(Square sq)
    {
        InitializeComponent();
        _sq = sq;
        dm = App.dm;
        Edgetxt.Text = _sq.Edge.ToString();
        ColourPicker.SelectedItem = _sq.figureColour.ToString();
        AddSquareBtn.IsVisible = false;
        EditSquareBtn.IsVisible = true;
    }

    private void AddSquareBtn_Clicked(object sender, EventArgs e)
    {
		try { 
		int i = int.Parse(Edgetxt.Text);
			var sq = new Square(i);
            sq.figureColour = (GeometryClasses.Colour)Enum.Parse(typeof(GeometryClasses.Colour), (String)ColourPicker.SelectedItem);
            ResultLbl.Text = sq.ToString();
			dm.AddFigure(sq);
        }
		catch { }
    }

    private void EditSquareBtn_Clicked(object sender, EventArgs e)
    {
        try
        {
           _sq.Edge = int.Parse(Edgetxt.Text);
           _sq.figureColour = (GeometryClasses.Colour)Enum.Parse(typeof(GeometryClasses.Colour), (String)ColourPicker.SelectedItem);
            ResultLbl.Text = _sq.ToString();
        }
        catch { }
    }
}