using GeometryClasses;
using GeometryClasses.GeometryClasses;
using System.Diagnostics;

namespace Lekcija6;

public partial class FigureListPage : ContentPage
{
    public GeometryDataManager dm;
    public FigureListPage()
	{
        dm = App.dm;
        BindingContext = this;
        InitializeComponent();
	}

    public List<GeometryClass> FigureList
    {
        get
        {
            Debug.WriteLine("GetList");
            return dm.figures;
        }
        set { dm.figures = value; }
    }

    private async void EditClicked(object sender, EventArgs e)
    {
        var b = sender as Button;
        if (b != null)
        {
            if (b.BindingContext is Square)
            {
                var sq = (Square)b.BindingContext;
                var sqPage = new SquarePage(sq);
                await Navigation.PushAsync(sqPage);
            }
        }
     }

    private async void DeleteClicked(object sender, EventArgs e)
    {
        var b = sender as Button;
        if (b != null)
        {
           var f =  b.BindingContext as GeometryClass;
            if ( f!=null)
            {
                bool answer = await DisplayAlert("Question?", "Would you like to delete? " + f.ToString(), "Yes", "No");
                if (answer)
                {
                    dm.figures.Remove(f);
                    BindingContext = null;
                    BindingContext = this;
                }
            }
        }
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = null;
        BindingContext = this;
    }
}