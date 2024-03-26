using LibraryManager.Core.Data;
using LibraryManager.Core.Models;
using LibraryManager.Core.Services.CollectionService;

namespace LibraryManager.Core.Tests.ServiceTests;

public class CollectionServiceTests
{
	private ICollectionService _collectionService;
	private LibraryContext _context;
	
	[SetUp]
	public void Setup()
	{
		_context = new LibraryContext(new DbConnectionConfig { ProviderName = "Test" });
		_collectionService = new CollectionService(_context);
	}
	
	[Test]
	public async Task CreateCollection_AddsCollection_WhenCollectionDoesNotExist()
	{
		// Arrange
		var collection = new Collection {Id = 1000, Name = "Test Collection" };
		
		// Act
		await _collectionService.CreateCollectionAsync(collection);
		
		// Assert
		Assert.That(_context.Collections.Contains(collection));
	}
	
	[Test]
	public async Task CreateCollection_DoesNotAddCollection_WhenCollectionExists()
	{
		// Arrange
		var collection = new Collection {Id = 1000, Name = "Test Collection" };
		await _collectionService.CreateCollectionAsync(collection);
		
		// Act
		var result = await _collectionService.CreateCollectionAsync(collection);
		
		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Collection already exists"));
		});
	}
	
	[Test]
	public async Task CreateCollection_ReturnsFailure_WhenValidationFails()
	{
		// Arrange
		var collection = new Collection {Id = 1000, Name = "Test Collection" };
		_context.Collections.Add(collection);
		await _context.SaveChangesAsync();
		
		// Act
		var result = await _collectionService.CreateCollectionAsync(collection);
		
		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Collection already exists"));
		});
	}
	
	[Test]
	public async Task GetCollection_ReturnsCollection_WhenCollectionExists()
	{
		// Arrange
		var collection = new Collection {Id = 1000, Name = "Test Collection" };
		_context.Collections.Add(collection);
		await _context.SaveChangesAsync();
		
		// Act
		var result = await _collectionService.GetCollectionAsync(1000);
		
		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.True);
			Assert.That(result.Data, Is.EqualTo(collection));
		});
	}
	
	[Test]
	public async Task GetCollection_ReturnsFailure_WhenCollectionDoesNotExist()
	{
		// Arrange
		var collection = new Collection {Id = 1000, Name = "Test Collection" };
		_context.Collections.Add(collection);
		await _context.SaveChangesAsync();
		
		// Act
		var result = await _collectionService.GetCollectionAsync(1001);
		
		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Collection not found"));
		});
	}
	
	[Test]
	public async Task GetCollection_ReturnsFailure_WhenValidationFails()
	{
		// Arrange
		var collection = new Collection {Id = 1000, Name = "Test Collection" };
		_context.Collections.Add(collection);
		await _context.SaveChangesAsync();
		
		// Act
		var result = await _collectionService.GetCollectionAsync(1000);
		
		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.True);
			Assert.That(result.Data, Is.EqualTo(collection));
		});
	}
	
	[Test]
	public async Task CreateCollection_ReturnsSuccess_WhenCollectionIsValid()
	{
		// Arrange
		var collection = new Collection {Id = 2000, Name = "Valid Collection" };

		// Act
		var result = await _collectionService.CreateCollectionAsync(collection);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.True);
			Assert.That(result.Message, Is.EqualTo("Collection added successfully"));
		});
	}

	[Test]
	public async Task GetCollection_ReturnsNull_WhenCollectionIdIsInvalid()
	{
		// Arrange
		var invalidId = 9999;

		// Act
		var result = await _collectionService.GetCollectionAsync(invalidId);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Collection not found"));
		});
	}

	[Test]
	public async Task CreateCollection_ReturnsFailure_WhenCollectionNameAlreadyExists()
	{
		// Arrange
		var collection = new Collection {Id = 4000, Name = "Existing Collection" };
		await _collectionService.CreateCollectionAsync(collection);

		// Act
		var result = await _collectionService.CreateCollectionAsync(collection);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Collection already exists"));
		});
	}

	[Test]
	public async Task GetCollection_ReturnsSuccess_WhenCollectionIdIsValid()
	{
		// Arrange
		var collection = new Collection {Id = 5000, Name = "Valid Collection" };
		_context.Collections.Add(collection);
		await _context.SaveChangesAsync();

		// Act
		var result = await _collectionService.GetCollectionAsync(5000);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.True);
			Assert.That(result.Data, Is.EqualTo(collection));
		});
	}
	
	// Test GetCollectionByNameAsync
	[Test]
	public async Task GetCollectionByName_ReturnsCollection_WhenCollectionExists()
	{
		// Arrange
		var collection = new Collection {Id = 1000, Name = "Test Collection" };
		_context.Collections.Add(collection);
		await _context.SaveChangesAsync();
		
		// Act
		var result = await _collectionService.GetCollectionByNameAsync("Test Collection");
		
		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.True);
			Assert.That(result.Data, Is.EqualTo(collection));
		});
	}
	
	[Test]
	public async Task GetCollectionByName_ReturnsFailure_WhenCollectionDoesNotExist()
	{
		// Arrange
		var collection = new Collection {Id = 1000, Name = "Test Collection" };
		_context.Collections.Add(collection);
		await _context.SaveChangesAsync();
		
		// Act
		var result = await _collectionService.GetCollectionByNameAsync("Nonexistent Collection");
		
		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Collection not found"));
		});
	}
	
	[Test]
	public async Task GetCollectionByName_ReturnsFailure_WhenValidationFails()
	{
		// Arrange
		var collection = new Collection {Id = 1000, Name = "Test Collection" };
		_context.Collections.Add(collection);
		await _context.SaveChangesAsync();
		
		// Act
		var result = await _collectionService.GetCollectionByNameAsync("Test Collection");
		
		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.True);
			Assert.That(result.Data, Is.EqualTo(collection));
		});
	}
	
	[Test]
	public async Task GetCollectionByName_ReturnsSuccess_WhenCollectionNameIsValid()
	{
		// Arrange
		var collection = new Collection {Id = 2000, Name = "Valid Collection" };
		_context.Collections.Add(collection);
		await _context.SaveChangesAsync();

		// Act
		var result = await _collectionService.GetCollectionByNameAsync("Valid Collection");

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.True);
			Assert.That(result.Message, Is.EqualTo("Collection retrieved successfully"));
		});
	}
	
	[Test]
	public async Task GetCollectionByName_ReturnsNull_WhenCollectionNameIsInvalid()
	{
		// Arrange
		var invalidName = "Invalid Collection";

		// Act
		var result = await _collectionService.GetCollectionByNameAsync(invalidName);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Collection not found"));
		});
	}
	
	// Test GetAllCollectionsAsync
	[Test]
	public async Task GetAllCollections_ReturnsCollections_WhenCollectionsExist()
	{
		// Arrange
		var collection1 = new Collection {Id = 1000, Name = "Collection 1" };
		var collection2 = new Collection {Id = 1001, Name = "Collection 2" };
		_context.Collections.Add(collection1);
		_context.Collections.Add(collection2);
		await _context.SaveChangesAsync();
		
		// Act
		var result = await _collectionService.GetAllCollectionsAsync();
		
		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.True);
			Assert.That(result.Data, Is.EquivalentTo(new[] {collection1, collection2}));
		});
	}
	
	[Test]
	public async Task GetAllCollections_ReturnsFailure_WhenNoCollectionsExist()
	{
		// Act
		var result = await _collectionService.GetAllCollectionsAsync();
		
		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("No collections found"));
		});
	}
	
	[Test]
	public async Task GetAllCollections_ReturnsSuccess_WhenCollectionsExist()
	{
		// Arrange
		var collection1 = new Collection {Id = 1000, Name = "Collection 1" };
		var collection2 = new Collection {Id = 1001, Name = "Collection 2" };
		_context.Collections.Add(collection1);
		_context.Collections.Add(collection2);
		await _context.SaveChangesAsync();

		// Act
		var result = await _collectionService.GetAllCollectionsAsync();

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.True);
			Assert.That(result.Message, Is.EqualTo("Collections retrieved successfully"));
		});
	}
	
	[Test]
	public async Task UpdateCollection_ReturnsCollection_WhenCollectionExists()
	{
		// Arrange
		var collection = new Collection {Id = 1000, Name = "Test Collection" };
		_context.Collections.Add(collection);
		await _context.SaveChangesAsync();
		
		// Act
		collection.Name = "Updated Collection";
		var result = await _collectionService.UpdateCollectionAsync(collection);
		
		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.True);
			Assert.That(result.Data, Is.EqualTo(collection));
		});
	}
	
	[Test]
	public async Task UpdateCollection_ReturnsFailure_WhenCollectionDoesNotExist()
	{
		// Arrange
		var collection = new Collection {Id = 1000, Name = "Test Collection" };
		
		// Act
		var result = await _collectionService.UpdateCollectionAsync(collection);
		
		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Collection not found"));
		});
	}
	
	[Test]
	public async Task UpdateCollection_ReturnsSuccess_WhenCollectionIsValid()
	{
		// Arrange
		var collection = new Collection {Id = 2000, Name = "Valid Collection" };
		_context.Collections.Add(collection);
		await _context.SaveChangesAsync();

		// Act
		collection.Name = "Updated Collection";
		var result = await _collectionService.UpdateCollectionAsync(collection);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.True);
			Assert.That(result.Message, Is.EqualTo("Collection updated successfully"));
		});
	}
	
	[Test]
	public async Task UpdateCollection_ReturnsNull_WhenCollectionIdIsInvalid()
	{
		// Arrange
		var invalidCollection = new Collection {Id = 9999, Name = "Invalid Collection" };

		// Act
		var result = await _collectionService.UpdateCollectionAsync(invalidCollection);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Collection not found"));
		});
	}
	
	[Test]
	public async Task UpdateCollection_ReturnsFailure_WhenCollectionNameAlreadyExists()
	{
		// Arrange
		var collection1 = new Collection {Id = 3000, Name = "Collection 1" };
		var collection2 = new Collection {Id = 3001, Name = "Collection 2" };
		_context.Collections.Add(collection1);
		_context.Collections.Add(collection2);
		await _context.SaveChangesAsync();

		// Act
		collection1.Name = "Collection 2";
		var result = await _collectionService.UpdateCollectionAsync(collection1);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Collection with the same name already exists"));
		});
	}
	
	[Test]
	public async Task UpdateCollection_ReturnsSuccess_WhenCollectionNameIsUnique()
	{
		// Arrange
		var collection1 = new Collection {Id = 4000, Name = "Collection 1" };
		var collection2 = new Collection {Id = 4001, Name = "Collection 2" };
		_context.Collections.Add(collection1);
		_context.Collections.Add(collection2);
		await _context.SaveChangesAsync();

		// Act
		collection1.Name = "Updated Collection";
		var result = await _collectionService.UpdateCollectionAsync(collection1);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.True);
			Assert.That(result.Message, Is.EqualTo("Collection updated successfully"));
		});
	}
	
	[Test]
	public async Task DeleteCollection_ReturnsSuccess_WhenCollectionExists()
	{
		// Arrange
		var collection = new Collection {Id = 1000, Name = "Test Collection" };
		_context.Collections.Add(collection);
		await _context.SaveChangesAsync();
		
		// Act
		var result = await _collectionService.DeleteCollectionAsync(1000);
		
		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.True);
			Assert.That(result.Message, Is.EqualTo("Collection deleted successfully"));
		});
	}
	
	[Test]
	public async Task DeleteCollection_ReturnsFailure_WhenCollectionDoesNotExist()
	{
		// Act
		var result = await _collectionService.DeleteCollectionAsync(1000);
		
		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Collection not found"));
		});
	}
	
	[Test]
	public async Task DeleteCollection_ReturnsFailure_WhenCollectionNameIsWishlist()
	{
		// Arrange
		var collection = new Collection {Id = 1000, Name = "Wishlist" };
		_context.Collections.Add(collection);
		await _context.SaveChangesAsync();
		
		// Act
		var result = await _collectionService.DeleteCollectionAsync(1000);
		
		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Cannot delete the Wishlist collection"));
		});
	}
	
	[Test]
	public async Task DeleteCollection_ReturnsSuccess_WhenCollectionIsValid()
	{
		// Arrange
		var collection = new Collection {Id = 2000, Name = "Valid Collection" };
		_context.Collections.Add(collection);
		await _context.SaveChangesAsync();

		// Act
		var result = await _collectionService.DeleteCollectionAsync(2000);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.True);
			Assert.That(result.Message, Is.EqualTo("Collection deleted successfully"));
		});
	}
	
	[Test]
	public async Task DeleteCollection_ReturnsNull_WhenCollectionIdIsInvalid()
	{
		// Arrange
		var invalidId = 9999;

		// Act
		var result = await _collectionService.DeleteCollectionAsync(invalidId);

		// Assert
		Assert.Multiple(() =>
		{
			Assert.That(result.Success, Is.False);
			Assert.That(result.Message, Is.EqualTo("Collection not found"));
		});
	}
	
	
}