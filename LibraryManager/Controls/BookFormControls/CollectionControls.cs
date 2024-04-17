namespace LibraryManager.Controls.BookFormControls
{
	public static class CollectionControls
	{
		
		public static ListBox CreateListBoxBookCollectionsViewMode()
		{
			var listBoxCollections = new ListBox
			{
				Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
				ItemHeight = 20,
				Location = new System.Drawing.Point(463, 190),
				Name = "listBoxCollections",
				Size = new System.Drawing.Size(366, 124)
			};

			return listBoxCollections;
		}
		
		public static Control[] CreateBookCollectionControlsEditMode()
		{
			var listBoxAllCollections = CreateListBoxAllCollections();
			var listBoxBookCollections = CreateListBoxBookCollections();
			var buttonAddCollection = CreateButtonAddCollection();
			var buttonRemoveCollection = CreateButtonRemoveCollection();

			return new Control[]
			{
				listBoxBookCollections,
				listBoxAllCollections,
				buttonAddCollection,
				buttonRemoveCollection
			};
		}

		private static ListBox CreateListBoxAllCollections()
		{
			var listBoxAllCollections = new ListBox
			{
				Font = new System.Drawing.Font(
					"Microsoft Sans Serif", 
					12F, 
					System.Drawing.FontStyle.Regular,
					System.Drawing.GraphicsUnit.Point,
					((byte) (0))),
				FormattingEnabled = true,
				ItemHeight = 20,
				Location = new System.Drawing.Point(463, 190),
				Name = "listBoxAllCollections",
				Size = new System.Drawing.Size(153, 124)
			};

			return listBoxAllCollections;
		}
		
		private static ListBox CreateListBoxBookCollections()
		{
			var listBoxBookCollections = new ListBox
			{
				Font = new System.Drawing.Font(
					"Microsoft Sans Serif", 
					12F,
					System.Drawing.FontStyle.Regular, 
					System.Drawing.GraphicsUnit.Point, 
					((byte) (0))),
				FormattingEnabled = true,
				ItemHeight = 20,
				Location = new System.Drawing.Point(677, 190),
				Name = "listBoxBookCollections",
				Size = new System.Drawing.Size(153, 124)
			};

			return listBoxBookCollections;
		}
		
		private static Button CreateButtonAddCollection()
		{
			var buttonAddCollection = new Button
			{
				Font = new System.Drawing.Font(
					"Microsoft Sans Serif", 
					12F, 
					System.Drawing.FontStyle.Regular, 
					System.Drawing.GraphicsUnit.Point, 
					((byte) (0))),
				Location = new System.Drawing.Point(622, 206),
				Name = "btnAddCollectionToBook",
				Size = new System.Drawing.Size(49, 46),
				TabIndex = 31,
				Text = ">>"
			};

			return buttonAddCollection;
		}
		
		private static Button CreateButtonRemoveCollection()
		{
			var buttonRemoveCollection = new Button
			{
				Font = new System.Drawing.Font(
					"Microsoft Sans Serif", 
					12F, 
					System.Drawing.FontStyle.Regular,
					System.Drawing.GraphicsUnit.Point, 
					((byte) (0))),
				Location = new System.Drawing.Point(622, 258),
				Name = "btnRemoveCollectionFromBook",
				Size = new System.Drawing.Size(49, 46),
				TabIndex = 30,
				Text = "<<"
			};

			return buttonRemoveCollection;
		}
	}
}