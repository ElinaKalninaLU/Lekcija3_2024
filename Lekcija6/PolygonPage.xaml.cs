using GeometryClasses;

namespace Lekcija6;

public partial class PolygonPage : ContentPage
{
    private Polygon p;
    private IAddFigure dm;
	public PolygonPage()
	{
		InitializeComponent();
        dm = App.dm;
        p  = new Polygon();
        ColourPicker.SelectedIndex = 1;
	}

    public PolygonPage(Polygon _p)
    {
        InitializeComponent();
        dm = App.dm;
        p = _p;
        ColourPicker.SelectedItem = p.figureColour.ToString();
        RefreshPage();
        AddPolygonBtn.IsVisible = false;
        EditPolygonBtn.IsVisible = true;

    }
    private void RefreshPage()
    {
        lstPoints.ItemsSource = null;
        lstPoints.ItemsSource = p.Points;
    }

    private void btnAddPoint_Clicked(object sender, EventArgs e)
    {
        var po = new GeometryClasses.Point(int.Parse(txtX.Text), int.Parse(txtY.Text));
        p.AddPoint(po);
        RefreshPage();
    }

    private void btnRemovePoint_Clicked(object sender, EventArgs e)
    {
        if (lstPoints.SelectedItem != null && lstPoints.SelectedItem is GeometryClasses.Point)
        {
            GeometryClasses.Point po = (GeometryClasses.Point)lstPoints.SelectedItem;
                p.Points.Remove(po);
            RefreshPage();
        }
    }

    private void AddPolygonBtn_Clicked(object sender, EventArgs e)
    {
        p.figureColour = (GeometryClasses.Colour)Enum.Parse(typeof(GeometryClasses.Colour), (String)ColourPicker.SelectedItem);
        dm.AddFigure(p);
        ResultLbl.Text =p.ToString();
        p = new Polygon();
        RefreshPage();
    }

    private void EditPolygonBtn_Clicked(object sender, EventArgs e)
    {
        p.figureColour = (GeometryClasses.Colour)Enum.Parse(typeof(GeometryClasses.Colour), (String)ColourPicker.SelectedItem);
        ResultLbl.Text = p.ToString();
        Navigation.PopAsync();
    }
}