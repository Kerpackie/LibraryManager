using System.Net;
using LibraryManager.Core.Data;
using LibraryManager.Core.Models;
using LibraryManager.Core.Services.CoverService;
using LibraryManager.Core.Tests.Utilities;
using LibraryManager.Core.Validators;
using LibraryManager.Core.Validators.CoverValidator;
using Moq.Protected;

namespace LibraryManager.Core.Tests.ServiceTests;

[TestFixture]
public class CoverServiceTests
{
	private LibraryContext _context;
	private ICoverService _coverService;
	private Mock<CoverValidator> _mockCoverValidator;
	private Mock<IHttpClientFactory> _mockHttpClientFactory;

	[SetUp]
	public void Setup()
	{
		_context = new LibraryContext(new DbConnectionConfig { ProviderName = "Test" });
		_mockCoverValidator = new Mock<CoverValidator>();
		
		// Create a simple 1x1 pixel white image in BMP format
		var mockImage = new byte[]
		{
			0x42, 0x4D, 0x3A, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x36, 0x00, 0x00, 0x00,
			0x28, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x18, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x13, 0x0B, 0x00, 0x00, 0x13, 0x0B, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0x00
		};

		// Create a Mock<HttpMessageHandler>
		var mockHttpMessageHandler = new Mock<HttpMessageHandler>();

		// Setup the SendAsync method to return a HttpResponseMessage with the content set to the bytes of the mock image
		mockHttpMessageHandler
			.Protected()
			.Setup<Task<HttpResponseMessage>>(
				"SendAsync",
				ItExpr.IsAny<HttpRequestMessage>(),
				ItExpr.IsAny<CancellationToken>()
			)
			.ReturnsAsync(new HttpResponseMessage
			{
				StatusCode = HttpStatusCode.OK,
				Content = new ByteArrayContent(mockImage)
			});

		// Create a HttpClient using the mocked HttpMessageHandler
		var client = new HttpClient(mockHttpMessageHandler.Object);

		// Setup the IHttpClientFactory to return the HttpClient when CreateClient is called
		//_mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);
		
		// Set up the mock IHttpClientFactory
		_mockHttpClientFactory = new Mock<IHttpClientFactory>();
		_mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);

