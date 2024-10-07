using GeometryClasses;
using System.Runtime.Intrinsics.Arm;

namespace TestLekcijai6;

public partial class RectanglePage : ContentPage
{
    private IAddFigure _dm;
    public RectanglePage()
	{
		InitializeComponent();
        _dm = App.dm;
    }

    private void btnCreateRectangle_Clicked(object sender, EventArgs e)
    {
        try
        {
            int x = int.Parse(txtX.Text);
            int y = int.Parse(txtY.Text);
            var rec = new Rectangle();
            rec.Height = x;
            rec.Width = y;
            _dm.AddFigure(rec);
            lblResult.Text = "Figure: " + rec.ToString();
        }
        catch (Exception ex)
        {
            lblResult.Text = "Incorect Edge Length " + ex.Message;
        }
    }
}