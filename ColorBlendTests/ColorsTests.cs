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
			Services.AddSingleton<BlendService>(new BlendService());
			var cut = RenderComponent<ColorsPage>();


			Assert.Equal("save", cut.Find($".rz-button-text").TextContent);

		}

	}
}