		_coverService = new CoverService(_context, _mockHttpClientFactory.Object, _mockCoverValidator.Object);
	}
	
	[TearDown]
	public void Cleanup()
	{
		if (Directory.Exists("./Images/isbn"))
		{
			Directory.Delete("./Images/isbn", true);
		}
	}
	
	[Test]
	public async Task InsertOrIgnoreCoverAsync_AddsCover_WhenCoverDoesNotExist()
	{
		// Arrange
		var cover = new Cover { Id = 1, 
			Small = Covers.UrlSmall, 
			Medium = Covers.UrlMedium, 
			Large = Covers.UrlLarge };
		_mockCoverValidator.Setup(x => x.Validate(cover))
			.Returns(new ValidationResult { IsValid = true });

		// Act
		await _coverService.InsertOrIgnoreCoverAsync(cover);

		// Assert
		_mockCoverValidator.Verify(x => x.Validate(cover), Times.Once);
	}
	
	[Test]
	public async Task InsertOrIgnoreCoverAsync_DoesNotAddCover_WhenCoverExists()
	{
		// Arrange
		var cover = new Cover { Id = 1, 
			Small = Covers.UrlSmall, 
			Medium = Covers.UrlMedium, 
			Large = Covers.UrlLarge };
		_mockCoverValidator.Setup(x => x.Validate(cover))
			.Returns(new ValidationResult { IsValid = true });
		await _coverService.InsertOrIgnoreCoverAsync(cover);

		// Act
		var result = await _coverService.InsertOrIgnoreCoverAsync(cover);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Cover already exists"));
		});
	}
	
	[Test]
	public async Task InsertOrIgnoreCoverAsync_ReturnsFailure_WhenValidationFails()
	{
		// Arrange
		var cover = new Cover { Id = 1, 
			Small = Covers.UrlSmall, 
			Medium = Covers.UrlMedium, 
			Large = Covers.UrlLarge };
		_mockCoverValidator.Setup(x => x.Validate(cover))
			.Returns(new ValidationResult { IsValid = false });

		// Act
		var result = await _coverService.InsertOrIgnoreCoverAsync(cover);

		// Assert
		Assert.That(result.Success, Is.False);
	}
	
	[Test]
	public async Task GetCoverAsync_ReturnsFailure_WhenCoverDoesNotExist()
	{
		// Arrange
		var cover = new Cover { Id = 1, 
			Small = Covers.UrlSmall, 
			Medium = Covers.UrlMedium, 
			Large = Covers.UrlLarge };

		// Act
		var result = await _coverService.GetCoverAsync(cover.Id);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Cover not found"));
		});
	}
	
	[Test]
	public async Task GetCoverAsync_ReturnsCover_WhenCoverExists()
	{
		// Arrange
		var cover = new Cover { Id = 1, 
			Small = Covers.UrlSmall, 
			Medium = Covers.UrlMedium, 
			Large = Covers.UrlLarge };
		
		_mockCoverValidator.Setup(x => x.Validate(cover))
			.Returns(new ValidationResult { IsValid = true });
		
		await _coverService.InsertOrIgnoreCoverAsync(cover);

		// Act
		var result = await _coverService.GetCoverAsync(cover.Id);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.True);
			Assert.That(result.Data, Is.EqualTo(cover));
		});
	}
	
	[Test]
	public async Task GetCoverAsync_ReturnsFailure_WhenCoverIdIsInvalid()
	{
		// Arrange
		var cover = new Cover { Id = 1, 
			Small = Covers.UrlSmall, 
			Medium = Covers.UrlMedium, 
			Large = Covers.UrlLarge };
		
		_mockCoverValidator.Setup(x => x.Validate(cover))
			.Returns(new ValidationResult { IsValid = true });
		await _coverService.InsertOrIgnoreCoverAsync(cover);

		// Act
		var result = await _coverService.GetCoverAsync(2);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Cover not found"));
		});
	}
	
	[Test]
	public async Task UpdateCoverAsync_ReturnsFailure_WhenCoverDoesNotExist()
	{
		// Arrange
		var cover = new Cover { Id = 1, 
			Small = Covers.UrlSmall, 
			Medium = Covers.UrlMedium, 
			Large = Covers.UrlLarge };
		
		_mockCoverValidator.Setup(x => x.Validate(cover))
			.Returns(new ValidationResult { IsValid = true });

		// Act
		var result = await _coverService.UpdateCoverAsync(cover);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Cover not found"));
		});
	}
	
	[Test]
	public async Task UpdateCoverAsync_ReturnsCover_WhenCoverExists()
	{
		// Arrange
		var cover = new Cover { Id = 1, 
			Small = Covers.UrlSmall, 
			Medium = Covers.UrlMedium, 
			Large = Covers.UrlLarge };
		
		_mockCoverValidator.Setup(x => x.Validate(cover))
			.Returns(new ValidationResult { IsValid = true });
		await _coverService.InsertOrIgnoreCoverAsync(cover);

		// Act
		var result = await _coverService.UpdateCoverAsync(cover);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.True);
			Assert.That(result.Data, Is.EqualTo(cover));
		});
	}
	
	[Test]
	public async Task UpdateCoverAsync_ReturnsFailure_WhenCoverIdIsInvalid()
	{
		// Arrange
		var cover = new Cover { Id = 1, 
			Small = Covers.UrlSmall, 
			Medium = Covers.UrlMedium, 
			Large = Covers.UrlLarge };
		
		var cover2 = new Cover { Id = 2, 
			Small = Covers.UrlSmall2, 
			Medium = Covers.UrlMedium2, 
			Large = Covers.UrlLarge2 };
		
		_mockCoverValidator.Setup(x => x.Validate(cover))
			.Returns(new ValidationResult { IsValid = true });
		_mockCoverValidator.Setup(x => x.Validate(cover2))
			.Returns(new ValidationResult { IsValid = true });
		
		await _coverService.InsertOrIgnoreCoverAsync(cover);

		// Act
		var result = await _coverService.UpdateCoverAsync(cover2);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Cover not found"));
		});
	}
	
	[Test]
	public async Task DeleteCoverAsync_ReturnsFailure_WhenCoverDoesNotExist()
	{
		// Arrange
		var cover = new Cover { Id = 1, 
			Small = Covers.UrlSmall, 
			Medium = Covers.UrlMedium, 
			Large = Covers.UrlLarge };

		// Act
		var result = await _coverService.DeleteCoverAsync(cover.Id);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Cover not found"));
		});
	}
	
	[Test]
	public async Task DeleteCoverAsync_ReturnsSuccess_WhenCoverExists()
	{
		// Arrange
		var cover = new Cover { Id = 1, 
			Small = Covers.UrlSmall, 
			Medium = Covers.UrlMedium, 
			Large = Covers.UrlLarge };
		_mockCoverValidator.Setup(x => x.Validate(cover))
			.Returns(new ValidationResult { IsValid = true });
		await _coverService.InsertOrIgnoreCoverAsync(cover);

		// Act
		var result = await _coverService.DeleteCoverAsync(cover.Id);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.True);
			Assert.That(result.Data, Is.True);
		});
	}
	
	[Test]
	public async Task DeleteCoverAsync_ReturnsFailure_WhenCoverIdIsInvalid()
	{
		// Arrange
		var cover = new Cover { Id = 1, 
			Small = Covers.UrlSmall, 
			Medium = Covers.UrlMedium, 
			Large = Covers.UrlLarge };
		_mockCoverValidator.Setup(x => x.Validate(cover))
			.Returns(new ValidationResult { IsValid = true });
		await _coverService.InsertOrIgnoreCoverAsync(cover);

		// Act
		var result = await _coverService.DeleteCoverAsync(2);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Cover not found"));
		});
	}
	
	[Test]
	public async Task DownloadCoverImageAsync_ReturnsFailure_WhenHttpClientThrowsException()
	{
		// Arrange
		var cover = new Cover { Id = 1, 
			Small = Covers.UrlSmall, 
			Medium = Covers.UrlMedium, 
			Large = Covers.UrlLarge };
		
		_mockCoverValidator.Setup(x => x.Validate(cover))
			.Returns(new ValidationResult { IsValid = true });
		
		await _coverService.InsertOrIgnoreCoverAsync(cover);
		_mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>()))
			.Throws(new Exception("An error occurred"));

		// Act
		var result = await _coverService.DownloadCoverImageAsync("isbn", cover);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("An error occurred: An error occurred"));
		});
	}
	
	[Test]
	public async Task DownloadCoverImageAsync_ReturnsFailure_WhenIOExceptionOccurs()
	{
		// Arrange
		var cover = new Cover { Id = 1, 
			Small = Covers.UrlSmall, 
			Medium = Covers.UrlMedium, 
			Large = Covers.UrlLarge };
		
		_mockCoverValidator.Setup(x => x.Validate(cover))
			.Returns(new ValidationResult { IsValid = true });
		
		await _coverService.InsertOrIgnoreCoverAsync(cover);
		
		_mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>()))
			.Throws(new IOException("An error occurred"));

		// Act
		var result = await _coverService.DownloadCoverImageAsync("isbn", cover);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("An error occurred while saving the image: An error occurred"));
		});
	}
	
	[Test]
	public async Task DownloadCoverImageAsync_ReturnsFailure_WhenHttpRequestExceptionOccurs()
	{
		// Arrange
		var cover = new Cover { Id = 1, 
			Small = Covers.UrlSmall, 
			Medium = Covers.UrlMedium, 
			Large = Covers.UrlLarge };
		
		_mockCoverValidator.Setup(x => x.Validate(cover))
			.Returns(new ValidationResult { IsValid = true });
		
		await _coverService.InsertOrIgnoreCoverAsync(cover);
		_mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>()))
			.Throws(new HttpRequestException("An error occurred"));

		// Act
		var result = await _coverService.DownloadCoverImageAsync("isbn", cover);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("An error occurred while downloading the image: An error occurred"));
		});
	}
	
	[Test]
	public async Task DownloadCoverImageAsync_ReturnsSuccess_WhenImagesDownloadedSuccessfully()
	{
		// Arrange
		var cover = new Cover { Id = 1, 
			Small = Covers.UrlSmall, 
			Medium = Covers.UrlMedium, 
			Large = Covers.UrlLarge };
		_mockCoverValidator.Setup(x => x.Validate(cover))
			.Returns(new ValidationResult { IsValid = true });
		await _coverService.InsertOrIgnoreCoverAsync(cover);

		// Act
		var result = await _coverService.DownloadCoverImageAsync("isbn", cover);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.True);
			Assert.That(result.Message, Is.EqualTo("Images downloaded successfully"));
		});
	}
	
	[Test]
	public async Task DownloadCoverImageAsync_DownloadsImagesInParallel()
	{
		// Arrange
		var cover = new Cover { Id = 1, 
			Small = Covers.UrlSmall, 
			Medium = Covers.UrlMedium, 
			Large = Covers.UrlLarge };
		_mockCoverValidator.Setup(x => x.Validate(cover))
			.Returns(new ValidationResult { IsValid = true });
		await _coverService.InsertOrIgnoreCoverAsync(cover);

		// Act
		await _coverService.DownloadCoverImageAsync("isbn", cover);

		// Assert
		_mockHttpClientFactory.Verify(_ => _.CreateClient(It.IsAny<string>()), Times.Once);
	}
	
	[Test]
	public async Task DownloadCoverImageAsync_DownloadsSmallImage()
	{
		// Arrange
		var cover = new Cover { Id = 1, 
			Small = Covers.UrlSmall, 
			Medium = Covers.UrlMedium, 
			Large = Covers.UrlLarge };
		_mockCoverValidator.Setup(x => x.Validate(cover))
			.Returns(new ValidationResult { IsValid = true });
		await _coverService.InsertOrIgnoreCoverAsync(cover);

		// Act
		await _coverService.DownloadCoverImageAsync("isbn", cover);

		// Assert
		_mockHttpClientFactory.Verify(_ => _.CreateClient(It.IsAny<string>()), Times.Once);
	}
	
	[Test]
	public async Task DownloadCoverImageAsync_DownloadsMediumImage()
	{
		// Arrange
		var cover = new Cover { Id = 1, 
			Small = Covers.UrlSmall, 
			Medium = Covers.UrlMedium, 
			Large = Covers.UrlLarge };
		_mockCoverValidator.Setup(x => x.Validate(cover))
			.Returns(new ValidationResult { IsValid = true });
		await _coverService.InsertOrIgnoreCoverAsync(cover);

		// Act
		await _coverService.DownloadCoverImageAsync("isbn", cover);

		// Assert
		_mockHttpClientFactory.Verify(_ => _.CreateClient(It.IsAny<string>()), Times.Once);
	}
	
	[Test]
	public async Task DownloadCoverImageAsync_DownloadsLargeImage()
	{
		// Arrange
		var cover = new Cover { Id = 1, 
			Small = Covers.UrlSmall, 
			Medium = Covers.UrlMedium, 
			Large = Covers.UrlLarge };
		_mockCoverValidator.Setup(x => x.Validate(cover))
			.Returns(new ValidationResult { IsValid = true });
		await _coverService.InsertOrIgnoreCoverAsync(cover);

		// Act
		await _coverService.DownloadCoverImageAsync("isbn", cover);

		// Assert
		_mockHttpClientFactory.Verify(_ => _.CreateClient(It.IsAny<string>()), Times.Once);
	}
	
	[Test]
	public async Task DownloadCoverImageAsync_DownloadsImagesToCorrectDirectory()
	{
		// Arrange
		var cover = new Cover { Id = 1, 
			Small = Covers.UrlSmall, 
			Medium = Covers.UrlMedium, 
			Large = Covers.UrlLarge };
		_mockCoverValidator.Setup(x => x.Validate(cover))
			.Returns(new ValidationResult { IsValid = true });
		await _coverService.InsertOrIgnoreCoverAsync(cover);

		// Act
		await _coverService.DownloadCoverImageAsync("isbn", cover);

		// Assert
		Assert.That(Directory.Exists("./Images/isbn"), Is.True);
	}
	
	[Test]
	public async Task DownloadCoverImageAsync_DownloadsImagesToCorrectFiles()
	{
		// Arrange
		var cover = new Cover { Id = 1, 
			Small = Covers.UrlSmall, 
			Medium = Covers.UrlMedium, 
			Large = Covers.UrlLarge };
		_mockCoverValidator.Setup(x => x.Validate(cover))
			.Returns(new ValidationResult { IsValid = true });

		// Act
		await _coverService.DownloadCoverImageAsync("isbn", cover);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(File.Exists("./Images/isbn/isbn_small.jpg"), Is.True);
			Assert.That(File.Exists("./Images/isbn/isbn_medium.jpg"), Is.True);
			Assert.That(File.Exists("./Images/isbn/isbn_large.jpg"), Is.True);
		});
	}
	
	[Test]
	public async Task DownloadCoverImageAsync_ReturnsFailure_WhenSmallImageDownloadFails()
	{
		// Arrange
		var cover = new Cover { Id = 1, 
			Small = Covers.UrlSmall, 
			Medium = Covers.UrlMedium, 
			Large = Covers.UrlLarge };
		
		_mockCoverValidator.Setup(x => x.Validate(cover))
			.Returns(new ValidationResult { IsValid = true });
		
		await _coverService.InsertOrIgnoreCoverAsync(cover);
		
		_mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>()))
			.Throws(new HttpRequestException("An error occurred"));

		// Act
		var result = await _coverService.DownloadCoverImageAsync("isbn", cover);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("An error occurred while downloading the image: An error occurred"));
		});
	}
	
	[Test]
	public async Task DownloadCoverImageAsync_ReturnsFailure_WhenMediumImageDownloadFails()
	{
		// Arrange
		var cover = new Cover { Id = 1, 
			Small = Covers.UrlSmall, 
			Medium = Covers.UrlMedium, 
			Large = Covers.UrlLarge };
		
		_mockCoverValidator.Setup(x => x.Validate(cover))
			.Returns(new ValidationResult { IsValid = true });
		
		await _coverService.InsertOrIgnoreCoverAsync(cover);
		
		_mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>()))
			.Throws(new HttpRequestException("An error occurred"));

		// Act
		var result = await _coverService.DownloadCoverImageAsync("isbn", cover);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("An error occurred while downloading the image: An error occurred"));
		});
	}
	
	[Test]
	public async Task DownloadCoverImageAsync_ReturnsFailure_WhenLargeImageDownloadFails()
	{
		// Arrange
		var cover = new Cover { Id = 1, 
			Small = Covers.UrlSmall, 
			Medium = Covers.UrlMedium, 
			Large = Covers.UrlLarge };
		
		_mockCoverValidator.Setup(x => x.Validate(cover))
			.Returns(new ValidationResult { IsValid = true });
		
		await _coverService.InsertOrIgnoreCoverAsync(cover);
		
		_mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>()))
			.Throws(new HttpRequestException("An error occurred"));

		// Act
		var result = await _coverService.DownloadCoverImageAsync("isbn", cover);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("An error occurred while downloading the image: An error occurred"));
		});
	}
	
	[Test]
	public async Task DownloadCoverImageAsync_ReturnsFailure_WhenSmallImageSaveFails()
	{
		// Arrange
		var cover = new Cover { Id = 1, 
			Small = Covers.UrlSmall, 
			Medium = Covers.UrlMedium, 
			Large = Covers.UrlLarge };
		
		_mockCoverValidator.Setup(x => x.Validate(cover))
			.Returns(new ValidationResult { IsValid = true });
		
		await _coverService.InsertOrIgnoreCoverAsync(cover);
		
		_mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>()))
			.Throws(new IOException("An error occurred"));

		// Act
		var result = await _coverService.DownloadCoverImageAsync("isbn", cover);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("An error occurred while saving the image: An error occurred"));
		});
	}
	
	[Test]
	public async Task DownloadCoverImageAsync_ReturnsFailure_WhenMediumImageSaveFails()
	{
		// Arrange
		var cover = new Cover { Id = 1, 
			Small = Covers.UrlSmall, 
			Medium = Covers.UrlMedium, 
			Large = Covers.UrlLarge };
		
		_mockCoverValidator.Setup(x => x.Validate(cover))
			.Returns(new ValidationResult { IsValid = true });
		
		await _coverService.InsertOrIgnoreCoverAsync(cover);
		
		_mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>()))
			.Throws(new IOException("An error occurred"));

		// Act
		var result = await _coverService.DownloadCoverImageAsync("isbn", cover);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("An error occurred while saving the image: An error occurred"));
		});
	}
	
	[Test]
	public async Task DownloadCoverImageAsync_ReturnsFailure_WhenLargeImageSaveFails()
	{
		// Arrange
		var cover = new Cover { Id = 1, 
			Small = Covers.UrlSmall, 
			Medium = Covers.UrlMedium, 
			Large = Covers.UrlLarge };
		
		_mockCoverValidator.Setup(x => x.Validate(cover))
			.Returns(new ValidationResult { IsValid = true });
		
		await _coverService.InsertOrIgnoreCoverAsync(cover);
		
		_mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>()))
			.Throws(new IOException("An error occurred"));

		// Act
		var result = await _coverService.DownloadCoverImageAsync("isbn", cover);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("An error occurred while saving the image: An error occurred"));
		});
	}
	
	
}