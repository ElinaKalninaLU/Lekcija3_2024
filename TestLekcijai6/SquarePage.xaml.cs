using GeometryClasses;
using System.Xml.Linq;

namespace TestLekcijai6;

public partial class SquarePage : ContentPage
{
	private IAddFigure _dm;
	public SquarePage()
	{
		_dm = App.dm;
        InitializeComponent();
	}

    private void btnCreateSquare_Clicked(object sender, EventArgs e)
    {
		try
		{
			var sq = new Square(int.Parse(txtEdge.Text));
			_dm.AddFigure(sq);
            lblResult.Text = "Figure: " + sq.ToString();
        }
		catch (Exception ex){
			lblResult.Text = "Incorect Edge Length " + ex.Message;
		}
    }
}