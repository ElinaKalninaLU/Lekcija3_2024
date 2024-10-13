using GeometryClasses;
using GeometryClasses.GeometryClasses;

namespace Lekcija6;

public partial class RectanglePage : ContentPage
{
    private IAddFigure dm;
    public RectanglePage()
	{
		InitializeComponent();
        dm = App.dm;
    }

    private void AddRectangleBtn_Clicked(object sender, EventArgs e)
    {
        try
        {
            int y = int.Parse(HeightTXT.Text);
            int x = int.Parse(WidthTXT.Text);
            var re = new Rectangle() { Height = y, Width = x};
            ResultLbl.Text = re.ToString();
            dm.AddFigure(re);
        }
        catch { }
    }
}