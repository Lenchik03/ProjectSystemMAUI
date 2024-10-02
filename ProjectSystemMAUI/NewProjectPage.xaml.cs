namespace ProjectSystemMAUI;

public partial class NewProjectPage : ContentPage
{
    public ProjectModel Project { get; set; }

    private DB dB = new DB();
    public NewProjectPage(ProjectModel project)
	{
		InitializeComponent();
        this.Project = project;
        BindingContext = this;
	}

    private void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
    {
        header.Text = $"�������: {e.NewValue:F1}";
    }
}