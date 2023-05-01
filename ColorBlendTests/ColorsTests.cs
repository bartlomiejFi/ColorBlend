using Bunit;
using ColorBlend.Pages;
using ColorBlend.Services;
using ColorBlend.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Radzen;
using Xunit;

namespace ColorBlendTests
{
	public class ColorsTests : TestContext
	{
		[Fact]
		public void RendersSuccessfully()
		{

			Services.AddSingleton<NotificationService>(new NotificationService());
			Services.AddSingleton<IColorsViewModel>(new ColorsBasicViewModel());
			Services.AddSingleton<ColorService>(new ColorService());
			var cut = RenderComponent<ColorsPage>();


			Assert.Equal("mix & save", cut.Find($".rz-button-text").TextContent);
			Assert.Equal("Choose two colors and confirm to save result!", cut.Find($".rz-text-h6").TextContent);

			//cut.Find("#ViewModel.Color input").Change("rgb(100, 100, 100)");
			//cut.Find("RadzenColorPicker").SetAttribute("Color2", "rgb(200, 100, 100)");

			//var cells = cut.FindAll("table>tbody>tr>td");

			//Assert.Collection(cells,
			//    c => Assert.Equal("", c.InnerHtml)
			//    );
		}

	}
}